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

        public async Task<Employee> EmployeeAutorization(LoginData loginData) // ADD Employee repository and select from emplRepository. Use FirstAsync();
        {
          return (await loginRepository.FindByCounditionAsync(x => x.Login == loginData.Login && x.Password == loginData.Password)).First().Employee;
        }
    }
}
