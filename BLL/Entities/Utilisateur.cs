using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{ 
    public class Utilisateur
    {
        public Guid UtilisateurId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public DateTime DateCreation { get; set; }

        private DateTime? _dateDesactivation;
        public bool DateDesactivation
        {
            get { return _dateDesactivation is not null; }
        }
        private List<Jeux> _jeux;
        public Jeux[] Jeux{ 
            get { return _jeux.ToArray(); }
        }

        public Utilisateur( Guid utilisateurId ,string pseudo , string email, string motdepasse , DateTime dateCreation , DateTime? dateDesactivation) : this (email,pseudo,motdepasse)
        {
            UtilisateurId = utilisateurId;
            DateCreation = dateCreation;
            _dateDesactivation = dateDesactivation;
        }
        public Utilisateur(string email,string pseudo ,string motdepasse) : this(email , pseudo)
        {
            MotDePasse = motdepasse;
        }
        public Utilisateur(string email, string pseudo)
        {
            Email = email;
            Pseudo = pseudo;
            //_jeux = new List<Jeux>();
        }
        public Utilisateur (string pseudo)
        {
            Pseudo = pseudo;

        }
        

        //public void AjouterJeu(string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute)
        //{
        //    Jeux jeu = new Jeux(Guid.NewGuid(), nom, description, ageMin, ageMax, nbJoueurMin, nbJoueurMax, dureeMinute, DateTime.Now);
        //    _jeux.Add(jeu);
        //}
        //public void SetJeux(IEnumerable<Jeux> jeux)
        //{
        //    if (jeux is null || jeux.Contains(null)) throw new ArgumentNullException(nameof(jeux));
        //    _jeux = new List<Jeux>(jeux);
        //}


    }
}
