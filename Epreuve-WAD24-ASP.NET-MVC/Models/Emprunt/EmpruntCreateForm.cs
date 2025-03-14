using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.Emprunt
{
    public class EmpruntCreateForm
    {
        [DisplayName("Date Retour : ")]
        public DateTime? DateRetour { get; set; }


        [HiddenInput]
        public Guid? PreteurId { get; set; }

        [HiddenInput]
        public Guid? EmprenteurId { get; set; }

        [HiddenInput]
        public Guid? JeuId { get; set; }


    }
}
