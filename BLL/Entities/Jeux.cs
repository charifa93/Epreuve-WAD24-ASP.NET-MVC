using DAL.Entities;
using System;
using System.Collections.Generic;
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

        


        private List<Tag> _tags;
        public Tag[] Tags
        {
            get { return _tags.ToArray(); }
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
            _tags = new List<Tag>();
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

    }
}
