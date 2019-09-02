using System;
using System.Net.Http;
using Flurl.Http.Configuration;
using SecureHttpClient;

namespace MindTheSecDemo.Security
{
    public class SecureHttpClientFactory : DefaultHttpClientFactory
    {
        private readonly SecureHttpClientHandler _secureHttpClientHandler;

        public SecureHttpClientFactory(SecureHttpClientHandler secureHttpClientHandler)
        {
            _secureHttpClientHandler = secureHttpClientHandler;
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            var apiHost = new Uri("https://pokeapi.co/").Host;

            _secureHttpClientHandler.AddCertificatePinner(apiHost,
                new string[] { "sha256/ERDh/10Q0FN9dIlnVgCqwBkkTHgysozHT5AzU+RtMgo=" });
            return _secureHttpClientHandler;
        }
    }
}
