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
        private ITagRepository<DAL.Entities.Tag> _tagService;

        public JeuxService(IJeuxRepository<DAL.Entities.Jeux> jeuxService, IUserRepository<DAL.Entities.Utilisateur> userService, ITagRepository<DAL.Entities.Tag> tagService)
        {
            _jeuxService = jeuxService;
            _userService = userService;
            _tagService = tagService;
        }

        public void Delete(Guid jeuId)
        {
           _jeuxService.Delete(jeuId);
        }

        public IEnumerable<Jeux> Get()
        {
            IEnumerable<Jeux> Jeux = _jeuxService.Get().Select(dal => dal.ToBLL());
            foreach (Jeux jeu in Jeux)
            {
                if (jeu.CreatedBy is not null)
                {
                    jeu.SetCreator(_userService.Get((Guid)jeu.CreatedBy).ToBLL());
                }
            }
            return Jeux;
        }

        public Jeux Get(Guid jeuId)
        {
            Jeux jeu = _jeuxService.Get(jeuId).ToBLL();
            if (jeu.CreatedBy is not null)
            {
                jeu.SetCreator(_userService.Get((Guid)jeu.CreatedBy).ToBLL());
            }
            
            return jeu;
        }

        public IEnumerable<Jeux> GetFromUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jeux> GetWithNom(string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentException("Le nom du jeu ne peut pas être vide.", nameof(nom));
            }

            return (IEnumerable<Jeux>)_jeuxService.GetWithNom(nom);
        }

        public IEnumerable<Jeux> GetWithTag(Guid tagId)
        {
            if (tagId == Guid.Empty)
            {
                throw new ArgumentException("L'ID du tag ne peut pas être vide.", nameof(tagId));
            }

            return (IEnumerable<Jeux>)_jeuxService.GetWithTag(tagId);
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
