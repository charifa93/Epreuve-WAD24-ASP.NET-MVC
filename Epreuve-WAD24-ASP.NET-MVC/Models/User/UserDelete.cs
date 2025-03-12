using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Epreuve_WAD24_ASP.NET_MVC.Models.User
{
    public class UserDelete
    {
        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }


        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
