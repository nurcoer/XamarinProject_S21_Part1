using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LCT.Client.Utils
{
    class AuthHeaderHandler : DelegatingHandler
    {
        public AuthHeaderHandler()
        {
            InnerHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
