using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    internal class Organism
    {

        private Genome genomeTrait;
        public Genome GenomeTrait
        {
            get { return genomeTrait; }
            set { genomeTrait = value; }
        }

        public Organism()
        {
            this.GenomeTrait = new Genome();
        }

    }
}
