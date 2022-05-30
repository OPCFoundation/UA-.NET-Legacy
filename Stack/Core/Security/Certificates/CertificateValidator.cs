/* Copyright (c) 1996-2022 The OPC Foundation. All rights reserved.
   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation Corporate Members in good-standing
     - GPL V2: everybody else
   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/
   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2
   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Selectors;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Opc.Ua
{
    /// <summary>
    /// Validates certificates.
    /// </summary>
    public class CertificateValidator : ICertificateValidator
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public CertificateValidator()
        {
            m_validatedCertificates = new Dictionary<string, X509Certificate2>();
            m_protectFlags = 0;
            m_autoAcceptUntrustedCertificates = false;
            m_rejectSHA1SignedCertificates = CertificateFactory.DefaultHashSize >= 256;
            m_rejectUnknownRevocationStatus = false;
            m_minimumCertificateKeySize = CertificateFactory.DefaultKeySize;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Raised when a certificate validation error occurs.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public event CertificateValidationEventHandler CertificateValidation
        {
            add
            {
                lock (m_callbackLock)
                {
                    m_CertificateValidation += value;
                }
            }

            remove
            {
                lock (m_callbackLock)
                {
                    m_CertificateValidation -= value;
                }
            }
        }

        /// <summary>
        /// Raised when an application certificate update occurs.
        /// </summary>
        public event CertificateUpdateEventHandler CertificateUpdate
        {
            add
            {
                lock (m_callbackLock)
                {
                    m_CertificateUpdate += value;
                }
            }

            remove
            {
                lock (m_callbackLock)
                {
                    m_CertificateUpdate -= value;
                }
            }
        }

        /// <summary>
        /// Updates the validator with the current state of the configuration.
        /// </summary>
        public virtual void Update(ApplicationConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Update(configuration.SecurityConfiguration);
        }

        /// <summary>
        /// Updates the validator with a new set of trust lists.
        /// </summary>
        public virtual void Update(
            CertificateTrustList issuerStore,
            CertificateTrustList trustedStore,
            CertificateStoreIdentifier rejectedCertificateStore)
        {
            lock (m_lock)
            {
                ResetValidatedCertificates();

                m_trustedCertificateStore = null;
                m_trustedCertificateList = null;

                if (trustedStore != null)
                {
                    m_trustedCertificateStore = new CertificateStoreIdentifier();

                    m_trustedCertificateStore.StoreType = trustedStore.StoreType;
                    m_trustedCertificateStore.StorePath = trustedStore.StorePath;
                    m_trustedCertificateStore.ValidationOptions = trustedStore.ValidationOptions;

                    if (trustedStore.TrustedCertificates != null)
                    {
                        m_trustedCertificateList = new CertificateIdentifierCollection();
                        m_trustedCertificateList.AddRange(trustedStore.TrustedCertificates);
                    }
                }

                m_issuerCertificateStore = null;
                m_issuerCertificateList = null;

                if (issuerStore != null)
                {
                    m_issuerCertificateStore = new CertificateStoreIdentifier();

                    m_issuerCertificateStore.StoreType = issuerStore.StoreType;
                    m_issuerCertificateStore.StorePath = issuerStore.StorePath;
                    m_issuerCertificateStore.ValidationOptions = issuerStore.ValidationOptions;

                    if (issuerStore.TrustedCertificates != null)
                    {
                        m_issuerCertificateList = new CertificateIdentifierCollection();
                        m_issuerCertificateList.AddRange(issuerStore.TrustedCertificates);
                    }
                }

                m_rejectedCertificateStore = null;

                if (rejectedCertificateStore != null)
                {
                    m_rejectedCertificateStore = (CertificateStoreIdentifier)rejectedCertificateStore.MemberwiseClone();
                }
            }
        }

        /// <summary>
        /// Updates the validator with the current state of the configuration.
        /// </summary>
        public virtual void Update(SecurityConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            lock (m_lock)
            {
                Update(
                    configuration.TrustedIssuerCertificates,
                    configuration.TrustedPeerCertificates,
                    configuration.RejectedCertificateStore);
                // protect the flags if application called to set property
                if ((m_protectFlags & ProtectFlags.AutoAcceptUntrustedCertificates) == 0)
                {
                    m_autoAcceptUntrustedCertificates = configuration.AutoAcceptUntrustedCertificates;
                }
            }

            if (configuration.ApplicationCertificate != null)
            {
                m_applicationCertificate = configuration.ApplicationCertificate.Find(true);
            }
        }


        /// <summary>
        /// Reset the list of validated certificates.
        /// </summary>
        public void ResetValidatedCertificates()
        {
            lock (m_lock)
            {
                // dispose outdated list
                foreach (var cert in m_validatedCertificates.Values)
                {
                    Utils.SilentDispose(cert);
                }
                m_validatedCertificates.Clear();
            }
        }

        /// <summary>
        /// If untrusted certificates should be accepted.
        /// </summary>
        public bool AutoAcceptUntrustedCertificates
        {
            get => m_autoAcceptUntrustedCertificates;
            set
            {
                lock (m_lock)
                {
                    m_protectFlags |= ProtectFlags.AutoAcceptUntrustedCertificates;
                    if (m_autoAcceptUntrustedCertificates != value)
                    {
                        m_autoAcceptUntrustedCertificates = value;
                        ResetValidatedCertificates();
                    }
                }
            }
        }

        /// <summary>
        /// If certificates using a SHA1 signature should be trusted.
        /// </summary>
        public bool RejectSHA1SignedCertificates
        {
            get => m_rejectSHA1SignedCertificates;
            set
            {
                lock (m_lock)
                {
                    m_protectFlags |= ProtectFlags.RejectSHA1SignedCertificates;
                    if (m_rejectSHA1SignedCertificates != value)
                    {
                        m_rejectSHA1SignedCertificates = value;
                        ResetValidatedCertificates();
                    }
                }
            }
        }

        /// <summary>
        /// if certificates with unknown revocation status should be rejected.
        /// </summary>
        public bool RejectUnknownRevocationStatus
        {
            get => m_rejectUnknownRevocationStatus;
            set
            {
                lock (m_lock)
                {
                    m_protectFlags |= ProtectFlags.RejectUnknownRevocationStatus;
                    if (m_rejectUnknownRevocationStatus != value)
                    {
                        m_rejectUnknownRevocationStatus = value;
                        ResetValidatedCertificates();
                    }
                }
            }
        }

        /// <summary>
        /// The minimum size of a certificate key to be trusted.
        /// </summary>
        public ushort MinimumCertificateKeySize
        {
            get => m_minimumCertificateKeySize;
            set
            {
                lock (m_lock)
                {
                    m_protectFlags |= ProtectFlags.MinimumCertificateKeySize;
                    if (m_minimumCertificateKeySize != value)
                    {
                        m_minimumCertificateKeySize = value;
                        ResetValidatedCertificates();
                    }
                }
            }
        }

        /// <summary>
        /// Validates the specified certificate against the trust list.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        public void Validate(X509Certificate2 certificate)
        {
            Validate(new X509Certificate2Collection() { certificate });
        }

        /// <summary>
        /// Validates a certificate.
        /// </summary>
        /// <remarks>
        /// Each UA application may have a list of trusted certificates that is different from 
        /// all other UA applications that may be running on the same machine. As a result, the
        /// certificate validator cannot rely completely on the Windows certificate store and
        /// user or machine specific CTLs (certificate trust lists).
        ///
        /// The validator constructs the trust chain for the certificate and follows the chain
        /// until it finds a certification that is in the application trust list. Non-fatal trust
        /// chain errors (i.e. certificate expired) are ignored if the certificate is in the 
        /// application trust list.
        ///
        /// If no certificate in the chain is trusted then the validator will still accept the
        /// certification if there are no trust chain errors.
        /// 
        /// The validator may be configured to ignore the application trust list and/or trust chain.
        /// </remarks>
        public virtual void Validate(X509Certificate2Collection chain)
        {
            Validate(chain, null);
        }

        /// <summary>
        /// Validates a certificate with domain validation check.
        /// <see cref="Validate(X509Certificate2Collection)"/>
        /// </summary>
        public virtual void Validate(X509Certificate2Collection chain, ConfiguredEndpoint endpoint)
        {
            X509Certificate2 certificate = chain[0];

            try
            {
                lock (m_lock)
                {
                    InternalValidate(chain, endpoint).GetAwaiter().GetResult();

                    // add to list of validated certificates.
                    m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
                }
            }
            catch (ServiceResultException se)
            {
                // check for errors that may be suppressed.
                if (ContainsUnsuppressibleSC(se.Result))
                {
                    SaveCertificate(certificate);
                    Utils.LogCertificate(Utils.TraceMasks.Error, "Certificate rejected. Reason={0}.",
                        certificate, se.Result.StatusCode);
                    LogInnerServiceResults(Utils.TraceMasks.Error, se.Result.InnerResult);
                    throw new ServiceResultException(se, StatusCodes.BadCertificateInvalid);
                }
                else
                {
                    Utils.LogCertificate(Utils.TraceMasks.Information, "Certificate Validation failed. Reason={0}.",
                        certificate, se.Result.StatusCode);
                    LogInnerServiceResults(Utils.TraceMasks.Information, se.Result.InnerResult);
                }

                // invoke callback.
                bool accept = false;

                ServiceResult serviceResult = se.Result;
                lock (m_callbackLock)
                {
                    do
                    {
                        accept = false;
                        if (m_CertificateValidation != null)
                        {
                            CertificateValidationEventArgs args = new CertificateValidationEventArgs(serviceResult, certificate);
                            m_CertificateValidation(this, args);
                            if (args.AcceptAll)
                            {
                                accept = true;
                                serviceResult = null;
                                break;
                            }
                            accept = args.Accept;
                        }
                        else if (m_autoAcceptUntrustedCertificates &&
                            serviceResult.StatusCode == StatusCodes.BadCertificateUntrusted)
                        {
                            accept = true;
                            Utils.LogCertificate("Auto accepted certificate: ", certificate);
                        }

                        if (accept)
                        {
                            serviceResult = serviceResult.InnerResult;
                        }
                        else
                        {
                            // report the rejected service result
                            se = new ServiceResultException(serviceResult);
                        }
                    } while (accept && serviceResult != null);
                }

                // throw if rejected.
                if (!accept)
                {
                    // write the invalid certificate to rejected store if specified.
                    Utils.LogCertificate(Utils.TraceMasks.Error, "Certificate rejected. Reason={0}.",
                        certificate, serviceResult != null ? serviceResult.StatusCode.ToString() : "Unknown Error");

                    SaveCertificate(certificate);

                    throw new ServiceResultException(se, StatusCodes.BadCertificateInvalid);
                }

                // add to list of peers.
                lock (m_lock)
                {
                    Utils.LogCertificate(Utils.TraceMasks.Information, "Validation errors suppressed: ", certificate);
                    m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
                }
            }
        }

        /// <summary>
        /// Recursively checks whether any of the service results or inner service results
        /// of the input sr must not be suppressed.
        /// The list of supressible status codes is - for backwards compatibiliyt - longer
        /// than the spec would imply.
        /// (BadCertificateUntrusted and BadCertificateChainIncomplete
        /// must not be supressed according to (e.g.) version 1.04 of the spec)
        /// </summary>
        /// <param name="sr"></param>
        private static bool ContainsUnsuppressibleSC(ServiceResult sr)
        {
            while (sr != null)
            {
                if (!m_suppressibleStatusCodes.Contains(sr.StatusCode))
                {
                    return true;
                }
                sr = sr.InnerResult;
            }
            return false;
        }

        /// <summary>
        /// List all reasons for failing cert validation.
        /// </summary>
        private static void LogInnerServiceResults(int traceLevel, ServiceResult result)
        {
            while (result != null)
            {
                Utils.Trace(Utils.TraceMasks.Security, " -- {0}", result.ToString());
                result = result.InnerResult;
            }
        }

        /// <summary>
        /// Saves the certificate in the rejected certificate store.
        /// </summary>
        private void SaveCertificate(X509Certificate2 certificate)
        {
            lock (m_lock)
            {
                if (m_rejectedCertificateStore != null)
                {
                    Utils.Trace(Utils.TraceMasks.Security, "Writing rejected certificate to: {0}", m_rejectedCertificateStore);
                    try
                    {
                        ICertificateStore store = m_rejectedCertificateStore.OpenStore();
                        try
                        {
                            store.Delete(certificate.Thumbprint);
                            store.Add(certificate);
                        }
                        finally
                        {
                            store.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Utils.Trace(e, "Could not write certificate to directory: {0}", m_rejectedCertificateStore);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the certificate information for a trusted peer certificate.
        /// </summary>
        private CertificateIdentifier GetTrustedCertificate(X509Certificate2 certificate)
        {
            // check if explicitly trusted.
            if (m_trustedCertificateList != null)
            {
                for (int ii = 0; ii < m_trustedCertificateList.Count; ii++)
                {
                    X509Certificate2 trusted = m_trustedCertificateList[ii].Find(false);

                    if (trusted != null && trusted.Thumbprint == certificate.Thumbprint)
                    {
                        if (Utils.IsEqual(trusted.RawData, certificate.RawData))
                        {
                            return m_trustedCertificateList[ii];
                        }
                    }
                }
            }

            // check if in peer trust store.
            if (m_trustedCertificateStore != null)
            {
                ICertificateStore store = m_trustedCertificateStore.OpenStore();

                try
                {
                    X509Certificate2 trusted = store.FindByThumbprint(certificate.Thumbprint);

                    if (trusted != null && Utils.IsEqual(trusted.RawData, certificate.RawData))
                    {
                        return new CertificateIdentifier(trusted, m_trustedCertificateStore.ValidationOptions);
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            // not a trusted.
            return null;
        }

        /// <summary>
        /// Returns true if the certificate matches the criteria.
        /// </summary>
        private bool Match(
            X509Certificate2 certificate,
            X500DistinguishedName subjectName,
            string serialNumber,
            string authorityKeyId)
        {
            bool check = false;

            // check for null.
            if (certificate == null)
            {
                return false;
            }

            // check for subject name match.
            if (!X509Utils.CompareDistinguishedName(certificate.SubjectName, subjectName))
            {
                return false;
            }

            // check for serial number match.
            if (!String.IsNullOrEmpty(serialNumber))
            {
                if (certificate.SerialNumber != serialNumber)
                {
                    return false;
                }
                check = true;
            }

            // check for authority key id match.
            if (!String.IsNullOrEmpty(authorityKeyId))
            {
                X509SubjectKeyIdentifierExtension subjectKeyId = X509Extensions.FindExtension<X509SubjectKeyIdentifierExtension>(certificate);

                if (subjectKeyId != null)
                {
                    if (subjectKeyId.SubjectKeyIdentifier != authorityKeyId)
                    {
                        return false;
                    }
                    check = true;
                }
            }

            // found match if keyId or serial number was checked
            return check;
        }

        /// <summary>
        /// Returns the issuers for the certificates.
        /// </summary>
        public bool GetIssuersNoExceptionsOnGetIssuer(X509Certificate2Collection certificates,
            List<CertificateIdentifier> issuers, Dictionary<X509Certificate2, ServiceResultException> validationErrors)
        {
            bool isTrusted = false;
            CertificateIdentifier issuer = null;
            ServiceResultException revocationStatus = null;
            X509Certificate2 certificate = certificates[0];

            CertificateIdentifierCollection untrustedCollection = new CertificateIdentifierCollection();
            for (int ii = 1; ii < certificates.Count; ii++)
            {
                untrustedCollection.Add(new CertificateIdentifier(certificates[ii]));
            }

            do
            {
                // check for root.
                if (X509Utils.IsSelfSigned(certificate))
                {
                    break;
                }

                if (validationErrors != null)
                {
                    (issuer, revocationStatus) = GetIssuerNoException(certificate, m_trustedCertificateList, m_trustedCertificateStore, true);
                }
                else
                {
                    issuer = GetIssuer(certificate, m_trustedCertificateList, m_trustedCertificateStore, true);
                }

                if (issuer == null)
                {
                    if (validationErrors != null)
                    {
                        (issuer, revocationStatus) = GetIssuerNoException(certificate, m_issuerCertificateList, m_issuerCertificateStore, true);
                    }
                    else
                    {
                        issuer = GetIssuer(certificate, m_issuerCertificateList, m_issuerCertificateStore, true);
                    }

                    if (issuer == null)
                    {
                        if (validationErrors != null)
                        {
                            (issuer, revocationStatus) = GetIssuerNoException(certificate, untrustedCollection, null, true);
                        }
                        else
                        {
                            issuer = GetIssuer(certificate, untrustedCollection, null, true);
                        }
                    }
                }
                else
                {
                    isTrusted = true;
                }

                if (issuer != null)
                {
                    if (validationErrors != null)
                    {
                        validationErrors[certificate] = revocationStatus;
                    }

                    if (issuers.Find(iss => string.Equals(iss.Thumbprint, issuer.Thumbprint, StringComparison.OrdinalIgnoreCase)) != default(CertificateIdentifier))
                    {
                        break;
                    }

                    issuers.Add(issuer);

                    certificate = issuer.Find(false);
                }
            }
            while (issuer != null);

            return isTrusted;
        }


        /// <summary>
        /// Returns the issuers for the certificates.
        /// </summary>
        [Obsolete("Class replaced by Opc.Ua.CertificateValidator.GetIssuers")]

        public bool GetIssuersWithChainSupportEnabled(X509Certificate2Collection certificates, List<CertificateIdentifier> issuers)
        {
            bool isTrusted = false;
            bool isChainComplete = false;
            CertificateIdentifier issuer = null;
            X509Certificate2 certificate = certificates[0];

            // application certificate is trusted
            CertificateIdentifier trustedCertificate = GetTrustedCertificate(certificate);
            if (trustedCertificate != null) isTrusted = true;

            if (Utils.CompareDistinguishedName(certificate.Subject, certificate.Issuer))
            {
                if (!isTrusted)
                {
                    throw ServiceResultException.Create(
                        StatusCodes.BadCertificateUntrusted,
                        "Self Signed Certificate is not trusted.\r\nIssuerName: {0}",
                        certificate.IssuerName.Name);

                }
                return isTrusted;
            }

            CertificateIdentifierCollection collection = new CertificateIdentifierCollection();

            for (int ii = 1; ii < certificates.Count; ii++)
            {
                collection.Add(new CertificateIdentifier(certificates[ii]));
            }

            do
            {
                issuer = GetIssuer(certificate, m_trustedCertificateList, m_trustedCertificateStore, true);
                if (issuer != null) isTrusted = true;

                if (issuer == null)
                {
                    issuer = GetIssuer(certificate, m_issuerCertificateList, m_issuerCertificateStore, true);

                    if (issuer == null)
                    {
                        issuer = GetIssuer(certificate, collection, null, true);
                    }
                }

                if (issuer != null)
                {
                    //isTrusted = true;

                    issuers.Add(issuer);
                    certificate = issuer.Find(false);

                    // check for root.
                    if (Utils.CompareDistinguishedName(certificate.Subject, certificate.Issuer))
                    {
                        isChainComplete = true;
                        break;
                    }
                }
                else
                {
                    isTrusted = false;
                }
            }
            while (issuer != null);
            if (!isChainComplete)
            {
                throw ServiceResultException.Create(
                StatusCodes.BadSecurityChecksFailed,
                "Certificate chain not complete.\r\nSubjectName: {0}\r\nIssuerName: {1}",
                    certificates[0].SubjectName.Name,
                    certificates[0].IssuerName.Name);
            }
            if (!isTrusted)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadCertificateUntrusted,
                    "Certificate issuer is not trusted.\r\nSubjectName: {0}\r\nIssuerName: {1}",
                            certificates[0].SubjectName.Name,
                            certificates[0].IssuerName.Name);

            }
            return isTrusted;
        }
        /// <summary>
        /// Returns the issuers for the certificates.
        /// </summary>
        public bool GetIssuers(X509Certificate2Collection certificates, List<CertificateIdentifier> issuers)
        {
            return GetIssuersNoExceptionsOnGetIssuer(
                certificates, issuers, null // ensures legacy behavior is respected
                );
        }

        /// <summary>
        /// Returns the issuers for the certificate.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        /// <param name="issuers">The issuers.</param>
        public bool GetIssuers(X509Certificate2 certificate, List<CertificateIdentifier> issuers)
        {
            return GetIssuers(new X509Certificate2Collection { certificate }, issuers);
        }

        /// <summary>
        /// Returns the certificate information for a trusted issuer certificate.
        /// </summary>
        private (CertificateIdentifier, ServiceResultException) GetIssuerNoException(
            X509Certificate2 certificate,
            CertificateIdentifierCollection explicitList,
            CertificateStoreIdentifier certificateStore,
            bool checkRecovationStatus)
        {
            ServiceResultException serviceResult = null;

#if DEBUG // check if not self-signed, tested in outer loop
            Debug.Assert(!X509Utils.IsSelfSigned(certificate));
#endif

            X500DistinguishedName subjectName = certificate.IssuerName;
            string keyId = null;
            string serialNumber = null;

            // find the authority key identifier.
            X509AuthorityKeyIdentifierExtension authority = X509Extensions.FindExtension<X509AuthorityKeyIdentifierExtension>(certificate);

            if (authority != null)
            {
                keyId = authority.KeyIdentifier;
                serialNumber = authority.SerialNumber;
            }

            // check in explicit list.
            if (explicitList != null)
            {
                for (int ii = 0; ii < explicitList.Count; ii++)
                {
                    X509Certificate2 issuer = explicitList[ii].Find(false);

                    if (issuer != null)
                    {
                        if (!X509Utils.IsIssuerAllowed(issuer))
                        {
                            continue;
                        }

                        if (Match(issuer, subjectName, serialNumber, keyId))
                        {
                            // can't check revocation.
                            return (new CertificateIdentifier(issuer, CertificateValidationOptions.SuppressRevocationStatusUnknown), null);
                        }
                    }
                }
            }

            // check in certificate store.
            if (certificateStore != null)
            {
                ICertificateStore store = certificateStore.OpenStore();

                try
                {
                    X509Certificate2Collection certificates = store.Enumerate();

                    for (int ii = 0; ii < certificates.Count; ii++)
                    {
                        X509Certificate2 issuer = certificates[ii];

                        if (issuer != null)
                        {
                            if (!X509Utils.IsIssuerAllowed(issuer))
                            {
                                continue;
                            }

                            if (Match(issuer, subjectName, serialNumber, keyId))
                            {
                                CertificateValidationOptions options = certificateStore.ValidationOptions;

                                // already checked revocation for file based stores. windows based stores always suppress.
                                options |= CertificateValidationOptions.SuppressRevocationStatusUnknown;

                                if (checkRecovationStatus)
                                {
                                    StatusCode status = store.IsRevoked(issuer, certificate);

                                    if (StatusCode.IsBad(status) && status != StatusCodes.BadNotSupported)
                                    {
                                        if (status == StatusCodes.BadCertificateRevocationUnknown)
                                        {
                                            if (X509Utils.IsCertificateAuthority(certificate))
                                            {
                                                status.Code = StatusCodes.BadCertificateIssuerRevocationUnknown;
                                            }

                                            if (m_rejectUnknownRevocationStatus)
                                            {
                                                serviceResult = new ServiceResultException(status);
                                            }
                                        }
                                        else
                                        {
                                            if (status == StatusCodes.BadCertificateRevoked && X509Utils.IsCertificateAuthority(certificate))
                                            {
                                                status.Code = StatusCodes.BadCertificateIssuerRevoked;
                                            }
                                            serviceResult = new ServiceResultException(status);
                                        }
                                    }
                                }

                                return (new CertificateIdentifier(issuer, options), serviceResult);
                            }
                        }
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            // not a trusted issuer.
            return (null, null);
        }

        /// <summary>
        /// Returns the certificate information for a trusted issuer certificate.
        /// </summary>
        private CertificateIdentifier GetIssuer(
            X509Certificate2 certificate,
            CertificateIdentifierCollection explicitList,
            CertificateStoreIdentifier certificateStore,
            bool checkRecovationStatus)
        {
            // check for root.
            if (X509Utils.IsSelfSigned(certificate))
            {
                return null;
            }

            (CertificateIdentifier result, ServiceResultException srex) =
                GetIssuerNoException(certificate, explicitList, certificateStore, checkRecovationStatus
                );
            if (srex != null)
            {
                throw srex;
            }
            return result;
        }

        /// <summary>
        /// Throws an exception if validation fails.
        /// </summary>
        /// <param name="certificates">The certificates to be checked.</param>
        /// <exception cref="ServiceResultException">If certificate[0] cannot be accepted</exception>
        [Obsolete("Class replaced by Opc.Ua.CertificateValidator.InternalValidate(X509Certificate2Collection certificates, ConfiguredEndpoint endpoint)")]
        protected virtual void InternalValidate(X509Certificate2Collection certificates)
        {
            lock (m_lock)
            {
                X509Certificate2 certificate = certificates[0];

                // check for previously validated certificate.
                X509Certificate2 certificate2 = null;

                if (m_validatedCertificates.TryGetValue(certificate.Thumbprint, out certificate2))
                {
                    if (Utils.IsEqual(certificate2.RawData, certificate.RawData))
                    {
                        return;
                    }
                }

                CertificateIdentifier trustedCertificate = GetTrustedCertificate(certificate);

                // get the issuers (checks the revocation lists if using directory stores).
                List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
                bool isIssuerTrusted = GetIssuers(certificates, issuers);

                // setup policy chain
                X509ChainPolicy policy = new X509ChainPolicy();

                policy.RevocationFlag = X509RevocationFlag.EntireChain;
                policy.RevocationMode = X509RevocationMode.NoCheck;
                policy.VerificationFlags = X509VerificationFlags.NoFlag;

                foreach (CertificateIdentifier issuer in issuers)
                {
                    if ((issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != 0)
                    {
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
                    }

                    // we did the revocation check in the GetIssuers call. No need here.
                    policy.RevocationMode = X509RevocationMode.NoCheck;
                    policy.ExtraStore.Add(issuer.Certificate);
                }

                // build chain.
                X509Chain chain = new X509Chain();
                chain.ChainPolicy = policy;
                chain.Build(certificate);

                // check the chain results.
                CertificateIdentifier target = trustedCertificate;

                if (target == null)
                {
                    target = new CertificateIdentifier(certificate);
                }

                for (int ii = 0; ii < chain.ChainElements.Count; ii++)
                {
                    X509ChainElement element = chain.ChainElements[ii];

                    CertificateIdentifier issuer = null;

                    if (ii < issuers.Count)
                    {
                        issuer = issuers[ii];
                    }

                    // check for chain status errors.
                    foreach (X509ChainStatus status in element.ChainElementStatus)
                    {
                        ServiceResult result = CheckChainStatus(status, target, issuer, (ii != 0));

                        if (ServiceResult.IsBad(result))
                        {
                            // check untrusted certificates.
                            if (trustedCertificate == null)
                            {
                                throw new ServiceResultException(StatusCodes.BadSecurityChecksFailed);
                            }

                            throw new ServiceResultException(result);
                        }
                    }

                    if (issuer != null)
                    {
                        target = issuer;
                    }
                }

                bool issuedByCA = !Utils.CompareDistinguishedName(certificate.Subject, certificate.Issuer);

                // check if certificate issuer is trusted.
                if (issuedByCA && !isIssuerTrusted)
                {
                    if (m_applicationCertificate == null || !Utils.IsEqual(m_applicationCertificate.RawData, certificate.RawData))
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadCertificateUntrusted,
                            "Certificate issuer is not trusted.\r\nSubjectName: {0}\r\nIssuerName: {1}",
                            certificate.SubjectName.Name,
                            certificate.IssuerName.Name);
                    }
                }

                // check if certificate is trusted.
                if (trustedCertificate == null && !isIssuerTrusted)
                {
                    if (m_applicationCertificate == null || !Utils.IsEqual(m_applicationCertificate.RawData, certificate.RawData))
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadCertificateUntrusted,
                            "Certificate is not trusted.\r\nSubjectName: {0}\r\nIssuerName: {1}",
                            certificate.SubjectName.Name,
                            certificate.IssuerName.Name);
                    }
                }
            }
        }


        /// <summary>
        /// Throws an exception if validation fails.
        /// </summary>
        /// <param name="certificate">The certificate to be checked.</param>
        /// <exception cref="ServiceResultException">If certificate cannot be accepted</exception>
        [Obsolete("Class is obsolete")]
        protected virtual void InternalValidate(X509Certificate2 certificate)
        {
            lock (m_lock)
            {
                // check for previously validated certificate.
                X509Certificate2 certificate2 = null;

                if (m_validatedCertificates.TryGetValue(certificate.Thumbprint, out certificate2))
                {
                    if (Utils.IsEqual(certificate2.RawData, certificate.RawData))
                    {
                        return;
                    }
                }

                CertificateIdentifier trustedCertificate = GetTrustedCertificate(certificate);

                // get the issuers (checks the revocation lists if using directory stores).
                List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
                bool isIssuerTrusted = GetIssuers(certificate, issuers);

                // setup policy chain
                X509ChainPolicy policy = new X509ChainPolicy();

                policy.RevocationFlag = X509RevocationFlag.EntireChain;
                policy.RevocationMode = X509RevocationMode.NoCheck;
                policy.VerificationFlags = X509VerificationFlags.NoFlag;

                foreach (CertificateIdentifier issuer in issuers)
                {
                    if ((issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != 0)
                    {
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
                    }

                    // we did the revocation check in the GetIssuers call. No need here.
                    policy.RevocationMode = X509RevocationMode.NoCheck;
                    policy.ExtraStore.Add(issuer.Certificate);
                }

                // build chain.
                X509Chain chain = new X509Chain();
                chain.ChainPolicy = policy;
                chain.Build(certificate);

                // check the chain results.
                CertificateIdentifier target = trustedCertificate;

                if (target == null)
                {
                    target = new CertificateIdentifier(certificate);
                }

                for (int ii = 0; ii < chain.ChainElements.Count; ii++)
                {
                    X509ChainElement element = chain.ChainElements[ii];

                    CertificateIdentifier issuer = null;

                    if (ii < issuers.Count)
                    {
                        issuer = issuers[ii];
                    }

                    // check for chain status errors.
                    foreach (X509ChainStatus status in element.ChainElementStatus)
                    {
                        ServiceResult result = CheckChainStatus(status, target, issuer, (ii != 0));

                        if (ServiceResult.IsBad(result))
                        {
                            throw new ServiceResultException(result);
                        }
                    }

                    if (issuer != null)
                    {
                        target = issuer;
                    }
                }

                // check if certificate is trusted.
                if (trustedCertificate == null && !isIssuerTrusted)
                {
                    if (m_applicationCertificate == null || !Utils.IsEqual(m_applicationCertificate.RawData, certificate.RawData))
                    {
                        throw ServiceResultException.Create(
                            StatusCodes.BadCertificateUntrusted,
                            "Certificate is not trusted.\r\nSubjectName: {0}\r\nIssuerName: {1}",
                            certificate.SubjectName.Name,
                            certificate.IssuerName.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Throws an exception if validation fails.
        /// </summary>
        /// <param name="certificates">The certificates to be checked.</param>
        /// <exception cref="ServiceResultException">If certificate[0] cannot be accepted</exception>
        [Obsolete("Class is replaced by Opc.Ua.CertificateValidator.InternalValidate(X509Certificate2Collection certificates, ConfiguredEndpoint endpoint)")]
        protected virtual void InternalValidateWithChainSupportEnabled(X509Certificate2Collection certificates)
        {
            lock (m_lock)
            {
                X509Certificate2 certificate = certificates[0];

                // check for previously validated certificate.
                X509Certificate2 certificate2 = null;

                if (m_validatedCertificates.TryGetValue(certificate.Thumbprint, out certificate2))
                {
                    if (Utils.IsEqual(certificate2.RawData, certificate.RawData))
                    {
                        return;
                    }
                }

                CertificateIdentifier trustedCertificate = GetTrustedCertificate(certificate);

                // get the issuers (checks the revocation lists if using directory stores).
                List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
                bool isIssuerTrusted = GetIssuersWithChainSupportEnabled(certificates, issuers);
                // setup policy chain
                X509ChainPolicy policy = new X509ChainPolicy();

                policy.RevocationFlag = X509RevocationFlag.EntireChain;
                policy.RevocationMode = X509RevocationMode.NoCheck;
                policy.VerificationFlags = X509VerificationFlags.NoFlag;

                foreach (CertificateIdentifier issuer in issuers)
                {
                    if ((issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != 0)
                    {
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
                        policy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
                    }

                    // we did the revocation check in the GetIssuers call. No need here.
                    policy.RevocationMode = X509RevocationMode.NoCheck;
                    policy.ExtraStore.Add(issuer.Certificate);
                }

                // build chain.
                X509Chain chain = new X509Chain();
                chain.ChainPolicy = policy;
                chain.Build(certificate);

                // check the chain results.
                CertificateIdentifier target = trustedCertificate;

                if (target == null)
                {
                    target = new CertificateIdentifier(certificate);
                }

                for (int ii = 0; ii < chain.ChainElements.Count; ii++)
                {
                    X509ChainElement element = chain.ChainElements[ii];

                    CertificateIdentifier issuer = null;

                    if (ii < issuers.Count)
                    {
                        issuer = issuers[ii];
                    }

                    // check for chain status errors.
                    foreach (X509ChainStatus status in element.ChainElementStatus)
                    {
                        ServiceResult result = CheckChainStatus(status, target, issuer, (ii != 0));

                        if (ServiceResult.IsBad(result))
                        {
                            throw new ServiceResultException(result);
                        }
                    }

                    if (issuer != null)
                    {
                        target = issuer;
                    }
                }
            }
        }

        /// <summary>
        /// Throws an exception if validation fails.
        /// </summary>
        /// <param name="certificates">The certificates to be checked.</param>
        /// <param name="endpoint">The endpoint for domain validation.</param>
        /// <exception cref="ServiceResultException">If certificate[0] cannot be accepted</exception>
        protected virtual async Task InternalValidate(X509Certificate2Collection certificates, ConfiguredEndpoint endpoint)
        {
            X509Certificate2 certificate = certificates[0];

            // check for previously validated certificate.
            X509Certificate2 certificate2 = null;

            if (m_validatedCertificates.TryGetValue(certificate.Thumbprint, out certificate2))
            {
                if (Utils.IsEqual(certificate2.RawData, certificate.RawData))
                {
                    return;
                }
            }

            CertificateIdentifier trustedCertificate = GetTrustedCertificate(certificate);

            // get the issuers (checks the revocation lists if using directory stores).
            List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
            Dictionary<X509Certificate2, ServiceResultException> validationErrors = new Dictionary<X509Certificate2, ServiceResultException>();

            bool isIssuerTrusted = GetIssuersNoExceptionsOnGetIssuer(certificates, issuers, validationErrors);

            ServiceResult sresult = PopulateSresultWithValidationErrors(validationErrors);

            // setup policy chain
            X509ChainPolicy policy = new X509ChainPolicy() {
                RevocationFlag = X509RevocationFlag.EntireChain,
                RevocationMode = X509RevocationMode.NoCheck,
                VerificationFlags = X509VerificationFlags.NoFlag,
#if NET5_0_OR_GREATER
                DisableCertificateDownloads = true,
#endif
            };

            foreach (CertificateIdentifier issuer in issuers)
            {
                if ((issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != 0)
                {
                    policy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
                    policy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
                    policy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
                    policy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
                }

                // we did the revocation check in the GetIssuers call. No need here.
                policy.RevocationMode = X509RevocationMode.NoCheck;
                policy.UrlRetrievalTimeout = TimeSpan.FromMilliseconds(1);
                policy.ExtraStore.Add(issuer.Certificate);
            }

            // build chain.
            bool chainIncomplete = false;
            X509Chain chain = new X509Chain();
            {
                chain.ChainPolicy = policy;
                chain.Build(certificate);

                // check the chain results.
                CertificateIdentifier target = trustedCertificate;

                if (target == null)
                {
                    target = new CertificateIdentifier(certificate);
                }

                foreach (X509ChainStatus chainStatus in chain.ChainStatus)
                {
                    switch (chainStatus.Status)
                    {
                        // status codes that are handled in CheckChainStatus
                        case X509ChainStatusFlags.RevocationStatusUnknown:
                        case X509ChainStatusFlags.Revoked:
                        case X509ChainStatusFlags.NotValidForUsage:
                        case X509ChainStatusFlags.OfflineRevocation:
                        case X509ChainStatusFlags.InvalidBasicConstraints:
                        case X509ChainStatusFlags.NotTimeValid:
                        case X509ChainStatusFlags.NotTimeNested:
                        case X509ChainStatusFlags.NoError:
                            break;

                        // by design, the trust root is not in the default store
                        case X509ChainStatusFlags.UntrustedRoot:
                            break;

                        // mark incomplete, invalidate the issuer trust
                        case X509ChainStatusFlags.PartialChain:
                            chainIncomplete = true;
                            isIssuerTrusted = false;
                            break;

                        case X509ChainStatusFlags.NotSignatureValid:
                            var result = ServiceResult.Create(
                                StatusCodes.BadCertificateInvalid,
                                "Certificate validation failed. {0}: {1}",
                                chainStatus.Status,
                                chainStatus.StatusInformation);
                            sresult = new ServiceResult(result, sresult);
                            break;

                        // unexpected error status
                        default:
                            Utils.Trace(Utils.TraceMasks.Error, "Unexpected status { 0} processing certificate chain.", chainStatus.Status);
                            goto case X509ChainStatusFlags.NotSignatureValid;
                    }
                }

                if (issuers.Count + 1 != chain.ChainElements.Count)
                {
                    // invalidate, unexpected result from X509Chain elements
                    chainIncomplete = true;
                    isIssuerTrusted = false;
                }

                for (int ii = 0; ii < chain.ChainElements.Count; ii++)
                {
                    X509ChainElement element = chain.ChainElements[ii];

                    CertificateIdentifier issuer = null;

                    if (ii < issuers.Count)
                    {
                        issuer = issuers[ii];
                    }

                    // validate the issuer chain matches the chain elements
                    if (ii + 1 < chain.ChainElements.Count)
                    {
                        var issuerCert = chain.ChainElements[ii + 1].Certificate;
                        if (issuer == null ||
                            !Utils.IsEqual(issuerCert.RawData, issuer.RawData))
                        {
                            // the chain used for cert validation differs from the issuers provided
                            Utils.LogCertificate(Utils.TraceMasks.Security, "An unexpected certificate was used in the certificate chain.", issuerCert);
                            chainIncomplete = true;
                            isIssuerTrusted = false;
                            break;
                        }
                    }

                    // check for chain status errors.
                    if (element.ChainElementStatus.Length > 0)
                    {
                        foreach (X509ChainStatus status in element.ChainElementStatus)
                        {
                            ServiceResult result = CheckChainStatus(status, target, issuer, (ii != 0));
                            if (ServiceResult.IsBad(result))
                            {
                                sresult = new ServiceResult(result, sresult);
                            }
                        }
                    }

                    if (issuer != null)
                    {
                        target = issuer;
                    }
                }
            }

            // check whether the chain is complete (if there is a chain)
            bool issuedByCA = !X509Utils.IsSelfSigned(certificate);
            if (issuers.Count > 0)
            {
                var rootCertificate = issuers[issuers.Count - 1].Certificate;
                if (!X509Utils.IsSelfSigned(rootCertificate))
                {
                    chainIncomplete = true;
                }
            }
            else
            {
                if (issuedByCA)
                {
                    // no issuer found at all
                    chainIncomplete = true;
                }
            }

            // check if certificate issuer is trusted.
            if (issuedByCA && !isIssuerTrusted && trustedCertificate == null)
            {
                var message = "Certificate Issuer is not trusted.";
                sresult = new ServiceResult(StatusCodes.BadCertificateUntrusted,
                    null, null, message, null, sresult);
            }

            // check if certificate is trusted.
            if (trustedCertificate == null && !isIssuerTrusted)
            {
                if (m_applicationCertificate == null || !Utils.IsEqual(m_applicationCertificate.RawData, certificate.RawData))
                {
                    var message = "Certificate is not trusted.";
                    sresult = new ServiceResult(StatusCodes.BadCertificateUntrusted,
                    null, null, message, null, sresult);
                }
            }

            if (endpoint != null && !FindDomain(certificate, endpoint))
            {
                string message = Utils.Format(
                    "The domain '{0}' is not listed in the server certificate.",
                    endpoint.EndpointUrl.DnsSafeHost);
                sresult = new ServiceResult(StatusCodes.BadCertificateHostNameInvalid,
                    null, null, message, null, sresult
                    );
            }

            // check if certificate is valid for use as app/sw or user cert
            X509KeyUsageFlags certificateKeyUsage = X509Utils.GetKeyUsage(certificate);

            if ((certificateKeyUsage & X509KeyUsageFlags.DataEncipherment) == 0)
            {
                sresult = new ServiceResult(StatusCodes.BadCertificateUseNotAllowed,
                    null, null, "Usage of certificate is not allowed.", null, sresult);
            }

            // check if minimum requirements are met
            if (m_rejectSHA1SignedCertificates && IsSHA1SignatureAlgorithm(certificate.SignatureAlgorithm))
            {
                sresult = new ServiceResult(StatusCodes.BadCertificateInvalid,
                    null, null, "SHA1 signed certificates are not trusted.", null, sresult);
            }

            int keySize = X509Utils.GetRSAPublicKeySize(certificate);
            if (keySize < m_minimumCertificateKeySize)
            {
                sresult = new ServiceResult(StatusCodes.BadCertificateInvalid,
                    null, null,
                    $"Certificate doesn't meet minimum key length requirement. ({keySize}<{m_minimumCertificateKeySize})",
                    null, sresult);
            }

            if (issuedByCA && chainIncomplete)
            {
                var message = "Certificate chain validation incomplete.";
                sresult = new ServiceResult(StatusCodes.BadCertificateChainIncomplete,
                    null, null, message, null, sresult);
            }

            if (sresult != null)
            {
                throw new ServiceResultException(sresult);
            }
        }

        private ServiceResult PopulateSresultWithValidationErrors(Dictionary<X509Certificate2, ServiceResultException> validationErrors)
        {
            Dictionary<X509Certificate2, ServiceResultException> p1List = new Dictionary<X509Certificate2, ServiceResultException>();
            Dictionary<X509Certificate2, ServiceResultException> p2List = new Dictionary<X509Certificate2, ServiceResultException>();
            Dictionary<X509Certificate2, ServiceResultException> p3List = new Dictionary<X509Certificate2, ServiceResultException>();

            ServiceResult sresult = null;

            foreach (KeyValuePair<X509Certificate2, ServiceResultException> kvp in validationErrors)
            {
                if (kvp.Value != null)
                {
                    if (kvp.Value.StatusCode == StatusCodes.BadCertificateRevoked)
                    {
                        p1List[kvp.Key] = kvp.Value;
                    }
                    else if (kvp.Value.StatusCode == StatusCodes.BadCertificateIssuerRevoked)
                    {
                        p2List[kvp.Key] = kvp.Value;
                    }
                    else if (kvp.Value.StatusCode == StatusCodes.BadCertificateRevocationUnknown)
                    {
                        p3List[kvp.Key] = kvp.Value;
                    }
                    else if (kvp.Value.StatusCode == StatusCodes.BadCertificateIssuerRevocationUnknown)
                    {
                        //p4List[kvp.Key] = kvp.Value;
                        var message = CertificateMessage("Certificate issuer revocation list not found.", kvp.Key);
                        sresult = new ServiceResult(StatusCodes.BadCertificateIssuerRevocationUnknown,
                            null, null, message, null, sresult);
                    }
                    else
                    {
                        if (StatusCode.IsBad(kvp.Value.StatusCode))
                        {
                            var message = CertificateMessage("Unknown error while trying to determine the revocation status.", kvp.Key);
                            sresult = new ServiceResult(kvp.Value.StatusCode,
                                null, null, message, null, sresult);
                        }
                    }
                }
            }

            if (p3List.Count > 0)
            {
                foreach (KeyValuePair<X509Certificate2, ServiceResultException> kvp in p3List)
                {
                    var message = CertificateMessage("Certificate revocation list not found.", kvp.Key);
                    sresult = new ServiceResult(StatusCodes.BadCertificateRevocationUnknown,
                        null, null, message, null, sresult);
                }
            }
            if (p2List.Count > 0)
            {
                foreach (KeyValuePair<X509Certificate2, ServiceResultException> kvp in p2List)
                {
                    var message = CertificateMessage("Certificate issuer is revoked.", kvp.Key);
                    sresult = new ServiceResult(StatusCodes.BadCertificateIssuerRevoked,
                        null, null, message, null, sresult);
                }
            }
            if (p1List.Count > 0)
            {
                foreach (KeyValuePair<X509Certificate2, ServiceResultException> kvp in p1List)
                {
                    var message = CertificateMessage("Certificate is revoked.", kvp.Key);
                    sresult = new ServiceResult(StatusCodes.BadCertificateRevoked,
                        null, null, message, null, sresult);
                }
            }

            return sresult;
        }

        /// <summary>
        /// Returns an object that can be used with a UA channel.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public X509CertificateValidator GetChannelValidator()
        {
            return new WcfValidatorWrapper(this);
        }

        /// <summary>
        /// Validate domains in a server certificate against endpoint used to connect a session.
        /// </summary>
        /// <param name="serverCertificate">The server certificate returned by a session connect.</param>
        /// <param name="endpoint">The endpoint used to connect to a server.</param>
        public void ValidateDomains(X509Certificate2 serverCertificate, ConfiguredEndpoint endpoint)
        {
            X509Certificate2 certificate2;
            if (m_validatedCertificates.TryGetValue(serverCertificate.Thumbprint, out certificate2))
            {
                if (Utils.IsEqual(certificate2.RawData, serverCertificate.RawData))
                {
                    return;
                }
            }

            bool domainFound = FindDomain(serverCertificate, endpoint);

            if (!domainFound)
            {
                bool accept = false;
                string message = Utils.Format(
                    "The domain '{0}' is not listed in the server certificate.",
                    endpoint.EndpointUrl.DnsSafeHost);
                var serviceResult = new ServiceResultException(StatusCodes.BadCertificateHostNameInvalid, message);
                if (m_CertificateValidation != null)
                {
                    var args = new CertificateValidationEventArgs(new ServiceResult(serviceResult), serverCertificate);
                    m_CertificateValidation(this, args);
                    accept = args.Accept || args.AcceptAll;
                }
                // throw if rejected.
                if (!accept)
                {
                    // write the invalid certificate to rejected store if specified.
                    Utils.LogCertificate(Utils.TraceMasks.Error, "Certificate rejected. Reason={1}.",
                        serverCertificate, serviceResult != null ? serviceResult.ToString() : "Unknown Error");
                    SaveCertificate(serverCertificate);

                    throw serviceResult;
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns an error if the chain status elements indicate an error.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private static ServiceResult CheckChainStatus(X509ChainStatus status, CertificateIdentifier id, CertificateIdentifier issuer, bool isIssuer)
        {
            switch (status.Status)
            {
                case X509ChainStatusFlags.NotValidForUsage:
                {
                    return ServiceResult.Create(
                        (isIssuer) ? StatusCodes.BadCertificateUseNotAllowed : StatusCodes.BadCertificateIssuerUseNotAllowed,
                        "Certificate may not be used as an application instance certificate. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.NoError:
                case X509ChainStatusFlags.OfflineRevocation:
                case X509ChainStatusFlags.InvalidBasicConstraints:
                {
                    break;
                }

                case X509ChainStatusFlags.PartialChain:
                    goto case X509ChainStatusFlags.UntrustedRoot;
                case X509ChainStatusFlags.UntrustedRoot:
                {
                    // self signed cert signature validation 
                    // .NET Core ChainStatus returns NotSignatureValid only on Windows, 
                    // so we have to do the extra cert signature check on all platforms
                    if (issuer == null && id.Certificate != null &&
                        X509Utils.IsSelfSigned(id.Certificate))
                    {
                        if (!IsSignatureValid(id.Certificate))
                        {
                            goto case X509ChainStatusFlags.NotSignatureValid;
                        }
                        break;
                    }

                    return ServiceResult.Create(
                        StatusCodes.BadCertificateChainIncomplete,
                        "Certificate chain validation failed. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.RevocationStatusUnknown:
                {
                    if (issuer != null)
                    {
                        if ((issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != 0)
                        {
                            Utils.Trace(Utils.TraceMasks.Information, "Error suppressed: {0}: {1}",
                                status.Status,
                                status.StatusInformation);
                            break;
                        }
                    }

                    // check for meaning less errors for self-signed certificates.
                    if (id.Certificate != null && X509Utils.IsSelfSigned(id.Certificate))
                    {
                        break;
                    }

                    return ServiceResult.Create(
                        (isIssuer) ? StatusCodes.BadCertificateIssuerRevocationUnknown : StatusCodes.BadCertificateRevocationUnknown,
                        "Certificate revocation status cannot be verified. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.Revoked:
                {
                    return ServiceResult.Create(
                        (isIssuer) ? StatusCodes.BadCertificateIssuerRevoked : StatusCodes.BadCertificateRevoked,
                        "Certificate has been revoked. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.NotTimeNested:
                {
                    if (id != null && ((id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != 0))
                    {
                        Utils.Trace(Utils.TraceMasks.Information,
                            "Error suppressed: {0}: {1}",
                            status.Status, status.StatusInformation);
                        break;
                    }

                    return ServiceResult.Create(
                        StatusCodes.BadCertificateIssuerTimeInvalid,
                        "Issuer Certificate has expired or is not yet valid. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.NotTimeValid:
                {
                    if (id != null && ((id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != 0))
                    {
                        Utils.Trace(Utils.TraceMasks.Information,
                            "Error suppressed: {0}: {1}",
                            status.Status, status.StatusInformation);
                        break;
                    }

                    return ServiceResult.Create(
                        (isIssuer) ? StatusCodes.BadCertificateIssuerTimeInvalid : StatusCodes.BadCertificateTimeInvalid,
                        "Certificate has expired or is not yet valid. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }

                case X509ChainStatusFlags.NotSignatureValid:
                default:
                {
                    return ServiceResult.Create(
                        StatusCodes.BadCertificateInvalid,
                        "Certificate validation failed. {0}: {1}",
                        status.Status,
                        status.StatusInformation);
                }
            }

            return null;
        }
        /// <summary>
        /// Returns if a certificate is signed with a SHA1 algorithm.
        /// </summary>
        private static bool IsSHA1SignatureAlgorithm(Oid oid)
        {
            return oid.Value == "1.3.14.3.2.29" ||     // sha1RSA
                oid.Value == "1.2.840.10040.4.3" ||    // sha1DSA
                oid.Value == "1.2.840.10045.4.1" ||    // sha1ECDSA
                oid.Value == "1.2.840.113549.1.1.5" || // sha1RSA
                oid.Value == "1.3.14.3.2.13" ||        // sha1DSA
                oid.Value == "1.3.14.3.2.27";          // dsaSHA1
        }

        /// <summary>
        /// Returns a certificate information message.
        /// </summary>
        private string CertificateMessage(string error, X509Certificate2 certificate)
        {
            var message = new StringBuilder()
                .AppendLine(error)
                .AppendFormat("Subject: {0}", certificate.Subject)
                .AppendLine();
            if (!string.Equals(certificate.Subject, certificate.Issuer, StringComparison.Ordinal))
            {
                message.AppendFormat("Issuer: {0}", certificate.Issuer)
                .AppendLine();
            }
            return message.ToString();
        }

        /// <summary>
        /// Returns if a self signed certificate is properly signed.
        /// </summary>
        private static bool IsSignatureValid(X509Certificate2 cert)
        {
            return X509Utils.VerifySelfSigned(cert);
        }

        /// <summary>
        /// The list of suppressible status codes.
        /// </summary>
        private static readonly ReadOnlyList<StatusCode> m_suppressibleStatusCodes =
            new ReadOnlyList<StatusCode>(
                new List<StatusCode>
                {
                    StatusCodes.BadCertificateHostNameInvalid,
                    StatusCodes.BadCertificateIssuerRevocationUnknown,
                    StatusCodes.BadCertificateChainIncomplete,
                    StatusCodes.BadCertificateIssuerTimeInvalid,
                    StatusCodes.BadCertificateIssuerUseNotAllowed,
                    StatusCodes.BadCertificateRevocationUnknown,
                    StatusCodes.BadCertificateTimeInvalid,
                    //StatusCodes.BadCertificatePolicyCheckFailed,
                    StatusCodes.BadCertificateUseNotAllowed,
                    StatusCodes.BadCertificateUntrusted
                });

        /// <summary>
        /// Find the domain in a certificate in the
        /// endpoint that was used to connect a session.
        /// </summary>
        /// <param name="serverCertificate">The server certificate which is tested for domain names.</param>
        /// <param name="endpoint">The endpoint which was used to connect.</param>
        /// <returns>True if domain was found.</returns>
        private bool FindDomain(X509Certificate2 serverCertificate, ConfiguredEndpoint endpoint)
        {
            bool domainFound = false;

            // check the certificate domains.
            IList<string> domains = X509Utils.GetDomainsFromCertficate(serverCertificate);

            if (domains != null && domains.Count > 0)
            {
                string hostname;
                string dnsHostName = hostname = endpoint.EndpointUrl.DnsSafeHost;
                bool isLocalHost = false;
                if (endpoint.EndpointUrl.HostNameType == UriHostNameType.Dns)
                {
                    if (String.Equals(dnsHostName, "localhost", StringComparison.InvariantCultureIgnoreCase))
                    {
                        isLocalHost = true;
                    }
                    else
                    {   // strip domain names from hostname
                        hostname = dnsHostName.Split('.')[0];
                    }
                }
                else
                {   // dnsHostname is a IPv4 or IPv6 address
                    // normalize ip addresses, cert parser returns normalized addresses
                    hostname = Utils.NormalizedIPAddress(dnsHostName);
                    if (hostname == "127.0.0.1" || hostname == "::1")
                    {
                        isLocalHost = true;
                    }
                }

                if (isLocalHost)
                {
                    dnsHostName = Utils.GetFullQualifiedDomainName();
                    hostname = Utils.GetHostName();
                }

                for (int ii = 0; ii < domains.Count; ii++)
                {
                    if (String.Equals(hostname, domains[ii], StringComparison.OrdinalIgnoreCase) ||
                        String.Equals(dnsHostName, domains[ii], StringComparison.OrdinalIgnoreCase))
                    {
                        domainFound = true;
                        break;
                    }
                }
            }
            return domainFound;
        }
        #endregion

        #region Private Enum
        /// <summary>
        /// Flag to protect setting by application
        /// from a modification by a SecurityConfiguration.
        /// </summary>
        [Flags]
        private enum ProtectFlags
        {
            AutoAcceptUntrustedCertificates = 1,
            RejectSHA1SignedCertificates = 2,
            RejectUnknownRevocationStatus = 4,
            MinimumCertificateKeySize = 8
        };
        #endregion

        #region WcfValidatorWrapper Class
        /// <summary>
        /// Wraps a WCF validator so the validator can be used in WCF bindings.
        /// </summary>
        internal class WcfValidatorWrapper : X509CertificateValidator
        {
            public WcfValidatorWrapper(CertificateValidator validator)
            {
                m_validator = validator;
            }

            public override void Validate(X509Certificate2 certificate)
            {
                try
                {
                    m_validator.Validate(certificate);
                }
                catch (Exception e)
                {
                    throw new System.IdentityModel.Tokens.SecurityTokenValidationException("Could not validate certificate.", e);
                }
            }

            internal void Validate(X509Certificate2Collection certificates)
            {
                try
                {
                    m_validator.Validate(certificates);
                }
                catch (Exception e)
                {
                    throw new System.IdentityModel.Tokens.SecurityTokenValidationException("Could not validate certificate.", e);
                }
            }

            private CertificateValidator m_validator;
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private object m_callbackLock = new object();
        private Dictionary<string, X509Certificate2> m_validatedCertificates;
        private CertificateStoreIdentifier m_trustedCertificateStore;
        private CertificateIdentifierCollection m_trustedCertificateList;
        private CertificateStoreIdentifier m_issuerCertificateStore;
        private CertificateIdentifierCollection m_issuerCertificateList;
        private CertificateStoreIdentifier m_rejectedCertificateStore;
        private event CertificateValidationEventHandler m_CertificateValidation;
        private event CertificateUpdateEventHandler m_CertificateUpdate;
        private X509Certificate2 m_applicationCertificate;
        private ProtectFlags m_protectFlags;
        private bool m_autoAcceptUntrustedCertificates;
        private bool m_rejectSHA1SignedCertificates;
        private bool m_rejectUnknownRevocationStatus;
        private ushort m_minimumCertificateKeySize;
        #endregion
    }

    #region CertificateValidationEventArgs Class
    /// <summary>
    /// The event arguments provided when a certificate validation error occurs.
    /// </summary>
    public class CertificateValidationEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal CertificateValidationEventArgs(ServiceResult error, X509Certificate2 certificate)
        {
            m_error = error;
            m_certificate = certificate;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The error that occurred.
        /// </summary>
        public ServiceResult Error => m_error;

        /// <summary>
        /// The certificate.
        /// </summary>
        public X509Certificate2 Certificate => m_certificate;

        /// <summary>
        /// Whether the current error reported for
        /// a certificate should be accepted and suppressed.
        /// </summary>
        public bool Accept
        {
            get => m_accept;
            set => m_accept = value;
        }

        /// <summary>
        /// Whether all the errors reported for
        /// a certificate should be accepted and suppressed.
        /// </summary>
        public bool AcceptAll
        {
            get => m_acceptAll;
            set => m_acceptAll = value;
        }
        #endregion

        #region Private Fields
        private ServiceResult m_error;
        private X509Certificate2 m_certificate;
        private bool m_accept;
        private bool m_acceptAll;
        #endregion
    }

    /// <summary>
    /// Used to handled certificate validation errors.
    /// </summary>
    public delegate void CertificateValidationEventHandler(CertificateValidator sender, CertificateValidationEventArgs e);
    #endregion

    #region CertificateUpdateEventArgs Class
    /// <summary>
    /// The event arguments provided when a certificate validation error occurs.
    /// </summary>
    public class CertificateUpdateEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        internal CertificateUpdateEventArgs(
            SecurityConfiguration configuration,
            ICertificateValidator validator)
        {
            SecurityConfiguration = configuration;
            CertificateValidator2 = validator;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The new security configuration.
        /// </summary>
        public SecurityConfiguration SecurityConfiguration { get; private set; }
        /// <summary>
        /// The new certificate validator.
        /// </summary>
        public ICertificateValidator CertificateValidator2 { get; private set; }

        #endregion
    }

    /// <summary>
    /// Used to handle certificate update events.
    /// </summary>
    public delegate void CertificateUpdateEventHandler(CertificateValidator sender, CertificateUpdateEventArgs e);

    #endregion

}
