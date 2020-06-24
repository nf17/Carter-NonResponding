using Carter;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarterApi.Api
{
    public class DefaultJsonResponseNegotiator : IResponseNegotiator
    {
        private readonly JsonSerializerSettings jsonSettings;

        public DefaultJsonResponseNegotiator()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            this.jsonSettings = new JsonSerializerSettings { ContractResolver = contractResolver, NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public bool CanHandle(Microsoft.Net.Http.Headers.MediaTypeHeaderValue accept)
        {
            return accept.MediaType.ToString().IndexOf("json", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public Task Handle(HttpRequest req, HttpResponse res, object model, CancellationToken cancellationToken)
        {
            res.ContentType = "application/json; charset=utf-8";
            return res.WriteAsync(JsonConvert.SerializeObject(model, this.jsonSettings), cancellationToken);
        }
    }

}
