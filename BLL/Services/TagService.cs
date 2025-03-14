using BLL.Mappers;
using Common.Repositories;
using BLL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService : ITagRepository<Tag>
    {
        private ITagRepository<DAL.Entities.Tag> _tagService;

        public TagService(ITagRepository<DAL.Entities.Tag> tagService)
        {
            _tagService = tagService;
        }

        public IEnumerable<Tag> Get()
        {
            return _tagService.Get().Select(dal => dal.ToBLL());

            
        }
    }
}
