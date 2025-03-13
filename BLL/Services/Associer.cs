using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;

namespace BLL.Services
{
    public class Associer : IAssocierRepository<Associer>
    {
        public IEnumerable<Associer> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Associer> GetTagsByJeu(Guid JeuId)
        {
            throw new NotImplementedException();
        }
    }
}
