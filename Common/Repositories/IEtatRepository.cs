using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IEtatRepository<TEtat,TId> :IGetALLRepository<TEtat,TId>
                                                
    {
       TEtat GetByJeuxId(TId jeuxId);
        //TEtat UpdateEtatInJeux (TId jeuxId , string NewEtat);
       
    }
}
