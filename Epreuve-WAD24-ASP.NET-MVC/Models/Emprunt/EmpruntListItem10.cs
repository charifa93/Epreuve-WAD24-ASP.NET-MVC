using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.Emprunt
{
    public class EmpruntListItem10
    {
        [ScaffoldColumn(false)]
        public Guid EmpruntId { get; set; }



        [DisplayName("JPreteur : ")]
        public Guid? PreteurId { get; set; }


        [DisplayName("Empranteur : ")]
        public Guid? EmprunteurId { get; set; }



        [DisplayName("Le jeu  : ")]
        public Guid? JeuId { get; set; }



        [DisplayName("Date de Emprunt : ")]
        public DateTime DateEmprunt { get; set; }



        [DisplayName("Date de retour  : ")]
        public DateTime DateRetour { get; set; }



        [DisplayName("Evaluation Preteur  : ")]
        public int? EvaluationPreteur { get; set; }

        [DisplayName("Evaluation Emprunteur  : ")]

        public int? EvaluationEmpruteur { get; set; }
    }
}
