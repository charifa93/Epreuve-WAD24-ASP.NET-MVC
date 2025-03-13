using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IAssocierRepository <TAssocier> : IGetALLRepository<TAssocier,Guid>
    {
        IEnumerable<TAssocier> GetTagsByJeu(Guid JeuId);
    }
}
