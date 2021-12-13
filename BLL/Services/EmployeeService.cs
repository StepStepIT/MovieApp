using DLL.Models;
using DLL.Repositoryes;

namespace BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task ChangePassword(Employee currentEmployee, string newPassword)
        {
            currentEmployee.LoginData.Password = newPassword;
            await employeeRepository.UpdateEntityAsync(currentEmployee);
        }
    }
}
