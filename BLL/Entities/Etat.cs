using DAL.Entities;
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
        public string NomEtat { get; set; }

        private Guid _utilisateurId;
        public Guid UtlisateurId { get { return Creator?.UtilisateurId ?? _utilisateurId; } }
        public Utilisateur? Creator { get; private set; }

        private Guid _jeuId;
        public Guid JeuId { get { return Jeux?.JeuId ?? _jeuId; } }
        public Jeux Jeux { get;private set; }


        public Etat(Guid etatId, Utilisateur creator, Jeux jeux, string nomEtat) 
        {
            EtatId = etatId;
            Creator = creator;
            Jeux = jeux;
            NomEtat = nomEtat;
        }
        public Etat( Utilisateur creator, Jeux jeux, string nomEtat) : this(Guid.NewGuid(), creator, jeux, nomEtat)
        {
        }
        public Etat(Guid etatId, Guid utilisateurId, Guid jeuId, string nomEtat)
        {
            EtatId = etatId;
            _jeuId = jeuId;
            _utilisateurId = utilisateurId;
            NomEtat = nomEtat;
        }
        public Etat( Guid utilisateurId, Guid jeuId, string nomEtat) : this(Guid.NewGuid(), utilisateurId, jeuId, nomEtat)
        {
        }
    }
}
