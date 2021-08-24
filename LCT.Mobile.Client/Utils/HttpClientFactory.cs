using System;
using System.Net.Http;

namespace LCT.Client.Utils
{
    public static class HttpClientFactory
    {
        public static HttpClient Create(string baseAddress) => new HttpClient(new AuthHeaderHandler())
        {
            BaseAddress = new Uri(baseAddress),
            //Timeout = TimeSpan.FromSeconds(5),
            
        };
        private static HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            return handler;
        }
       
        
    }
}