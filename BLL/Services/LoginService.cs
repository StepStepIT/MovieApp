using DLL.Models;
using DLL.Repositoryes;

namespace BLL.Services
{
    public class LoginService
    {
        private readonly LoginRepository loginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task<Employee> EmployeeAutorization(LoginData loginData)
        {
          return (await loginRepository.FindByCounditionAsync(x => x.Login == loginData.Login && x.Password == loginData.Password)).First().Employee;
        }
    }
}
