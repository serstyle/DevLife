using DevLifeMvc.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DevLifeMvc.Services
{
    public class StoryService : IStoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        public bool GetStoriesError { get; private set; }
        public StoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<IStory>> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/stories");
            var client = _clientFactory.CreateClient("backend");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<IEnumerable<Story>>(responseStream);
                return res;
            }
            else
            {
                GetStoriesError = true;
                return Array.Empty<IStory>();
            }
        }
        public async Task<IStory> Get(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/stories/{id}");
            var client = _clientFactory.CreateClient("backend");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Story>(responseStream);
                return res;
            }
            else
            {
                GetStoriesError = true;
                return null;
            }
        }
        public async Task Edit(string id, Story storyIn)
        {
            var str = await this.Get(id);
            storyIn.vote = str.vote;
            var storyItemJson = new StringContent(
                JsonSerializer.Serialize(storyIn),
                Encoding.UTF8,
                "application/json");


            var client = _clientFactory.CreateClient("backend");

            using var response = await client.PutAsync($"api/stories/{id}", storyItemJson);
            response.EnsureSuccessStatusCode();

        }
        public async Task Create(Story storyIn)
        {
            var storyItemJson = new StringContent(
                JsonSerializer.Serialize(storyIn),
                Encoding.UTF8,
                "application/json");
            var client = _clientFactory.CreateClient("backend");

            using var response = await client.PostAsync($"api/stories/", storyItemJson);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(string id)
        {
            var client = _clientFactory.CreateClient("backend");
            using var response = await client.DeleteAsync($"api/stories/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
