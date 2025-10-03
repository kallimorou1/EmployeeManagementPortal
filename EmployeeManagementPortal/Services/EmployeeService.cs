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

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {

            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetAll");
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }

        public async Task<bool> AddEmployeeAsync(Employee newEmployee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee/Add/", newEmployee);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateEmployeeAsync(Employee updatedEmployee)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Employee/Update{updatedEmployee.Id}", updatedEmployee);
            return response.IsSuccessStatusCode;
        }       
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/DeleteById/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
