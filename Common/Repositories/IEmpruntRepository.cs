using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IEmpruntRepository<TEmprunt> : 
                                                       IInsertRepository<TEmprunt,Guid>
                                                      
                                                           
    {
        void CloturerEmprunt(Guid empruntId);
        IEnumerable<TEmprunt> GetTop10Emprunts();
        void AjouterEvaluationAsync(Guid empruntId, int? evaluationPreteur, int? evaluationEmprunteur);

    }
}
