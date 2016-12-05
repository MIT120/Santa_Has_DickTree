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
        Form1 f = new Form1();
        [TestMethod()]        
        public void PermutationTest()
        {
            int[] expected = new int[8] { 1, 1, 1, 1, 1, 1, 1, 0 };
            int[] actual = new int[8] { 1, 0, 1, 1, 1, 1, 1, 1 };
            actual = f.Permutation(actual, GivenPermutations.arrayP);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShiftArrayTest()
        {
            int[] actual = new int[7] { 0, 1, 1, 1, 1, 1, 1 };
            int[] expected = new int[7] { 1, 1, 1, 1, 1, 1, 0 };
            Form1 f = new Form1();
            actual = f.ShiftArray(actual, "R");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CombineArrayTest()
        {
            int[] arr1 = new int[7] { 0, 1, 0, 1, 1, 1, 1 };
            int[] arr2 = new int[6] { 1, 1, 1, 1, 0, 1 };
            int[] expected = new int[13] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 };
            CollectionAssert.AreEqual(f.CombineArray(arr1, arr2), expected);
        }
    }
}
