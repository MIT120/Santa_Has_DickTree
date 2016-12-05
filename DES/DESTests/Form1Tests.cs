using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DES.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void PermutationTest()
        {
            int[] expected = new int[16] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 };
            int[] actual = new int[16] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Form1 f = new Form1();
            actual = f.Permutation(actual, GivenPermutations.arrayIP);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
