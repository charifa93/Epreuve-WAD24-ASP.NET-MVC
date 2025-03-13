using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IUserRepository<TUtilisateur> :IInsertRepository<TUtilisateur, Guid> ,
                                                     IGetRepository<TUtilisateur, Guid> , 
                                                    IDeleteRepository<TUtilisateur, Guid>,
                                                    IUpdateRepository<TUtilisateur, Guid>
    { 
     
    }
}
