using DLL.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SessionService
    {
        private readonly SessionRepository sessionRepository;

        public SessionService(SessionRepository session)
        {
            sessionRepository = session;
        }


    }
}
