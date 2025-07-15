using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TavoliApp.Models;

namespace TavoliApp.ApiClients
{
    public class WSTavoliClient
    {
        private readonly HttpClient _httpClient;

        public WSTavoliClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TavoloDto>> GetTavoloDtoSummaryAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Tavoli/GetTavoliOccupatiSummary");

                if (!response.IsSuccessStatusCode)
                    return new List<TavoloDto>();

                var json = await response.Content.ReadAsStringAsync();

                var risultato = JsonSerializer.Deserialize<ElencoTavoliResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return risultato?.Tavoli ?? new List<TavoloDto>();
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
                return new List<TavoloDto>();
            }
        }
    }
}
