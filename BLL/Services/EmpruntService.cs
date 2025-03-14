using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmpruntService :IEmpruntRepository<Emprunt>
    {
        private IEmpruntRepository<DAL.Entities.Emprunt> _empruntService;
        private IJeuxRepository<DAL.Entities.Jeux> _jeuxService;
        private IUserRepository<DAL.Entities.Utilisateur> _userService;

        public EmpruntService(IEmpruntRepository<DAL.Entities.Emprunt> empruntService, IJeuxRepository<DAL.Entities.Jeux> jeuxService, IUserRepository<DAL.Entities.Utilisateur> userService)
        {
            _empruntService = empruntService;
            _jeuxService = jeuxService;
            _userService = userService;
        }

        public void AjouterEvaluationAsync(Guid empruntId, int? evaluationPreteur, int? evaluationEmprunteur)
        {
            _empruntService.AjouterEvaluationAsync(empruntId, evaluationPreteur, evaluationEmprunteur);
        }

        public void CloturerEmprunt(Guid empruntId)
        {
            _empruntService.CloturerEmprunt(empruntId);
        }

        public IEnumerable<Emprunt> GetTop10Emprunts()
        {
            IEnumerable<Emprunt> emprunts = _empruntService.GetTop10Emprunts().Select(dal=>dal.ToBLL());

            foreach (Emprunt emprunt in emprunts)
            {
                if (emprunt.JeuId is not null)
                {
                    emprunt.SetEmprunteur(_userService.Get((Guid)emprunt.EmprenteurId).ToBLL());
                    emprunt.SetJeux(_jeuxService.Get((Guid)emprunt.JeuId).ToBLL());
                    emprunt.SetEmprunteur(_userService.Get((Guid)emprunt.PreteurId).ToBLL());

                }
            }
            return emprunts;
        }

        public Guid Insert(Emprunt emprunt)
        {
            return _empruntService.Insert(emprunt.ToDAL());
        }
    }
}
