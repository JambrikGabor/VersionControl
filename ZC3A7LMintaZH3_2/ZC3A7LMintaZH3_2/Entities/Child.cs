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
            Regex r = new Regex("^[ÁÉŐÚÖÜÓŰÍA-Z]{1}[áéöőüűóúía-z]{0,40}\\s[ÁÉŐÚÖÜÓŰÍA-Z]{1}[áéöőüűóúía-z]{0,40}$");

            //bool isLowLetter = false, isCaptialLetter = false, isNumber = false;
            //for (int i = 0; i < name.Length; i++)
            //{
            //    if (Char.IsLower(name[i])) isLowLetter = true;
            //    if (Char.IsUpper(name[i])) isCaptialLetter = true;
            //    if (Char.IsDigit(name[i])) isNumber = true;
            //}

            return r.IsMatch(name); //&& isLowLetter && isCaptialLetter && isNumber;

            //if (r.IsMatch(name))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

        }
    }
}
