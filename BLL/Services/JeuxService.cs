using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;

namespace BLL.Services
{
    public class JeuxService : IJeuxRepository<Jeux>
    {
        private IJeuxRepository<DAL.Entities.Jeux> _jeuxService;
        private IUserRepository<DAL.Entities.Utilisateur> _userService;
        //private IEtatRepository<DAL.Entities.Etat> _etatService;

        public JeuxService(IJeuxRepository<DAL.Entities.Jeux> jeuxService, IUserRepository<DAL.Entities.Utilisateur> userService)
        {
            _jeuxService = jeuxService;
            _userService = userService;
            //_etatService = etatService;
        }

        public void Delete(Guid jeuId)
        {
           _jeuxService.Delete(jeuId);
        }

        public IEnumerable<Jeux> Get()
        {
            throw new NotImplementedException();
        }

        public Jeux Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jeux> GetFromUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jeux> GetWithNom(string Nom)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jeux> GetWithTag(Guid tagId)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(Jeux entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Jeux entity)
        {
            throw new NotImplementedException();
        }
        //private IEtatRepository<DAL.Entities.Etat> _etatService;

    }
}
