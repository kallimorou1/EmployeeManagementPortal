using EmployeeManagement.Shared.Models;
using System.Net.Http.Json;


namespace EmployeeManagement.Portal.Services
{
    public class EmployeeService
    {
            private readonly HttpClient _httpClient;

            public EmployeeService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

        public async Task<List<Employee>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetAll");
        }

        public async Task<Employee?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }

        public async Task<bool> Add(Employee newEmployee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee/Add/", newEmployee);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateEmployee(Employee updatedEmployee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/Update", updatedEmployee);

            return response.IsSuccessStatusCode;
        }       
        public async Task<bool> DeleteById(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/DeleteById?id={id}");
            return response.IsSuccessStatusCode;
        }
    }
}
