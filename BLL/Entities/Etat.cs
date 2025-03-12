using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Etat
    {
        

        public Guid EtatId { get; set; }
        public Guid UtilisateurId { get; set; }
        public Guid JeuId { get; set; }
        public string NomEtat { get; set; }

        public Etat(string nomEtat)
        {
            NomEtat = nomEtat;
        }

        public Etat(Guid etatId, Guid utilisateurId, Guid jeuId, string nomEtat) : this(nomEtat)
        {
            EtatId = etatId;
            UtilisateurId = utilisateurId;
            JeuId = jeuId;
        }
    }
}
