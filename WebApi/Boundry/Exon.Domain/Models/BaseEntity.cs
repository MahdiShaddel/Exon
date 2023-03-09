using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exon.Domain.Models
{
    public class BaseEntity<Tkey>
    {
        public Tkey Id { get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime ModifedDate { get; set; }
    }
}
