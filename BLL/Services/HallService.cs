using DLL.Models;
using DLL.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HallService
    {
        HallRepository hallRepository;

        public HallService(HallRepository hallRepository)
        {
            this.hallRepository = hallRepository;
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            var hallList = await hallRepository.GetAllAsync().ConfigureAwait(false);

            return hallList.ToList();
        }


    }
}
