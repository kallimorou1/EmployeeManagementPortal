using EmployeeManagement.Shared.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace EmployeeManagementPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            var employees = _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetAll");
            return employees;
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            var employee = _httpClient.GetFromJsonAsync<Employee>($"api/Employee/GetById?id={id}");
            return employee;
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
           var addedEmployee = _httpClient.PostAsJsonAsync("api/Employee/Create", employee)
                .ContinueWith(task => task.Result.Content.ReadFromJsonAsync<Employee>())
                .Unwrap();
            return addedEmployee;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
