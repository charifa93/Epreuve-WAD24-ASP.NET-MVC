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
        }

    }
}
