using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Etat
    {
        public Guid EtatId { get; set; }
        public Guid UtilisateurId {  get; set; }
        public Guid JeuId { get; set; }
        public string NomEtat { get; set; }
       
    }
}
