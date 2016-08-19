/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using System.Net.Http;

namespace SessionlessMethodCallClient
{
    public class DefaultHttpHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var requestDate = request.Headers.Date;
            // do something with the date ...

            // var response = await base.SendAsync(request, cancellationToken);

            HttpResponseMessage response = new HttpResponseMessage();
            FormUrlEncodedContent data = new FormUrlEncodedContent(new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("value", "value1") });
            response.Content = data;

            var responseDate = response.Headers.Date;
            // do something with the date ...

            return Task.FromResult(response);
        }
    }

    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MessageHandlers.Add(new DefaultHttpHandler());
            appBuilder.UseWebApi(config);
        }
    }
}
