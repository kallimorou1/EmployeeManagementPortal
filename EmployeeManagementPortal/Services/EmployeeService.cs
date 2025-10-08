using EmployeeManagement.Shared.Models;
using System;
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
        public async Task<(List<Employee> Employees, int TotalPages)> GetAll(
            PaginationDTO pagination)
        {
            var url = $"api/Employee/GetAll?page={pagination.Page}&quantityPerPage={pagination.QuantityPerPage}";
            
            if (!string.IsNullOrWhiteSpace(pagination.SearchTerm))
                url += $"&SearchTerm={Uri.EscapeDataString(pagination.SearchTerm)}";

            if (!string.IsNullOrWhiteSpace(pagination.SortColumn))
                url += $"&SortColumn={Uri.EscapeDataString(pagination.SortColumn)}&SortOrder={SortOrder.Ascending}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            int totalPages = 1;

            if (response.Headers.TryGetValues("pagesQuantity", out var values))
            {
                int.TryParse(values.FirstOrDefault(), out totalPages);
            }
            

            var employees = await response.Content.ReadFromJsonAsync<List<Employee>>();
            return (employees ?? new List<Employee>(), totalPages);


        }



        #region GET BY ID
        public async Task<Employee?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }
        #endregion

        #region ADD NEW EMPLOYEE
        public async Task<bool> Add(Employee newEmployee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee/Add/", newEmployee);
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region UPDATE EMPLOYEE
        public async Task<bool> UpdateEmployee(Employee updatedEmployee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/Update", updatedEmployee);

            return response.IsSuccessStatusCode;
        }
        #endregion

        #region DELETE EMPLOYEE BY ID
        public async Task<bool> DeleteById(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/DeleteById?id={id}");
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
