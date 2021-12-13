using DLL.Models;
using DLL.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovieService
    {
        private readonly MovieRepository movieRepository;
        public MovieService(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllMovie()
        {
            var moviesTemp = await movieRepository.GetAllAsync().ConfigureAwait(false);

            return moviesTemp.ToList();
        }
    }
}
