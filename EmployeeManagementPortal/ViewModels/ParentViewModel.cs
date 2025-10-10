using EmployeeManagement.Portal.ViewModels.Pages;

namespace EmployeeManagement.Portal.ViewModels
{
    public class ParentViewModel
    {
        public bool Initilized { get; set; } = false;
        public string PageTitle { get; set; } = "Employee Management";

       public string? GlobalMessage { get; set; }
        public string GlobalMessageClass { get; set; } = "";
    }

}
