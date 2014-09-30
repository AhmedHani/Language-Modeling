using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageModeling
{
    public partial class Unigram : Form
    {
        public Unigram()
        {
            InitializeComponent();
            richTextBox1.Text = LoadFile.inputFile;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Unigram_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = richTextBox1.Text.Split(' ');
            HashSet<string> allWords = new HashSet<string>();

            foreach (string i in words)
            {
                allWords.Add(i);
            }

            NGrams.Unigram uni = new NGrams.Unigram(allWords);
            uni.train();
            Dictionary<string, int> temp = uni.afterParsing();
            Dictionary<int, int> uniGramsFreq = uni.test();

            foreach (KeyValuePair<string, int> i in temp)
            {
                richTextBox2.Text += i.Key + ", " + i.Value + "\n";
            }

            foreach(KeyValuePair<int, int> i in uniGramsFreq) 
            {
                dataGridView1.Rows[0].Cells[0].Value = i.Key;
                dataGridView1.Rows[0].Cells[1].Value = i.Value;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
