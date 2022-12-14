using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZC3A7LMintaZH3_2.Entities;

namespace ZC3A7LMintaZH3_2.Entities2
{
    public class Child
    {
        public string Name { get; set; }
        public Behaviour ChildBehaviour { get; set; }

        CheckBehaviour(int number,bool bool) 
        {
            if (number<=5)
            {
                return false;
            }
        }
    }
}
