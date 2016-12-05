using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace DES
{
    public partial class Form1 : Form
    {        
        string cypher;
        int NrSubKeys = 2;
        public List<int[]> Subkeys;
        Algorithm a;
        public Form1()
        {
            InitializeComponent();
            a = new Algorithm();
        }
        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            listBox1.Items.Clear();
            cypher = Convert.ToString(textBox1.Text);
            if (checkBox1.Checked)
            {
                GivenPermutations.arrayKey = a.BinMessageToArray((Convert.ToString(textBox2.Text)));
            }
            else
            {
                GivenPermutations.arrayKey = a.BinMessageToArray(a.StringToBinary(Convert.ToString(textBox2.Text)));
            }
            Subkeys = a.InitializeSubKeys(GivenPermutations.arrayPC1, GivenPermutations.arrayPC2, GivenPermutations.arrayKey, NrSubKeys);
            foreach (int[] key in Subkeys)
            {
                a.DisplayArray(key, "Subkey" + Subkeys.IndexOf(key), listBox1);
            }
            textBox3.Text = a.EncryptOrDecrypt(cypher, false, Subkeys);
            Subkeys = null;
            textBox1.Text = "";
        }
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            cypher = Convert.ToString(textBox3.Text);
            if (checkBox1.Checked)
            {
                GivenPermutations.arrayKey = a.BinMessageToArray((Convert.ToString(textBox2.Text)));
            }
            else
            {
                GivenPermutations.arrayKey = a.BinMessageToArray(a.StringToBinary(Convert.ToString(textBox2.Text)));
            }
            Subkeys = a.InitializeSubKeys(GivenPermutations.arrayPC1, GivenPermutations.arrayPC2, GivenPermutations.arrayKey, NrSubKeys);
            cypher = (a.EncryptOrDecrypt(cypher, true, Subkeys));
            if (cypher.IndexOf("0") == cypher.Length - 1)
            {
                listBox1.Items.Add("Message: " + cypher.Remove(cypher.Length - 1));
            }
            else
            {
                listBox1.Items.Add("Message: " + cypher);
            }
            Subkeys = null;
        }
        private void btn_convert_Click(object sender, EventArgs e)
        {
            if (radio_string.Checked)
            {
                text_bin.Text = a.StringToBinary(text_string.Text);
            }
            else if (radio_bin.Checked)
            {
                text_bin.Text = a.BinaryToString(text_string.Text);
            }
        }     
    }
}
