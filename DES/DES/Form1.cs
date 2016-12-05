using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// We declare a message to be read, the same message converted to bin(bin_msg) and two given parity bits.
        /// </summary>
        int[] arrayMessage;
        string message, bin_msg, key, encrypted;
        const int ParityBitOne = 8;
        const int ParityBitTwo = 16;
        const int NbrParityBits = 2;
        int NrSubKeys = 2; 
        public List<int[]> Subkeys;
        public Form1()
        {
            InitializeComponent();
            arrayMessage = new int[16];
        }
        private void b_message_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            encrypted = "";
            message = Convert.ToString(textBox1.Text);
            key = Convert.ToString(textBox2.Text);
            GivenPermutations.arrayKey = MessageToBinary(StringToBinary(key), GivenPermutations.arrayKey);
            Subkeys = InitializeSubKeys(GivenPermutations.arrayPC1, GivenPermutations.arrayPC2, GivenPermutations.arrayKey, NrSubKeys);
            Encrypt(message);                       
        }
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            encrypted = "";
            message = Convert.ToString(textBox1.Text);
            key = Convert.ToString(textBox2.Text);
            GivenPermutations.arrayKey = MessageToBinary(StringToBinary(key), GivenPermutations.arrayKey);
            Subkeys = InitializeSubKeys(GivenPermutations.arrayPC1, GivenPermutations.arrayPC2, GivenPermutations.arrayKey, NrSubKeys);
            Decrypt(message); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GivenPermutations.arrayKey = RandomizeArray(GivenPermutations.arrayKey);            
            string s = "";
            foreach (int item in GivenPermutations.arrayKey)
            {
                s += item.ToString();
            }
            label_key.Text = s;
            s = BinaryToString(s);
            textBox2.Text = s;

        }
        /// <summary>
        /// Gets the user input from the textbox
        /// Converts the string into binary string using StringToBinary()
        /// </summary>
        public int[] MessageToBinary(string message, int []arr_message)
        {           
            try
            {                
                for (int i = 0; i < message.Length; i++)
                {
                    arr_message[i] = Convert.ToInt32(Convert.ToString(message[i]));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return arr_message;      
        }
        /// <summary>
        /// This Method converts a string to a string in binary using a stringbuilder
        /// </summary>
        /// <param name="data">The string to be converted</param>
        /// <returns>returns string in binary</returns>
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (char c in data.ToCharArray())
                {
                    sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Converts a string in binary to a string in ASCII format
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
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
                    Rezult[i] = BinaryMessage[PermutationTable[i]-1];
                }                
                return Rezult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }
        /// <summary>
        /// This method should get the message array after initial permutation.
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
        public int[] FunctionF(int[] rightPart,int[] permutationTableE, int[] permutationTableP,int[,] S1, int[,] S2, int[] subkey)
        {
            try
            {               
                rightPart = Permutation(rightPart, permutationTableE);                
                rightPart = XorArrays(subkey, rightPart);
                DisplayArray(rightPart, "After Xoring each key");
                rightPart = Sbox(rightPart, S1, S2);
                DisplayArray(rightPart, "After Sbox:");
                rightPart = Permutation(rightPart, permutationTableP);
                DisplayArray(rightPart, "After permutation");
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rightPart;
        }
        /// <summary>
        /// First we remove two parity bits from our random key, then we permute the key with permutationTablePC2 (PC1).
        /// Next we split the key in firstSubKey and left arrays, then we shift them to the firstSubKey once and the combination array is permuted,
        /// resulting in key1. At last we shift the left and firstSubKey array again we permute the combination array and that is key2. 
        /// </summary>
        /// <param name="permutationTablePC1">This is PC1</param>
        /// <param name="permutationTablePC2">This is PC2</param>
        /// <param name="firstSubKey">This bool checks if the firstSubKey or the left key has to be returned</param>
        /// <returns>The left or firstSubKey 14 bit key</returns>
        public List<int[]> InitializeSubKeys(int [] permutationTablePC1,int[] permutationTablePC2, int[] key,int nrSubKeys)
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
                    key = CombineArray(arrayLeft, arrayRight);
                    subkeys.Add(Permutation(key, permutationTablePC2));
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            return subkeys;
        }
        /// <summary>
        /// Splits the array in two parts depending on the string that is passed
        /// </summary>
        /// <param name="arrSplit">array to be split</param>
        /// <param name="firstSubKey">wich part</param>
        /// <returns>Left or firstSubKey array</returns>
        public int[] SplitArray(int[] arrSplit, string leftOrRight )
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
                else if (leftOrRight =="R")
                {
                    for (int i = newArray.Length; i < arrSplit.Length; i++)
                    {
                        newArray[i - newArray.Length] = arrSplit[i];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newArray;
        }
        /// <summary>
        /// This method shifts the given array one index to the left or firstSubKey
        /// </summary>
        /// <param name="arrayToShift">array to be shifted</param>
        /// <param name="firstSubKey">which direction</param>
        /// <returns>shifted array</returns>
        public int[] ShiftArray(int[] arrayToShift, string leftOrRight)
        {
            int counter = 0;
            int[] arrayNew = new int[arrayToShift.Length-1];
            try
            {
                if (leftOrRight == "L")
                {
                    counter += 1;
                }
                else if (leftOrRight == "R")
                {
                    counter = arrayToShift.Length - 1;
                }
                for (int i = 0; i < arrayToShift.Length-1; i++)
                {
                    if (counter == arrayToShift.Length-1)
                    {
                        counter = 0;
                    }
                    arrayNew[i] = arrayToShift[counter];
                    counter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return arrayNew;
        }
        /// <summary>
        /// Combines two arrays into one
        /// </summary>
        /// <param name="arrLeft">first array</param>
        /// <param name="arrRight">second array</param>
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
                MessageBox.Show(ex.Message); 
            }
            return arrayNew;
        }
        /// <summary>
        /// Randomizes an array with fixed lenght
        /// </summary>
        /// <param name="key">array to be randomized</param>
        /// <returns></returns>
        public int[] RandomizeArray(int[] arr)
        {
            Random r = new Random();
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(0, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            return arr;
        }
        /// <summary>
        /// Xors two arrays
        /// </summary>
        /// <param name="arrayOne"></param>
        /// <param name="arrayTwo"></param>
        /// <returns>result array</returns>
        public int[] XorArrays(int[] arrayOne, int[] arrayTwo)
        {
            int[] arrayNew = new int[arrayOne.Length];
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return arrayNew;
        }
        /// <summary>
        /// Display an array
        /// </summary>
        /// <param name="key"></param>
        public void DisplayArray(int[] arr, string description)
        {
            string s = "";
            foreach (int item in arr)
            {
                s += item.ToString();
            }
            listBox1.Items.Add(description+": "+s);
        }
        /// <summary>
        /// Converts an array to a decimal value stored in a double
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double BinToDec(int[] arr )
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
        /// <param name="arr"></param>
        /// <param name="Sbox1"></param>
        /// <param name="Sbox2"></param>
        /// <returns></returns>
        public int[] Sbox(int[] arr, int[,]Sbox1, int[,]Sbox2)
        {
            int[] arrLeft = new int[arr.Length/2];
            int[] arrRight = new int[arr.Length/2];
            int[] arrayResult = new int[arr.Length];

            arrLeft = SplitArray(arr, "L");
            arrRight = SplitArray(arr, "R");
            arrLeft =  GetSboxNr(arrLeft,Sbox1);
            arrRight = GetSboxNr(arrRight, Sbox2);
            arrayResult = CombineArray(arrLeft,arrRight);
            return arrayResult ;
        }
        /// <summary>
        /// Gets the Sbox number and returns it in binary in an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sBox"></param>
        /// <returns></returns>
        public int[] GetSboxNr(int[] arr,int[,]sBox)
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
                sBoxNr = sBox[Convert.ToInt16(firstLastDecimal),Convert.ToInt16(middleDecimal)];                 
                string binary = Convert.ToString(sBoxNr, 2);
                while (binary.Length < arrayResult.Length)
                {
                    binary = "0" + binary;
                }
                arrayResult = MessageToBinary(binary, arrayResult);
                return arrayResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public void SwitchSides()
        {
            int[] arrLeft = new int[arrayMessage.Length / 2];
            int[] arrRight = new int[arrayMessage.Length / 2];
            int[] arrNewRight = new int[arrayMessage.Length / 2];
            int[] arrNewLeft = new int[arrayMessage.Length / 2];
            arrLeft = SplitArray(arrayMessage, "L");
            arrRight = SplitArray(arrayMessage, "R");
            try
            {
                foreach (int[] Subkey in Subkeys)
                {
                    arrNewRight = FunctionF(arrRight, GivenPermutations.arrayE, GivenPermutations.arrayP, GivenPermutations.arrayS1, GivenPermutations.arrayS2, Subkey);
                    arrNewRight = XorArrays(arrLeft, arrNewRight);
                    arrNewLeft = arrRight;
                    arrLeft = arrNewLeft;
                    arrRight = arrNewRight;
                }
                arrayMessage = CombineArray(arrRight, arrLeft);
                arrayMessage = Permutation(arrayMessage, GivenPermutations.arrayIP1);
                foreach (int item in arrayMessage)
                {
                    label_enc.Text += item.ToString();
                    encrypted += item.ToString();
                }
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }            
        }
        public List<string> SplitToStrings(string s)
        {
            try
            {
                List<string> allParts = new List<string>();
                if (s.Length % 2 != 0)
                {
                    s += "0";
                }
                for (int i = 0; i < s.Length / 2; i += 2)
                {
                    allParts.Add(s.Substring(i, 2));
                }
                return allParts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            return null;
        }
        public void Encrypt(string toEncrypt)
        {
            foreach (string s in SplitToStrings(toEncrypt))
            {
                bin_msg = StringToBinary(s);
                label_bin.Text = bin_msg;
                arrayMessage = MessageToBinary(bin_msg, arrayMessage);
                arrayMessage = Permutation(arrayMessage, GivenPermutations.arrayIP);
                DisplayArray(arrayMessage, "After IP");
                SwitchSides();
            }
            encrypted = BinaryToString(encrypted);
            textBox3.Text = encrypted;
        }
        public void Decrypt(string toEncrypt)
        {
            foreach (int[] subkey in Subkeys)
            {
                Array.Reverse(subkey);
            }
            foreach (string s in SplitToStrings(toEncrypt))
            {
                bin_msg = StringToBinary(s);
                label_bin.Text = bin_msg;
                arrayMessage = MessageToBinary(bin_msg, arrayMessage);
                arrayMessage = Permutation(arrayMessage, GivenPermutations.arrayIP);
                DisplayArray(arrayMessage, "After IP");
                SwitchSides();
            }
            encrypted = BinaryToString(encrypted);
            textBox3.Text = encrypted;
        }

        
    }
}
