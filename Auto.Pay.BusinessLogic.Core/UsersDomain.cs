using Auto.Pay.BusinessLogic.Entities;
using Auto.Pay.BusinessLogic.Interface;
using Auto.Pay.Persistence.Interface;

namespace Auto.Pay.Dominio.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string userName, string password)
        {
            return null;
            //return _usersRepository.Authenticate(userName, password);
        }

        public TokenBlackList LogOut(string token, string userName)
        {
            return null;
            //return _usersRepository.LogOut(token, userName);
        }
    }
}
