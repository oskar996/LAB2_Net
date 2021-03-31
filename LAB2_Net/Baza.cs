using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LAB2_Net
{
    public class Kurs
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int PLN { get; set; }
        public int CHF { get; set; }
        public int GBP { get; set; }
        public int VES { get; set; }
    }

    public class Kantor : DbContext
    {
        public virtual DbSet<Kurs> Piniondze { get; set; }
    }
}
