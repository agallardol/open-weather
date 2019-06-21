using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherMapApi
{
    public class AddAppIdMessageHandler : DelegatingHandler
    {
        readonly string appId;
        public AddAppIdMessageHandler(string appId)
        {
            this.appId = appId;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri($"{request.RequestUri.AbsoluteUri}&appid={this.appId}");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
