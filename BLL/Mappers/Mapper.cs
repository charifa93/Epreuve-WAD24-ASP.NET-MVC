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
               UtilisateurId = etat.UtlisateurId,
               JeuId = etat.JeuId,
               NomEtat = etat.NomEtat
            };
        }

        public static B.Tag ToBLL(this D.Tag tag)
        {
            if(tag is null ) throw new ArgumentNullException(nameof(tag));
            return new B.Tag
                (
                tag.TagId,
                tag.NomTag
                );
        }
        public static D.Tag ToDAL(this B.Tag tag)
        {
            if (tag is null) throw new ArgumentNullException(nameof(tag));
            return new D.Tag()
            {
                TagId = tag.TagId,
                NomTag = tag.NomTag,
            };
        }

        public static B.Emprunt ToBLL(this D.Emprunt emprunt)
        {
            if (emprunt is null) throw new ArgumentNullException(nameof(emprunt));
            return new B.Emprunt
                (
                emprunt.EmpruntId,
                emprunt.DateEmprunt,
                emprunt.DateRetour,
                emprunt.EvaluationPreteur,
                emprunt.EvaluationEmprunteur,
                emprunt.PreteurId,
                emprunt.EmprunteurId,
                emprunt.JeuId
                );
        }
        public static D.Emprunt ToDAL(this B.Emprunt emprunt)
        {
            if (emprunt is null) throw new ArgumentNullException(nameof(emprunt));
            return new D.Emprunt()
            {
               
                EmpruntId = emprunt.EmpruntId,
                PreteurId = emprunt.PreteurId,
                EmprunteurId = emprunt.EmprenteurId,
                JeuId = emprunt.JeuId,
                DateEmprunt = emprunt.DateEmprunt,
                DateRetour = emprunt.DateRetour,
                EvaluationPreteur = emprunt.EvaluationPreteur,
                EvaluationEmprunteur = emprunt.EvaluationEmprunteur

            };
        }

        public static B.Associer ToBLL(this D.Associer associer)
        {
            if(associer is null) throw new ArgumentNullException(nameof(associer));
            return new B.Associer
                (
                associer.JeuId,
                associer.TagId
                );
        }
        public static D.Associer ToDAL(this B.Associer associer)
        {
            if (associer is null) throw new ArgumentNullException( nameof(associer));
            return new D.Associer()
            {
                JeuId = associer.JeuId,
                TagId = associer.TagId

            };
        }
        



    }

}
