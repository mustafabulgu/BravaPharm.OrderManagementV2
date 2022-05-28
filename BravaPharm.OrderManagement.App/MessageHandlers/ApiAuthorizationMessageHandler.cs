using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;

namespace BravaPharm.OrderManagement.App.MessageHandlers
{
    public class ApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public ApiAuthorizationMessageHandler(
            IAccessTokenProvider provider, NavigationManager navigation, IConfiguration configuration)
            : base(provider, navigation)
        {
            var apiUrl = configuration["ApiUrl"];
            var scopeIdentifier = configuration["AzureAdReadWriteScope"];
            ConfigureHandler(
                  authorizedUrls: new[] { apiUrl },
                  scopes: new[] { scopeIdentifier });
        }
    }
}
