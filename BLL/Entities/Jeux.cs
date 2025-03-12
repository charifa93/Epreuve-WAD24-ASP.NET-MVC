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
        public Utilisateur? Creator { get; private set; }

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
        }

        public Jeux(Guid jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation, Utilisateur? creator)
        {
            Creator = creator;
        }
    }
}
