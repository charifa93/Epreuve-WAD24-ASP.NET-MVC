using Epreuve_WAD24_ASP.NET_MVC.Models.User;
using BLL.Entities;

namespace Epreuve_WAD24_ASP.NET_MVC.Mappers
{
    internal static class Mapper
    {
        public static UserDetails ToDetails(this Utilisateur user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDetails()
            {
                UtilisateurId = user.UtilisaeurId,
                Pseudo = user.Pseudo,
                Email = user.Email,
                DateCreation = DateOnly.FromDateTime(user.DateCreation),
                //Cocktails = user.Cocktails.Select(bll => bll.ToListItem())
            };
        }
    }
}
