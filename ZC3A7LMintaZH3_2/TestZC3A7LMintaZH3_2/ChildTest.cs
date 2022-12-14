using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZC3A7LMintaZH3_2.Entities;

namespace TestZC3A7LMintaZH3_2
{
    public class ChildTest
    {
        [Test,
         TestCase(0,false),
         TestCase(100,false),
         TestCase(1,true),
         TestCase(2, true),
            TestCase(3, true),
            TestCase(4, true),
            TestCase(5, true)
        ]
        public void TestCheckBehaviour(int behaviour, bool expectedResult)
        {
            var child = new Child();

            var actualResult = child.CheckBehaviour(behaviour);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
