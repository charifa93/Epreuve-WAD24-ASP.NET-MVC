using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class Jeux
    {
      
        public Guid JeuId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int NbJoueurMin { get; set; }
        public int NbJoueurMax { get; set; }
        public int? DureeMinute { get; set; }
        public DateTime DateCreation { get; set; }

        private Guid? _createdBy;
        public Guid? CreatedBy { get { return Creator?.UtilisateurId ?? _createdBy; } }
        public Utilisateur? Creator { get; private set; }

        


        private List<Associer> _associer;
        public Associer[] Associers
        {
            get { return _associer.ToArray(); }
        }




        public Jeux(Guid jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation)
        {
            JeuId = jeuId;
            Nom = nom;
            Description = description;
            AgeMin = ageMin;
            AgeMax = ageMax;
            NbJoueurMin = nbJoueurMin;
            NbJoueurMax = nbJoueurMax;
            DureeMinute = dureeMinute;
            DateCreation = dateCreation;
            _associer = new List<Associer>();
        }

        public Jeux(Guid jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation, Guid? createdby )
        {
           
            _createdBy = createdby;
        }
        public Jeux(Guid jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation, Utilisateur? creator )
        {
            
            Creator = creator;
            if (Creator is not null) _createdBy = Creator.UtilisateurId;
        }


        //Les Methodes :

        public void SetCreator(Utilisateur creator)
        {
            if (creator is null) throw new ArgumentNullException(nameof(creator));
            if (CreatedBy is null) throw new InvalidOperationException("Pas d'utilisateur à enregitrer.");
            if (CreatedBy != creator.UtilisateurId) throw new InvalidOperationException("Mauvais utilisateur");
            Creator = creator;
        }



    }
}
