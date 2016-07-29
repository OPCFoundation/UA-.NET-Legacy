/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua;

namespace DsatsDemo
{
    public partial class LockConditionState
    {
        #region Public Methods
        /// <summary>
        /// Requests the lock.
        /// </summary>
        public void RequestLock(ISystemContext context)
        {
            TranslationInfo state = new TranslationInfo(
                "LockConditionStateWaitingForApproval",
                "en-US",
                BrowseNames.WaitingForApproval);

            if (this.LockState.CurrentState != null)
            {
                this.LockState.CurrentState.Value = new LocalizedText(state);
                this.LockState.CurrentState.Id.Value = ExpandedNodeId.ToNodeId(ObjectIds.LockStateMachineType_WaitingForApproval, context.NamespaceUris);
            }

            this.LockStateAsString.Value = state.Text;

            UpdateEffectiveState(context);
        }

        /// <summary>
        /// Grants the lock.
        /// </summary>
        public void SetLock(ISystemContext context)
        {
            TranslationInfo state = new TranslationInfo(
                "LockConditionStateLocked",
                "en-US",
                BrowseNames.Locked);

            if (this.LockState.CurrentState != null)
            {
                this.LockState.CurrentState.Value = new LocalizedText(state);
                this.LockState.CurrentState.Id.Value = ExpandedNodeId.ToNodeId(ObjectIds.LockStateMachineType_Locked, context.NamespaceUris);
            }

            this.LockStateAsString.Value = state.Text;

            UpdateEffectiveState(context);
        }

        /// <summary>
        /// Releases the lock.
        /// </summary>
        public void Unlock(ISystemContext context)
        {
            TranslationInfo state = new TranslationInfo(
                "LockConditionStateUnlocked",
                "en-US",
                BrowseNames.Unlocked);

            if (this.LockState.CurrentState != null)
            {
                this.LockState.CurrentState.Value = new LocalizedText(state);
                this.LockState.CurrentState.Id.Value = ExpandedNodeId.ToNodeId(ObjectIds.LockStateMachineType_Unlocked, context.NamespaceUris);
            }

            this.LockStateAsString.Value = state.Text;

            UpdateEffectiveState(context);
        }

        /// <summary>
        /// Specifies the thumbprint of a certificate that has access to the lock.
        /// </summary>
        public void SetPermission(string thumbprint)
        {
            if (m_thumbprints == null)
            {
                m_thumbprints = new List<string>();
            }

            m_thumbprints.Add(thumbprint);
        }

        /// <summary>
        /// Checks if the certificate has access to the lock.
        /// </summary>
        public bool HasPermission(X509Certificate2 certificate)
        {
            if (m_thumbprints != null)
            {
                return m_thumbprints.Contains(certificate.Thumbprint);
            }

            return false;
        }
        #endregion

        #region Public Methods
        private List<string> m_thumbprints;
        #endregion
    }
}
