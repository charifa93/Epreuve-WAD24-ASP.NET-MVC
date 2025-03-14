using Epreuve_WAD24_ASP.NET_MVC.Models.User;
using BLL.Entities;
using Epreuve_WAD24_ASP.NET_MVC.Models.Jeux;
using Humanizer;
using Epreuve_WAD24_ASP.NET_MVC.Models.Emprunt;

namespace Epreuve_WAD24_ASP.NET_MVC.Mappers
{
    internal static class Mapper
    {
        public static UserDetails ToDetails(this Utilisateur user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDetails()
            {
                UtilisateurId = user.UtilisateurId,
                Pseudo = user.Pseudo,
                Email = user.Email,
                DateCreation = DateOnly.FromDateTime(user.DateCreation),
                Jeux = user.Jeux.Select(bll => bll.ToListItem())
            };
        }
        public static Utilisateur ToBLL(this UserCreateForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new Utilisateur(
                Guid.Empty,
                user.Pseudo,
                user.Email,
                user.MotDePasse,
                DateTime.Now,
                null
                );
        }

        public static UserEditForm ToEditForm(this Utilisateur user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserEditForm()
            {
                Pseudo = user.Pseudo

            };
        }

        public static Utilisateur ToBLL(this UserEditForm user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new Utilisateur(

               user.Pseudo

                );
        }
        public static UserDelete ToDelete(this Utilisateur user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            return new UserDelete()
            {

                Pseudo = user.Pseudo,
                Email = user.Email
            };


        }



        //Jeux
        public static JeuxListItems ToListItem(this Jeux jeux)
        {
            if (jeux is null) throw new ArgumentNullException(nameof(jeux));
            return new JeuxListItems()
            {
                JeuId = jeux.JeuId,
                Nom = jeux.Nom,
                Description = jeux.Description,
                AgeMin = jeux.AgeMin,
                AgeMax = jeux.AgeMax,
                NbJoueurMax = jeux.NbJoueurMax,
                NbJoueurMin = jeux.NbJoueurMin,
                DureeMinute = jeux.DureeMinute
            };
        }
        public static JeuxDetails ToDetails(this Jeux jeux)
        {
            if (jeux is null) throw new ArgumentNullException(nameof(jeux));
            return new JeuxDetails()
            {
                jeuId = jeux.JeuId,
                Name = jeux.Nom,
                Description = jeux.Description,
                AgeMax = jeux.AgeMax,
                AgeMin = jeux.AgeMin,
                NbJoueurMax = jeux.NbJoueurMax,
                NbJoueurMin = jeux.NbJoueurMin,
                DureeMinute = jeux.DureeMinute,
                DateCreation = DateOnly.FromDateTime(jeux.DateCreation)
                //Tags = jeux.Tags.Select(bll => bll.ToListItem())

            };

        }

        public static Jeux ToBLL (this JeuxCreateForm jeux)
        {
            if (jeux is null ) throw new ArgumentNullException(nameof(jeux));
            return new Jeux(
               Guid.Empty,
               jeux.Nom,
               jeux.Description,
               jeux.AgeMax,
               jeux.AgeMin,
               jeux.NbJoueurMax,
               jeux.NbJoueurMin,
               jeux.DureeMinute,
               DateTime.Now
                );  
        }

        //public static JeuxEditForm ToEditForm(this Jeux jeux)
        //{ if (jeux is null) throw new ArgumentNullException(nameof(jeux));
        //    return new JeuxEditForm()
        //    {
                
        //    }
        //}
        //public static JeuxDelete ToDelete (this Jeux jeux)
        //{
        //    if( jeux is null ) throw new ArgumentNullException (nameof(jeux));
        //    return new JeuxDelete(

        //        );
        //}

        public static EmpruntListItem10 ToListEmprunt10 (this Emprunt emprunt)
        {
            if (emprunt is null ) throw new ArgumentNullException (nameof(Emprunt));
            return new EmpruntListItem10()
            {
                EmpruntId = emprunt.EmpruntId,
                PreteurId = emprunt.PreteurId,
                EmprunteurId = emprunt.EmprenteurId,
                JeuId = emprunt.JeuId,
                EvaluationPreteur = emprunt.EvaluationPreteur,
                EvaluationEmpruteur = emprunt.EvaluationEmprunteur
            };
        }
        
        public static Emprunt ToBLL (this EmpruntCreateForm emprunt)
        {
            if ( emprunt is null ) throw new ArgumentNullException(nameof(Emprunt));
            return new Emprunt(
                Guid.Empty,
                DateTime.Now ,
                emprunt.DateRetour,
                null,
                null,
                emprunt.PreteurId,
                emprunt.EmprenteurId,
                emprunt.JeuId
                );
        }
    }
}
