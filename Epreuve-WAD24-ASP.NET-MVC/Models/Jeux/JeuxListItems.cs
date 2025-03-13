using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.Jeux
{
    public class JeuxListItems
    {
        [ScaffoldColumn(false)]
        public Guid JeuId { get; set; }
        [DisplayName("Jeu : ")]
        public string Nom { get; set; }
        [DisplayName("Description : ")]
        public string? Description { get; set; }

        [DisplayName("Age minimun : ")]
        public int AgeMin { get; set; }

        [DisplayName("Age Maximun : ")]
        public int AgeMax { get; set; }

        [DisplayName("Nombre de joueur min  : ")]
        public int NbJoueurMin { get; set; }

        [DisplayName("Nombre de joueur Max  : ")]

        public int NbJoueurMax { get; set;}

        [DisplayName("la duree du jeu en Minute   : ")]

        public int? DureeMinute {  get; set; }



    }
}
