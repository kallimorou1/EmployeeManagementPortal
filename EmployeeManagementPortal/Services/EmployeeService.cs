using EmployeeManagement.Shared.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

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
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
