using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public  class Emprunt
    {
        public Guid EmpruntId { get; set; }
        public DateTime DateEmprunt {  get; set; }
        public DateTime? DateRetour { get; set; }
        public int? EvaluationPreteur { get; set; }
        public int? EvaluationEmprunteur { get; set; }

        private Guid? _preteurId;
        public Guid? PreteurId { get { return Preteur?.UtilisateurId ?? _preteurId; } }
        public Utilisateur? Preteur { get; private set; }


        private Guid? _emprunteurId;
        public Guid? EmprenteurId { get { return Emprunteur?.UtilisateurId ?? _emprunteurId; } }
        public Utilisateur? Emprunteur { get; private set; }

        private Guid? _jeuId;
        public Guid? JeuId{ get { return Jeux?.JeuId ?? _jeuId; } }
        public Jeux? Jeux { get; private set; }


        public Emprunt(Guid emprintId, DateTime dateEmprunt, DateTime? dateRetour, int? evaluationPreteur, int? evaluationEmprunteur, Utilisateur? preteur, Utilisateur? emprunteur, Jeux jeux)
        {
            EmpruntId = emprintId;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
            EvaluationEmprunteur = evaluationEmprunteur;
            EvaluationPreteur = evaluationPreteur;
            Preteur = preteur;
            Emprunteur = emprunteur;
            Jeux = jeux;

        }
        public Emprunt(Guid emprintId, DateTime dateEmprunt, DateTime? dateRetour, int? evaluationPreteur, int? evaluationEmprunteur, Guid? preteurId, Guid? emprunteurId, Guid? jeuId)
        {
            EmpruntId = emprintId;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
            EvaluationEmprunteur = evaluationEmprunteur;
            EvaluationPreteur = evaluationPreteur;
            _preteurId = preteurId;
            _emprunteurId = emprunteurId;
            _jeuId = jeuId;
        }

        public Emprunt(DateTime dateEmprunt, DateTime? dateRetour, int? evaluationPreteur, int? evaluationEmprunteur, Utilisateur? preteur, Utilisateur emprunteur, Jeux jeux) : this(Guid.NewGuid(), dateEmprunt, dateRetour, evaluationPreteur, evaluationEmprunteur, preteur, emprunteur, jeux)
        {}
        public Emprunt(DateTime dateEmprunt, DateTime? dateRetour, int? evaluationPreteur, int? evaluationEmprunteur, Guid? preteurId, Guid emprunteurId, Guid jeuId) : this (Guid.NewGuid(), dateEmprunt, dateRetour, evaluationPreteur, evaluationEmprunteur, preteurId,emprunteurId,jeuId)
        { }

        public void SetJeux(Jeux jeu)
        {
            if (jeu is null) throw new ArgumentNullException(nameof(jeu));
            if (JeuId is null) throw new InvalidOperationException("Pas de jeu à enregitrer.");
            Jeux = jeu;
        }

        public void SetEmprunteur(Utilisateur emprunteur)
        {
            if (emprunteur is null) throw new ArgumentNullException(nameof(emprunteur));
            if (EmprenteurId is null) throw new InvalidOperationException("Pas de Emprunteur à enregitrer.");
            Emprunteur = emprunteur;
        }

        public void SetPreteur(Utilisateur preteur)
        {
            if (preteur is null) throw new ArgumentNullException(nameof(preteur));
            if (PreteurId is null) throw new InvalidOperationException("Pas de Preteur à enregitrer.");
            Preteur = preteur;
        }





    }
}
