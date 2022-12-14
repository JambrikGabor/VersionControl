using PackMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZC3A7LMintaZH3_2.Enum;

namespace ZC3A7LMintaZH3_2.Entities
{
    public class Child
    {
        public string Name { get; set; }
        public Behaviour ChildBehaviour { get; set; }

        public List<Gift> Gifts { get; set; }

        public bool CheckBehaviour(int number) 
        {
            if (number>=1 &&number<=5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
