﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.User
{
    public class UserDetails
    {
        [ScaffoldColumn(false)]
        public Guid UtilisateurId { get; set; }


        [DisplayName("Pseudo : ")]
        public string Pseudo { get; set; }


        [DisplayName("E-mail : ")]
        [EmailAddress]
        public string Email { get; set; }


        [DisplayName("Date d'inscription : ")]
        [DataType(DataType.Date)]
        public DateOnly DateCreation { get; set; }


        //[DisplayName("Vos cocktails : ")]
        //public IEnumerable<CocktailListItem> Cocktails { get; set; }
    }
}
