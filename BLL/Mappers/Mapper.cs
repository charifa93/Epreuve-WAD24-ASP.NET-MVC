using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        public static Utilisateur ToBLL (this DAL.Entities.Utilisateur user)
        {
            if(user is null) throw new ArgumentNullException(nameof(user);
            return new Utilisateur(
                user.UtilisateurId,
                user.Pseudo,
                user.Email,
                user.Motdepasse,
                user.DateCreation,
                user.DateDesactivation
                );
        }
        public static DAL.Entities.Utilisateur ToDAL(this Utilisateur user) 
        {
            if (user is null) throw new ArgumentNullException( nameof(user));
            return new DAL.Entities.Utilisateur()
            {
                UtilisateurId = user.UtilisateurId,
                Pseudo = user.Pseudo,
                Email = user.Email,
                Motdepasse = user.MotDePasse,
                DateCreation = user.DateCreation,
                DateDesactivation = (user.DateDesactivation) ? new DateTime() : null
            };
        }
    }
}
