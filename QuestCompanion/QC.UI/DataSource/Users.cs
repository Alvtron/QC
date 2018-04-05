using QC.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace QC.UI.DataSource
{
    public class Users
    {
        public static Users Instance { get; } = new Users();
        private const string baseUri = "http://localhost:63011/api/";

        HttpClient _client;

        private Users()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<User[]> GetUsers()
        {
            var json = await _client.GetStringAsync("Users").ConfigureAwait(false);
            User[] users = JsonConvert.DeserializeObject<User[]>(json);
            return users;
        }

        public async Task<bool> DeleteStudent(User user)
        {
            var response = await _client.DeleteAsync($"Users\\{user.UID}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound;
        }

        public async Task<bool> AddStudent(User user)
        {
            string postBody = JsonConvert.SerializeObject(user);
            var response = await _client.PostAsync("Users", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}