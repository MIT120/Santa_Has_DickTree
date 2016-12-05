using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    public class GivenPermutations
    {
       /// All the given arrays (IP,IP1,E,P,PC1,PC2,S1,S2), an array for the rezult of the function F, and an array for the key(random/input).
       ///                                          1  2  3   4  5  6   7   8  9  10  11 12 13 14 15  16
        public static int[] arrayIP= new int[16] { 10, 6, 16, 2, 8, 14, 12, 4, 1, 11, 7, 9, 5, 13, 3, 15 };
        public static int[] arrayIP1 = new int[16] { 9, 4, 15, 8, 13, 2, 11, 5, 12, 1, 10, 7, 14, 6, 16, 3 };
        public static int[] arrayE = new int[12] { 8, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 1 };
        public static int[] arrayP= new int[8] { 6, 4, 7, 3, 5, 1, 8, 2 };
        public static int[] arrayPC1 = new int[14] { 12, 5, 14, 1, 10, 2, 6, 9, 15, 4, 13, 7, 11, 3 };
        public static int[] arrayPC2 = new int[12] { 6, 11, 4, 8, 13, 3, 12, 5, 1, 10, 2, 9 };
        public static int[] arrayFunction = new int[12];
        public static int[] arrayKey = new int[16];
        public static int[,] arrayS1 = new int[4, 16]
            {
                {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8}, 
                {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1}, 
                {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7}, 
                {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
            };
        public static int[,] arrayS2 = new int[4, 16]
            {
                {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15}, 
                {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9}, 
                {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4}, 
                {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
            };
    }
}
