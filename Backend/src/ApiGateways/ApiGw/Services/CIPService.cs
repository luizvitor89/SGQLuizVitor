using ApiGw.Authentication.Models;
using ApiGw.Config;
using ApiGw.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiGw.Services
{
    public class CIPService : ICIPService
    {
        private readonly HttpClient _apiClient;
        private readonly UrlsConfig _urls;

        public CIPService(HttpClient httpClient, IOptions<UrlsConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }

        public async Task<EmissorViewModel> EmissorLoginAsync(AuthModel authModel)
        {
            var url = _urls.CIP + UrlsConfig.CIPOperations.EmissorLogin();
            var response = await _apiClient.PostAsJsonAsync(url, authModel);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EmissorViewModel>(data);
        }
    }
}
