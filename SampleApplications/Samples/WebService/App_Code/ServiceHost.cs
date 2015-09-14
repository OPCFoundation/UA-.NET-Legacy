/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Runtime.Serialization;

using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Bindings;
using Opc.Ua.Server;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// A factory used by the WCF framework to create new instances of UA servers.
    /// </summary>
	public class ServiceHostFactory : ServiceHostFactoryBase
	{
        #region Overridden Members
        /// <summary>
        /// Creates a new instance of a service host.
        /// </summary>
	    public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
	    {
            // load the configuration.
            SampleConfiguration configuration = SampleConfiguration.Load("Opc.Ua.Server", ApplicationType.Server);

            // create the object that implements the server.
            SampleServer server = new SampleServer();

            // return the default host.
            return server.Start(configuration, baseAddresses);
        }
        #endregion
    }
}
