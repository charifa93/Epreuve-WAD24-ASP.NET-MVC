using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.Jeux
{
    public class JeuxCreateForm
    {
        [DisplayName("Nom du jeu : ")]
        [Required(ErrorMessage = "Le champ 'Nom du Jeu' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Nom du cocktail' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Nom du cocktail' doit contenir au maximum 64 caractères.")]
        public string Nom { get; set; }


        [DisplayName("Description : ")]
        [MinLength(2, ErrorMessage = "Le champ 'Description' doit contenir au minimum 2 caractères.")]
        //[MaxLength(512, ErrorMessage = "Le champ 'Description' doit contenir au maximum 512 caractères.")]
        public string? Description { get; set; }


        [DisplayName("AgeMin : ")]
        [DataType(DataType.MultilineText)]
        [Range(1, int.MaxValue, ErrorMessage = " Age minimum doit être supérieur à 0.")]
        [Required(ErrorMessage = "Le champ 'AgeMin' est obligatoire.")]
        public int AgeMin { get; set; }


        [DisplayName("AgeMax : ")]
        [DataType(DataType.MultilineText)]
        [Range(1, int.MaxValue, ErrorMessage = "Age Max doit être supérieur à AgeMin.")]
        [Required(ErrorMessage = "Le champ 'AgeMax' est obligatoire.")]
        public int AgeMax { get; set; }

        [DisplayName("Nombre de Joueur minumum : ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Le champ 'AgeMax' est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de joueurs minimum doit être supérieur à 0.")]
        public int NbJoueurMin { get; set; }

        [DisplayName("Nombre de Joueur Maximun : ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Le champ 'AgeMax' est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de joueurs Max doit être supérieur à 0.")]
        public int NbJoueurMax { get; set; }

        [DisplayName("Duree Minute : ")]
        [DataType(DataType.MultilineText)]
        [Range(1, int.MaxValue, ErrorMessage = "La Duree Minute doit être supérieur à 00.")]
        public int? DureeMinute { get; set; }

    }
}
