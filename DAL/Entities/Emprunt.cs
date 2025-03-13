using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Emprunt
    {
        public Guid EmpruntId { get; set; }
        public Guid? PreteurId { get ; set; }
        public Guid? EmprunteurId { get ; set; }
        public Guid?  JeuId {  get ; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }
        public int? EvaluationPreteur { get; set; }
        public int? EvaluationEmprunteur { get; set; }
    }
}
