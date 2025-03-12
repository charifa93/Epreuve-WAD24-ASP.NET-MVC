using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IJeuxRepository<TJeux> : IGetALLRepository<TJeux, Guid> ,
                                              IGetRepository<TJeux, Guid>,
                                             IUpdateRepository<TJeux, Guid>,
                                             IInsertRepository<TJeux, Guid>,
                                             IDeleteRepository<TJeux, Guid>
                                             
    {
        IEnumerable<TJeux> GetFromUser(Guid userId);
        IEnumerable<TJeux> GetWithTag(Guid tagId);
        IEnumerable<TJeux> GetWithNom(string Nom);
    }
}
