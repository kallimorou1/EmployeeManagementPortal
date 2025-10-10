using EmployeeManagement.Portal.Services;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Portal.ViewModels.Pages
{
    public class HomeViewModel : ParentViewModel
    {
        private readonly IEmployeeService EmployeeService;
        public List<Employee> Employees = new();

        public HomeViewModel(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        public async Task LoadData()
        {
            try
            {
                var paginationDto = new PaginationDTO
                {
                    Page = 1,
                    QuantityPerPage = 1000,
                };

                var (employees, _) = await EmployeeService.GetAll(paginationDto);
                Employees = employees;
            }
            finally
            {
                Initilized = true;
                PageTitle = $"Dashboard - {Employees.Count} employees found";
            }
        }
    }
}
