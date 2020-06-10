﻿using DoorToGate.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoorToGate.Services
{
    public class TSAClient : ITSAClient
    {
        private readonly HttpClient _client;

        public TSAClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<TSAWaitTime> GetAirport(string airport)
        {
            try
            {
                var endpoint = $"{airport}/JSON/";
                var response = await _client.GetAsync(endpoint);
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TSAWaitTime>(json);

            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
