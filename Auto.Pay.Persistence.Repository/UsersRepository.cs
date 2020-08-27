using Blastic.Skylu.Infraestructura.Entities;
using Blastic.Skylu.Infraestructura.Interface;
using Blastic.Skylu.Servicio.Api.Models;
using System;
using System.Linq;

namespace Blastic.Skylu.Infraestructura.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ContextoSimulador _contexto;
        private readonly ITokenBlackListRepository _tokenBlackListRepository;

        public UsersRepository(ContextoSimulador contexto, ITokenBlackListRepository tokenBlackListRepository)
        {
            _contexto = contexto;
            _tokenBlackListRepository = tokenBlackListRepository;
        }

        public Users Authenticate(string userName, string password)
        {
            return _contexto.Users.FirstOrDefault(u => u.Username.ToUpper().Equals(userName.ToUpper()) && u.Passwordhash.ToUpper().Equals(password.ToUpper()) && !u.Eliminado);
        }

        public TokenBlackList LogOut(string token, string userName)
        {
            return _tokenBlackListRepository.Agregar(
                   new TokenBlackList
                   {
                       UserName = userName,
                       Token = token
                   });
        }
    }
}
