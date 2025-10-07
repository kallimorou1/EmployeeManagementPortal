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


        public async Task<(List<Employee> Employees, int TotalPages)> GetAll(int page = 1, int quantityPerPage = 10)
        {
            var response = await _httpClient.GetAsync($"api/Employee/GetAll?page={page}&quantityPerPage={quantityPerPage}");
            response.EnsureSuccessStatusCode();

            int totalPages = 1;
            if (response.Headers.TryGetValues("pagesQuantity", out var values))
            {
                Console.WriteLine($"DEBUG: pagesQuantity header = {values.FirstOrDefault()}");
                int.TryParse(values.FirstOrDefault(), out totalPages);
            }else
            {
                Console.WriteLine("DEBUG: pagesQuantity header not found");
            }

            var employees = await response.Content.ReadFromJsonAsync<List<Employee>>();
            return (employees ?? new List<Employee>(), totalPages);
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
