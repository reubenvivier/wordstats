using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;
using System.Collections;
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int wordCount(string input)
        {

            int count = input.Split(' ').Count();

            return count;


        }

        private int charCount(string input)
        {

            int length = input.Replace(" ", "").Length;

            return length;

        }

        private int charspaceCount(string input)
        {

            int length = input.Length;

            return length;

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox2.AppendText("Word count: ");

            richTextBox3.Clear();
            richTextBox3.AppendText("Char count: ");

            richTextBox4.Clear();
            richTextBox4.AppendText("Length count: ");

            int Wrdcount = wordCount(richTextBox1.Text);

            string wordcount = Convert.ToString(Wrdcount);
            richTextBox2.AppendText(wordcount);


            int Chrcount = charCount(richTextBox1.Text);

            string Charcount = Convert.ToString(Chrcount);
            richTextBox3.AppendText(Charcount);

            int Spacecount = charspaceCount(richTextBox1.Text);

            string Spccount = Convert.ToString(Spacecount);
            richTextBox4.AppendText(Spccount);
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            string untrimmedWords = "";
            string trimmedWords = "";
            //listBox1.DataSource = File.ReadAllLines(@" C:\Users\Reuben-Laptop\Desktop\dt text\basewrd1.txt");
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\Reuben-Laptop\Desktop\BNC_COCA_25000", "*.txt"))
            {
                string words = File.ReadAllText(file);
                untrimmedWords += words.ToString();
            }

            untrimmedWords = Regex.Replace(untrimmedWords, " 0", "");
            trimmedWords = untrimmedWords.Replace("\t", "").Replace("\r", "");//.Replace("\n","");
            List <string> trimmedWordList = new List<string>();
            trimmedWordList = trimmedWords.Split('\n').ToList<string>();
            

            

            listBox1.DataSource = trimmedWordList;

        }
    }
}