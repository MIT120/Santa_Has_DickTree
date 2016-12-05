using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Algorithm
    {
        int[] arrayMessage;
        string bin_msg, encrypted;
        public int[] BinMessageToArray(string message)
        {
            int[] arr_message = new int[message.Length];
            try
            {
                for (int i = 0; i < message.Length; i++)
                {
                    arr_message[i] = Convert.ToInt32(Convert.ToString(message[i]));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return arr_message;
        }
        public string ArrayToString(int[] arr)
        {
            string s = null;
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i].ToString();
            }
            return s;
        }
        /// <summary>
        /// This Method converts a string to a string in binary using a stringbuilder
        /// </summary>
        /// <param name="data">The string to be converted</param>
        /// <returns>returns string in binary</returns>
        public string StringToBinary(string data)
        {
            Encoding cp437 = Encoding.GetEncoding(437);
            string s = null;
            int length = data.Length;
            string[] binary = new string[length];
            byte[] arr = cp437.GetBytes(data);
            for (int i = 0; i < arr.Length; i++)
            {
                binary[i] = Convert.ToString(arr[i], 2);
                if (binary[i].Length < 8)
                {
                    string zeros = "";
                    for (int j = 0; j < (8 - binary[i].Length); j++)
                    {
                        zeros += "0";
                    }
                    binary[i] = zeros + binary[i];
                }
            }
            foreach (string item in binary)
            {
                s += item;
            }
            return s;
        }
        /// <summary>
        /// Converts a string in binary to a string in ASCII format
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string BinaryToString(string data)
        {
            Encoding cp437 = Encoding.GetEncoding(437);
            int length = data.Length / 8;
            string[] Decim = new string[length];
            byte[] arrayOfBinary = new byte[length];
            for (int i = 0; i < arrayOfBinary.Length; i++)
            {
                arrayOfBinary[i] = Convert.ToByte(data.Substring(i * 8, 8), 2);
            }
            var text = cp437.GetString(arrayOfBinary);
            return text;
        }
        /// <summary>
        /// Permutes two arrays of same or different lenght
        /// </summary>
        /// <param name="binaryMessage">  This is the binary key to be permuted</param>
        /// <param name="permutationTablePC1">This is the permutaion order</param>
        /// <returns>                 This is the permuted key (array_bin_new)</returns>
        public int[] Permutation(int[] BinaryMessage, int[] PermutationTable)
        {
            int[] Rezult = new int[PermutationTable.Length];
            try
            {
                for (int i = 0; i < PermutationTable.Length; i++)
                {
                    Rezult[i] = BinaryMessage[PermutationTable[i] - 1];
                }
                return Rezult;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// This method should get the cypher array after initial permutation.
        /// Then using the right part of that array we make another permutation with E.
        /// The result should be xored with the keys (one by one).
        /// Finaly the result of the xoring is permuted with the S-boxes.
        /// </summary>
        /// <param name="binaryMessage"></param>
        /// <param name="permutationTableE"></param>
        /// <param name="key"></param>
        /// <param name="permutationTablePC1"></param>
        /// <param name="permutationTablePC2"></param>
        /// <returns></returns>
        public int[] FunctionF(int[] rightPart, int[] permutationTableE, int[] permutationTableP, int[,] S1, int[,] S2, int[] subkey)
        {
            try
            {
                rightPart = Permutation(rightPart, permutationTableE);
                rightPart = XorArrays(subkey, rightPart);
                //DisplayArray(rightPart, "After Xoring each key");
                rightPart = Sbox(rightPart, S1, S2);
                //DisplayArray(rightPart, "After Sbox:");
                rightPart = Permutation(rightPart, permutationTableP);
                //DisplayArray(rightPart, "After permutation");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return rightPart;
        }
        /// <summary>
        /// The parity bits of the key are removed, the key is then split into two parts and shifted acordingly.
        /// The resulting combination of the parts is permuted with PC2, becoming the sub key.
        /// </summary>
        /// <param name="key">Master key</param>
        /// <param name="nrSubKeys">number of sub keys to be created</param>
        /// <returns>The list of subkeys</returns>
        public List<int[]> InitializeSubKeys(int[] permutationTablePC1, int[] permutationTablePC2, int[] key, int nrSubKeys)
        {
            List<int[]> subkeys = new List<int[]>();
            try
            {
                key = Permutation(key, permutationTablePC1);
                int[] arrayLeft = SplitArray(key, "L");
                int[] arrayRight = SplitArray(key, "R");
                while (subkeys.Count != nrSubKeys)
                {
                    arrayLeft = ShiftArray(arrayLeft, "R");
                    arrayRight = ShiftArray(arrayRight, "R");
                    arrayLeft = ShiftArray(arrayLeft, "R");
                    arrayRight = ShiftArray(arrayRight, "R");
                    subkeys.Add(Permutation(CombineArray(arrayLeft, arrayRight), permutationTablePC2));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return subkeys;
        }
        /// <summary>
        /// Splits the array in two parts depending on the string that is passed
        /// </summary>
        /// <param name="leftOrRight">"L" or "R"</param>
        public int[] SplitArray(int[] arrSplit, string leftOrRight)
        {
            int[] newArray = new int[arrSplit.Length / 2];
            try
            {
                if (leftOrRight == "L")
                {
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = arrSplit[i];
                    }
                }
                else if (leftOrRight == "R")
                {
                    for (int i = newArray.Length; i < arrSplit.Length; i++)
                    {
                        newArray[i - newArray.Length] = arrSplit[i];
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return newArray;
        }
        /// <summary>
        /// This method shifts the given array one index to the left or right
        /// </summary>
        /// <param name="leftOrRight">"L" or "R"</param>
        public int[] ShiftArray(int[] arrayToShift, string leftOrRight)
        {
            int counter = 0;
            int[] arrayNew = new int[arrayToShift.Length];
            try
            {
                if (leftOrRight == "L")
                {
                    counter = arrayToShift.Length - 1;
                }
                else if (leftOrRight == "R")
                {
                    counter += 1;
                }
                for (int i = 0; i < arrayToShift.Length; i++)
                {

                    arrayNew[i] = arrayToShift[counter];
                    counter++;
                    if (counter == arrayToShift.Length)
                    {
                        counter = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return arrayNew;
        }
        /// <summary>
        /// Combines two arrays into one
        /// </summary>
        /// <returns>arrLeft+arrRight</returns>
        public int[] CombineArray(int[] arrLeft, int[] arrRight)
        {
            int[] arrayNew = new int[arrLeft.Length + arrRight.Length];
            int counter = 0;
            try
            {
                for (int i = 0; i < arrayNew.Length; i++)
                {
                    if (i < arrLeft.Length)
                    {
                        arrayNew[i] = arrLeft[i];
                    }
                    else
                    {
                        arrayNew[i] = arrRight[counter];
                        counter++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return arrayNew;
        }
        /// <summary>
        /// Xors two arrays with the same lenght
        /// </summary>
        public int[] XorArrays(int[] arrayOne, int[] arrayTwo)
        {
            int[] arrayNew = new int[arrayOne.Length];
            try
            {
                if (arrayOne.Length == arrayTwo.Length)
                {
                    for (int i = 0; i < arrayOne.Length; i++)
                    {
                        if (arrayOne[i] == arrayTwo[i])
                        {
                            arrayNew[i] = 0;
                        }
                        else if (arrayOne[i] != arrayTwo[i])
                        {
                            arrayNew[i] = 1;
                        }
                    }
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return arrayNew;
        }
        /// <summary>
        /// Display an array with a description
        /// </summary>
        public void DisplayArray(int[] arr, string description, System.Windows.Forms.ListBox listbox)
        {
            string s = "";
            foreach (int item in arr)
            {
                s += item.ToString();
            }
            listbox.Items.Add(description + ": " + s);
        }
        /// <summary>
        /// Converts a binary array to a decimal value stored in a double
        /// </summary>
        public double BinToDec(int[] arr)
        {
            double sum = 0;
            Array.Reverse(arr);
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 1)
                    sum = sum + (Math.Pow(2, j));
            }
            return sum;
        }
        /// <summary>
        /// Returns the result of the Sboxes in a 8bit array
        /// </summary>
        public int[] Sbox(int[] arr, int[,] Sbox1, int[,] Sbox2)
        {
            int[] arrLeft = new int[arr.Length / 2];
            int[] arrRight = new int[arr.Length / 2];
            int[] arrayResult = new int[arr.Length];

            arrLeft = SplitArray(arr, "L");
            arrRight = SplitArray(arr, "R");
            arrLeft = GetSboxNr(arrLeft, Sbox1);
            arrRight = GetSboxNr(arrRight, Sbox2);
            arrayResult = CombineArray(arrLeft, arrRight);
            return arrayResult;
        }
        /// <summary>
        /// Gets the Sbox number and returns it in binary in an array
        /// </summary>
        public int[] GetSboxNr(int[] arr, int[,] sBox)
        {
            int[] arrayFirstLast = new int[2];
            int[] arrayMiddle = new int[4];
            int[] arrayResult = new int[4];
            double firstLastDecimal = 0;
            double middleDecimal = 0;
            int sBoxNr = 0;
            int counter = 0;
            int counter2 = 0;
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0 || i == arr.Length - 1)
                    {
                        arrayFirstLast[counter] = arr[i];
                        counter++;
                    }
                    else
                    {
                        arrayMiddle[counter2] = arr[i];
                        counter2++;
                    }
                }
                firstLastDecimal = BinToDec(arrayFirstLast);
                middleDecimal = BinToDec(arrayMiddle);
                sBoxNr = sBox[Convert.ToInt16(firstLastDecimal), Convert.ToInt16(middleDecimal)];
                string binary = Convert.ToString(sBoxNr, 2);
                while (binary.Length < arrayResult.Length)
                {
                    binary = "0" + binary;
                }
                arrayResult = BinMessageToArray(binary);
                return arrayResult;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Swiches the right and left side for every key
        /// </summary>
        public void SwitchSides(List<int[]> subkeys)
        {
            int[] arrLeft = new int[arrayMessage.Length / 2];
            int[] arrRight = new int[arrayMessage.Length / 2];
            int[] arrNewRight = new int[arrayMessage.Length / 2];
            int[] arrNewLeft = new int[arrayMessage.Length / 2];
            arrLeft = SplitArray(arrayMessage, "L");
            arrRight = SplitArray(arrayMessage, "R");
            try
            {
                foreach (int[] Subkey in subkeys)
                {
                    arrNewRight = FunctionF(arrRight, GivenPermutations.arrayE, GivenPermutations.arrayP, GivenPermutations.arrayS1, GivenPermutations.arrayS2, Subkey);
                    arrNewRight = XorArrays(arrLeft, arrNewRight);
                    arrNewLeft = arrRight;
                    arrLeft = arrNewLeft;
                    arrRight = arrNewRight;
                }
                arrayMessage = CombineArray(arrRight, arrLeft);
                arrayMessage = Permutation(arrayMessage, GivenPermutations.arrayIP1);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Splits a string into two characters and puts them into a list
        /// </summary>
        public List<string> SplitToStrings(string s, bool isBinary)
        {
            int nrOfChars = 2;
            try
            {
                if (isBinary == true)
                {
                    nrOfChars = 16;
                }
                List<string> allParts = new List<string>();
                if (s.Length % 2 != 0)
                {
                    s += "0";
                }
                for (int i = 0; i < s.Length; i += nrOfChars)
                {
                    allParts.Add(s.Substring(i, nrOfChars));
                }
                return allParts;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Encrypts a string
        /// </summary>
        public string EncryptOrDecrypt(string toConvert, bool decrypt, List<int[]> subkeys)
        {
            encrypted = null;
            if (decrypt == true)
            {
                subkeys.Reverse();
            }

            if (toConvert.Contains("0") || toConvert.Contains("1") && toConvert.Length > 15)
            {
                foreach (string s in SplitToStrings(toConvert, true))
                {
                    arrayMessage = Permutation(BinMessageToArray(s), GivenPermutations.arrayIP);
                    SwitchSides(subkeys);
                    encrypted += (ArrayToString(arrayMessage));
                }
            }
            else
            {
                foreach (string s in SplitToStrings(toConvert, false))
                {
                    bin_msg = StringToBinary(s);
                    arrayMessage = Permutation(BinMessageToArray(bin_msg), GivenPermutations.arrayIP);
                    SwitchSides(subkeys);
                    encrypted += BinaryToString((ArrayToString(arrayMessage)));
                }                
            }
            return encrypted;
        }
    }
}
