using B = BLL.Entities;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        public static B.Utilisateur ToBLL(this D.Utilisateur user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new B.Utilisateur(
                user.UtilisateurId,
                user.Pseudo,
                user.Email,
                user.Motdepasse,
                user.DateCreation,
                user.DateDesactivation
                );
        }
        public static D.Utilisateur ToDAL(this B.Utilisateur user) 
        {
            if (user is null) throw new ArgumentNullException( nameof(user));
            return new D.Utilisateur()
            {
                UtilisateurId = user.UtilisateurId,
                Pseudo = user.Pseudo,
                Email = user.Email,
                Motdepasse = user.MotDePasse,
                DateCreation = user.DateCreation,
                DateDesactivation = (user.DateDesactivation) ? new DateTime() : null
            };
        }

        public static B.Jeux ToBLL (this D.Jeux jeux)
        {
            if (jeux is null) throw new ArgumentNullException(nameof(jeux));
            return new B.Jeux(
                jeux.JeuId,
                jeux.Nom,
                jeux.Description,
                jeux.AgeMin,
                jeux.AgeMax,
                jeux.NbJoueourMin,
                jeux.NbJoueourMax,
                jeux.DureeMinute,
                jeux.DateCreation
                );
        }
        public static D.Jeux ToDAL (this B.Jeux jeux)
        {
            if (jeux is null) throw new ArgumentNullException(nameof(jeux));
            return new D.Jeux()
            {
               JeuId = jeux.JeuId,
                Nom = jeux.Nom,
                Description = jeux.Description,
                AgeMin = jeux.AgeMin,
                AgeMax = jeux.AgeMax,
                NbJoueourMin = jeux.NbJoueurMin,
                NbJoueourMax = jeux.NbJoueurMax,
                DureeMinute = jeux.DureeMinute,
                DateCreation = jeux.DateCreation
            };
        }
        public static B.Etat ToBLL(this D.Etat etat)
        {
            if (etat is null) throw new ArgumentNullException(nameof(etat));
            return new B.Etat(
                etat.EtatId,
                etat.UtilisateurId,
                etat.JeuId,
                etat.NomEtat
                );
        }
        public static D.Etat ToDAL (this B.Etat etat) 
        {
            if (etat is null) throw new ArgumentNullException(nameof(etat));
            return new D.Etat()
            {
                EtatId = etat.EtatId,
                UtilisateurId = etat.UtilisateurId,
                JeuId = etat.JeuId,
                NomEtat = etat.NomEtat
            };
        }

    }

}
