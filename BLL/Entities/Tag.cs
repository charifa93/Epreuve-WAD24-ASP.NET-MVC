using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Tag
    {
        
        public Guid TagId { get; set; }
        public string NomTag { get; set; }

        public Tag(Guid tagId, string nomTag)
        {
            TagId = tagId;
            NomTag = nomTag;
        }



    }
}
