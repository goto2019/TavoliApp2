using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TavoliApp.WSTavoliClient
{
    public class WSTavoliClient
    {
        private readonly HttpClient _httpClient;

        public WSTavoliClient(string ip)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://{ip}:50000")
            };
        }

        public async Task<List<TavoliOccupati>> GetTavoliOccupatiSummaryAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Tavoli/GetTavoliOccupatiSummary");

                if (!response.IsSuccessStatusCode)
                    return new List<TavoliOccupati>();

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<TavoliOccupati>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<TavoliOccupati>();
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
                return new List<TavoliOccupati>();
            }
        }
    }
}
