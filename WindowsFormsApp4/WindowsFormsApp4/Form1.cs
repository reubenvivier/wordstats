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

        static class Globals
        {
            // this is the global word list
            public static List<string> trimmedWordList;
        }

        private int wordCount(string input)
        {

            // word count
            int count = input.Split(' ').Count();
            return count;

        }

        private int charCount(string input)
        {

            // character count
            int length = input.Replace(" ", "").Length;
            return length;

        }

        private int charspaceCount(string input)
        {
            // character and space count
            int length = input.Length;
            return length;

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Checks if text is entered
            string textInput = richTextBox1.Text.Replace(" ", string.Empty);
            if (textInput != string.Empty)
            {

                // Clears ands sets text in stats boxes
                richTextBox2.Clear();
                richTextBox2.AppendText("Word count: ");

                richTextBox3.Clear();
                richTextBox3.AppendText("Char count: ");

                richTextBox4.Clear();
                richTextBox4.AppendText("Length count: ");

                // Calculates word stats
                int wrdCount = wordCount(richTextBox1.Text);
                string wordcount = Convert.ToString(wrdCount);
                richTextBox2.AppendText(wordcount);

                int chrCount = charCount(richTextBox1.Text);
                string Charcount = Convert.ToString(chrCount);
                richTextBox3.AppendText(Charcount);

                int spaceCount = charspaceCount(richTextBox1.Text);
                string Spccount = Convert.ToString(spaceCount);
                richTextBox4.AppendText(Spccount);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string untrimmedWords = "";
            string trimmedWords = "";
            
            // foreach loop that gets all the words in all the files and combinds them into one
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\Reuben-Laptop\Desktop\BNC_COCA_25000", "*.txt"))
            {
                string words = File.ReadAllText(file);
                untrimmedWords += words.ToString();
            }

            // trims strings to only include words
            untrimmedWords = Regex.Replace(untrimmedWords, " 0", "");
            trimmedWords = untrimmedWords.Replace("\t", "").Replace("\r", "");

            // splits words into a list
            Globals.trimmedWordList = new List<string>();
            Globals.trimmedWordList = trimmedWords.Split('\n').ToList<string>();
           
            listBox1.DataSource = Globals.trimmedWordList;
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
        }
    }
}