using DLL.Models;
using DLL.Repositoryes;

namespace BLL.Services
{
    public class AdminService
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly SessionRepository sessionRepository;
        private readonly MovieRepository movieRepository;

        public AdminService(EmployeeRepository employeeRepository, SessionRepository sessionRepository, MovieRepository movieRepository)
        {
            this.employeeRepository = employeeRepository;
            this.sessionRepository = sessionRepository;
            this.movieRepository = movieRepository;
        }
        public async Task CreateNewEmployeeAsync(Employee newEmployee)
        {
            await employeeRepository.CreateAsync(newEmployee);
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            var employeesTemp = await employeeRepository.GetAllAsync().ConfigureAwait(false);

            return employeesTemp.ToList();
        }
        public async Task CreateSession(Session newSession)
        {
            await sessionRepository.CreateAsync(newSession);
        }
        public async Task AddNewMovie(Movie newMovie)
        {
            await movieRepository.CreateAsync(newMovie);
        }
    }
}
