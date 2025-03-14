using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using Common.Repositories;
using DAL.Entities;
using DAL.Services;

namespace BLL.Services
{
    public class AssocierService : IAssocierRepository<AssocierService>
    {
        private IAssocierRepository<DAL.Entities.Associer> _associerService;
        private IJeuxRepository<DAL.Entities.Jeux> _jeuxService;
        private ITagRepository<DAL.Entities.Tag> _tagService;

        public AssocierService(IJeuxRepository<Jeux> jeuxService, ITagRepository<Tag> tagService, IAssocierRepository<Associer> associerService)
        {
            _associerService = associerService;
            _jeuxService = jeuxService;
            _tagService = tagService;
        }

        public IEnumerable<AssocierService> Get()
        {
            var associers = _associerService.Get().Select(dal => dal.ToBLL());

            foreach (var associer in associers)
            {
                associer.SetJeux(_jeuxService.Get(associer.JeuId).ToBLL());
                //associer.SetTag(_tagService.Get(associer.TagId).ToBLL());
            }

            return (IEnumerable<AssocierService>)associers;
        }


    }


}
