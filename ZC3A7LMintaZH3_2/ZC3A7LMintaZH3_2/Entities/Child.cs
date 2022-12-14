using PackMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public bool CheckName(string name) 
        {
            Regex r = new Regex("^[A-Z]{*1}"+"[a-z]{,40}"+" "+"[A-Z]{*1}"+"[a-z]{,40}$");
            if (r.IsMatch(name)==true)
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
