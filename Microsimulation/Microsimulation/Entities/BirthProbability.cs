using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsimulation.Entities
{
    class BirthProbability
    {
        public int Age { get; set; }
        public int NumberOfChildren { get; set; }
        public double ProbabilityOfBirth { get; set; }
    }
}
