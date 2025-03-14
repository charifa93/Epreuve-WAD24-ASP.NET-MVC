using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Associer
    {

        private Guid _tagId;
        public Guid TagId { get{ return Tag?.TagId ?? _tagId; } }
        public Tag Tag { get; private set; }

        private Guid _jeuId;
        public Guid JeuId { get { return Jeux?.JeuId ?? _jeuId; } }
        public Jeux Jeux { get; private set; }

        public Associer(Guid tagId,Guid jeuId) 
        {
            _tagId = tagId;
            _jeuId = jeuId;
        }
        public Associer(Tag tag , Jeux jeux) 
        {
            Tag = tag;
            Jeux = jeux;
            _jeuId = Jeux.JeuId;
            _tagId = Tag.TagId;
        }

        public void SetJeux(Jeux jeux)
        {
            if (jeux is null) throw new ArgumentNullException(nameof(jeux));
            if (JeuId != Jeux.JeuId) throw new InvalidOperationException("Mauvais Jeu");
            Jeux = jeux;
        }

        public void SetTag(Tag Tags)
        {
            if (Tags is null) throw new ArgumentNullException(nameof(Tags));
            if (TagId != Tag.TagId) throw new InvalidOperationException("Mauvais Tag");
            Tag = Tags;
        }

    }
}
