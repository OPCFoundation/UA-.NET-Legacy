/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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

#include "StdAfx.h"
#include "MainForm.h"
#include "ComDaClientUtils.h"
#include "ComDaDataCallback.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace Quickstarts::ComDataAccessClient;
using namespace Opc::Ua::Configuration;

// 899A3076-F94E-4695-9DF8-0ED25B02BDBA
static const GUID CATID_PseudoComServers = {0x899A3076, 0xF94E, 0x4695, { 0x9D, 0xF8, 0x0E, 0xD2, 0x5B, 0x02, 0xBD, 0xBA } }; 

//==============================================================================
// ComDaClientUtils Functions

// CreateInstance
IUnknown* ComDaClientUtils::CreateInstance(REFCLSID tClsid, REFIID tInterface)
{
	// initialize server security info.
	COSERVERINFO cInfo; 
	memset(&cInfo, 0, sizeof(cInfo));

    cInfo.pwszName    = NULL;
    cInfo.pAuthInfo   = NULL;
    cInfo.dwReserved1 = NULL;
    cInfo.dwReserved2 = NULL;

	// setup requested interfaces.
    MULTI_QI cResults;
	memset(&cResults, 0, sizeof(cResults));

    cResults.pIID = &tInterface;
    cResults.pItf = NULL;
    cResults.hr   = S_OK;

    // call create instance.
    HRESULT hResult = CoCreateInstanceEx(
        tClsid,
        NULL,
        CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER,
        &cInfo,
        1,
        &cResults);

    if (FAILED(hResult))
    {
		throw gcnew COMException("Could not create COM server.", hResult);
	}

    // check that interface is supported.
    if (FAILED(cResults.hr))
    {
		cResults.pItf->Release();
		throw gcnew COMException("Server does not support the requested interface.", cResults.hr);
    }

	return cResults.pItf;
}

// EnumerateServers
List<String^>^ ComDaClientUtils::EnumerateComServerOnLocalhost()
{
	ICatInformation* ipManager = NULL;
	IEnumGUID* ipEnum = NULL;
	LPWSTR pszProgId = NULL;
	List<String^>^ progIds = gcnew List<String^>();

	try
	{
		// need to access the category manager.
		ipManager = (ICatInformation*)ComDaClientUtils::CreateInstance(CLSID_StdComponentCategoriesMgr, IID_ICatInformation);

		// all COM servers which are proxies for a UA server are in the CATID_PseudoComServers category.
		ipManager->EnumClassesOfCategories(
			1,
			&CATID_PseudoComServers,
			0,
			NULL,
			&ipEnum);

		ULONG uFetched = 0;

		while (true)
		{
			CLSID tClsid;
			HRESULT hResult = ipEnum->Next(1, &tClsid, &uFetched);

			if (FAILED(hResult))
			{
				break;
			}

			if (uFetched == 0)
			{
				break;
			}

			// convert the CLSIDs to a ProgID for display.
			hResult = ProgIDFromCLSID(tClsid, (LPOLESTR*)&pszProgId);

			if (SUCCEEDED(hResult))
			{
				progIds->Add(Marshal::PtrToStringUni((IntPtr)pszProgId));
				CoTaskMemFree(pszProgId);
				pszProgId = NULL;
			}
		}

		return progIds;
	}
	finally
	{
		if (pszProgId != NULL)
		{
			CoTaskMemFree(pszProgId);
		}

		if (ipEnum != NULL) ipEnum->Release();
		if (ipManager != NULL) ipManager->Release();
	}
}


// Returns the UA servers on the specified host.
List<ApplicationDescription^>^ ComDaClientUtils::EnumerateUaServersOnHost(String^ hostname)
{
	DiscoveryClient^ client = nullptr;

	try
	{
		// construct the url.
		if (String::IsNullOrEmpty(hostname))
		{
			hostname = "localhost";
		}

		String^ discoveryUrl = String::Format("opc.tcp://{0}:4840", hostname);

		// connect to the discovery server and fetch the servers.
		client = DiscoveryClient::Create(gcnew Uri(discoveryUrl));

		ApplicationDescriptionCollection^ servers = client->FindServers(nullptr);

		// close the channel.
		client->Close();
		client = nullptr;

		return servers;
	}
	finally
	{
		if (client != nullptr)
		{
			client->Close();
		}
	}
}

// Creates a COM server for the specified url and returns the ProgID.
String^ ComDaClientUtils::CreateComServerForApplication(String^ discoveryUrl, bool useSecurity)
{
	DiscoveryClient^ client = nullptr;

	try
	{
		// connect to the discovery server and fetch the servers.
		Uri^ uri = gcnew Uri(discoveryUrl);
		client = DiscoveryClient::Create(uri);

		EndpointDescriptionCollection^ endpoints = client->GetEndpoints(nullptr);

		// close the channel.
		client->Close();
		client = nullptr;

		// select the best endpoint.
		EndpointDescription^ endpoint = nullptr;

		for (int ii = 0; ii < endpoints->Count; ii++)
		{
			if (!endpoints[ii]->EndpointUrl->StartsWith(uri->Scheme))
			{
				continue;
			}

			if (!useSecurity && endpoints[ii]->SecurityMode == MessageSecurityMode::None)
			{
				endpoint = endpoints[ii];
				break;
			}

			if (endpoint == nullptr)
			{
				endpoint = endpoints[ii];
				continue;
			}

			if (endpoint->SecurityLevel < endpoints[ii]->SecurityLevel)
			{
				endpoint = endpoints[ii];
			}
		}

        // need to fix the domains if the server is behind a firewall and the server is returning the wrong URLs.
        // this should only be necessary if the server is not configured properly.
        UriBuilder^ endpointUrl = gcnew UriBuilder(endpoint->EndpointUrl);

        if (!Utils::AreDomainsEqual(endpointUrl->Uri, uri))
        {
            endpointUrl->Host = uri->DnsSafeHost;
            endpoint->EndpointUrl = endpointUrl->ToString();

            // need to discard unuseable discovery urls.
            endpoint->Server->DiscoveryUrls->Clear();
            endpoint->Server->DiscoveryUrls->Add(uri->ToString());
        }

		// create the COM server configuration.
		ConfiguredEndpoint^ configuredEndpoint = gcnew ConfiguredEndpoint(nullptr, endpoint, nullptr);

		// Assign a COM identity.
		EndpointComIdentity^ identity = gcnew EndpointComIdentity();

		identity->Specification = ComSpecification::DA;
		identity->ProgId = PseudoComServer::CreateProgIdFromUrl(ComSpecification::DA, endpoint->EndpointUrl);
		identity->Clsid = Guid::NewGuid();

		configuredEndpoint->ComIdentity = identity;

		// save it - requires permission to access the registry.
		PseudoComServer::Save(configuredEndpoint);

		// return the prog id.
		return configuredEndpoint->ComIdentity->ProgId;
	}
	finally
	{
		if (client != nullptr)
		{
			client->Close();
		}
	}
}
