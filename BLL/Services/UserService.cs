using BLL.Mappers;
using BLL.Entities;
using Common.Repositories;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserRepository<Utilisateur>
    {
        private IUserRepository<DAL.Entities.Utilisateur> _userService;
        private IJeuxRepository<DAL.Entities.Jeux> _jeuxService;

        public UserService(IUserRepository<D.Utilisateur> userService, IJeuxRepository<D.Jeux> jeuxService)
        {
            _userService = userService;
            _jeuxService = jeuxService;
        }

        public void Delete(Guid userId)
        {
            _userService.Delete(userId);
        }

        public Utilisateur Get(Guid userId)
        {
            Utilisateur user = _userService.Get(userId).ToBLL();
            return user ;
        }

        public Guid Insert(Utilisateur user)
        {
            return _userService.Insert(user.ToDAL());

        }
    }
}
