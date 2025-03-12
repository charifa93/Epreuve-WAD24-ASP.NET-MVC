using BLL.Mappers;
using Common.Repositories;
using DAL.Entities;
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

        public UserService(IUserRepository<Utilisateur> userService, IJeuxRepository<Jeux> jeuxService)
        {
            _userService = userService;
            _jeuxService = jeuxService;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Utilisateur Get(Guid userId)
        {
            Utilisateur user = _userService.Get(userId).ToBLL();
            user.SetJeux(_userService.GetFromUser(userId));
            return user;
        }

        public Guid Insert(Utilisateur entity)
        {
            throw new NotImplementedException();
        }
    }
}
