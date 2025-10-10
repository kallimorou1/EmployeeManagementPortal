using EmployeeManagement.Portal.Services;
using EmployeeManagement.Portal.ViewModels;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

public class CreateViewModel : ParentViewModel
{
    private readonly NavigationManager _navigation;
    private readonly IEmployeeService _employeeService;

    public Employee? Employee { get; set; }
    public string? Message { get; set; }
    public string MessageClass { get; set; } = "";

    public CreateViewModel(NavigationManager navigation, IEmployeeService employeeService)
    {
        _navigation = navigation;
        _employeeService = employeeService;
    }

    public void Initialize()
    {
        Employee = new Employee
        {
            Name = "",
            Position = "",
            Department = ""
        };
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            if (Employee is not null)
            {
                var success = await _employeeService.Add(Employee);

                if (success)
                {
                    Message = "Employee created successfully!";
                    MessageClass = "alert alert-success";
                    await Task.Delay(2000);
                    _navigation.NavigateTo("/EmployeeManagement");
                }
                else
                {
                    Message = "Failed to add employee.";
                    MessageClass = "alert alert-danger";
                }
            }
        }
        catch (HttpRequestException)
        {
            Message = "Network error. Please check your connection.";
            MessageClass = "alert alert-danger";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    public void NavigateToEmployeeList()
    {
        _navigation.NavigateTo("/EmployeeManagement");
    }
}
