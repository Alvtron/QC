using QC.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace QC.UI.DataSource
{
    /// <summary>
    /// 
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Users Instance { get; } = new Users();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string baseUri = "http://localhost:63011/api/";

        /// <summary>
        /// The client
        /// </summary>
        HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="Users" /> class from being created.
        /// </summary>
        private Users()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetStudents()
        {
            var json = await _client.GetStringAsync("Users").ConfigureAwait(false);
            User[] students = JsonConvert.DeserializeObject<User[]>(json);
            return students;
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public async Task<bool> DeleteStudent(User student)
        {
            var response = await _client.DeleteAsync($"Users\\{student.UID}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound;
        }

        /// <summary>
        /// Adds the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        public async Task<bool> AddStudent(User user)
        {
            string postBody = JsonConvert.SerializeObject(user);
            var response = await _client.PostAsync("Users", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}