using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.Jeux
{
    public class JeuxDetails
    {
        [ScaffoldColumn(false)]
        public Guid jeuId { get; set; }


        [DisplayName("Jeu : ")]
        public string Name { get; set; }


        [DisplayName("Description : ")]
        public string? Description { get; set; }


        [DisplayName("Age Min : ")]
        [DataType(DataType.MultilineText)]
        public int AgeMin { get; set; }


        [DisplayName("Age Max : ")]
        [DataType(DataType.MultilineText)]
        public int AgeMax { get; set; }


        [DisplayName("Nbr joueur Min : ")]
        [DataType(DataType.MultilineText)]
        public int NbJoueurMin { get; set; }


        [DisplayName("Nbr joueur Max : ")]
        [DataType(DataType.MultilineText)]
        public int NbJoueurMax { get; set; }


        [DisplayName("Duree Minute : ")]
        [DataType(DataType.MultilineText)]
        public int? DureeMinute { get; set; }



        [DisplayName("Créé par : ")]
        public string? Creator { get; set; }


        
        public DateOnly DateCreation{ get; set; }

        //[DisplayName("Jeux : ")]
        //public IEnumerable<JeuxListItems> Jeux { get; set; }
    }
}
