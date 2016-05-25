using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevZa.Entity
{
    [Table("AllSequences")]
    public class AllSequences
    {
        [Key]
        public string SeqName { get; set; }

        public int Seed { get; set; }

        public int Incr { get; set; }

        public int Currval { get; set; }

        public AllSequences()
        {
            Seed = 1;
            Incr = 1;
            Currval = 0;
        }

        public AllSequences(string seqName):this()
        {
            this.SeqName = seqName;
        }

        public AllSequences(string seqName, int seed, int incr, int currval):this(seqName)
        {
            this.Seed = seed;
            this.Incr = incr;
            this.Currval = currval;
        }
    }
}
