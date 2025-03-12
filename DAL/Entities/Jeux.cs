using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public  class Jeux
    {
        private Guid guid;
        private int nbJoueurMin;
        private int nbJoueurMax;
        private DateTime now;

        public Jeux(Guid guid, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime now)
        {
            this.guid = guid;
            Nom = nom;
            Description = description;
            AgeMin = ageMin;
            AgeMax = ageMax;
            this.nbJoueurMin = nbJoueurMin;
            this.nbJoueurMax = nbJoueurMax;
            DureeMinute = dureeMinute;
            this.now = now;
        }

        public Guid JeuId { get; set; }
        public string Nom {  get; set; }
        public string Description { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int NbJoueourMin { get; set; }
        public int NbJoueourMax { get; set;}
        public int? DureeMinute { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
