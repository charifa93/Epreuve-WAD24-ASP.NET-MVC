using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class Mapper
    {
        public static Utilisateur ToUser(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            //if (record is null) return null;
            return new Utilisateur()
            {
                UtilisateurId = (Guid)record[nameof(Utilisateur.UtilisateurId)],
                Email = (string)record[nameof(Utilisateur.Email)],
                Motdepasse = "********",
                Pseudo = (string)record[nameof(Utilisateur.Pseudo)],
                DateCreation = (DateTime)record[nameof(Utilisateur.DateCreation)],
                DateDesactivation = (record[nameof(Utilisateur.DateDesactivation)] is DBNull) ? null : (DateTime?)record[nameof(Utilisateur.DateDesactivation)]

            };
        }
        public static Jeux ToJeux(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Jeux()
            {
                JeuId = (Guid)record[nameof(Jeux.JeuId)],
                Nom = (string)record[nameof(Jeux.Nom)],
                Description = (string)record[nameof(Jeux.Description)],
                AgeMin = (int)record[nameof(Jeux.AgeMin)],
                AgeMax = (int)record[nameof(Jeux.AgeMax)],
                NbJoueourMin = (int)record[nameof(Jeux.NbJoueourMin)],
                NbJoueourMax = (int)record[nameof(Jeux.NbJoueourMax)],
                DureeMinute = (record[nameof(Jeux.DureeMinute)] is DBNull) ? null : (int?)record[nameof(Jeux.DureeMinute)],
                DateCreation = (DateTime)record[nameof(Jeux.DateCreation)]
            };
        }
        public static Etat ToEtat(this IDataRecord record)
        {
            if(record is null) throw new ArgumentNullException( nameof(record));
            return new Etat()
            {
                EtatId = (Guid)record[nameof(Etat.EtatId)],
                UtilisateurId = (Guid)record[nameof(Etat.UtilisateurId)],
                JeuId = (Guid)record[nameof(Etat.JeuId)],
                NomEtat = (string)record[nameof(Etat.NomEtat)]
            };
        }
        public static Tag ToTag(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Tag()
            { 
                TagId = (Guid)record[nameof(Associer.TagId)],
                NomTag = (string)record[nameof(Tag.NomTag)]
            };
        }

        public static Associer ToAssocier(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Associer()
            {
                JeuId = (Guid)record[nameof(Associer.JeuId)],
                TagId = (Guid)record[nameof(Associer.TagId)]
            };
            }
    }
}
