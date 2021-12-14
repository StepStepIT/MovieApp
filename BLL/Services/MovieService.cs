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
         private readonly MovieRepository _movieRepository;
        public MovieService(MovieRepository _movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllMovie()//Add async 
        {
            var moviesTemp = await _movieRepository.GetAllAsync().ConfigureAwait(false);

            return moviesTemp.ToList();
        }
    }
}
