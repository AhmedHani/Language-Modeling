using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;

namespace LanguageModeling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\ahmed_000\\Documents\\Visual Studio 2012\\Projects\\NGramsParser\\NGramsParser\\testXML.xml");
            String xmlString = doc.InnerXml;

            foreach (XmlNode child in doc.DocumentElement.ChildNodes)
            {

                if (child.NodeType == XmlNodeType.Element)
                {
                    richTextBox1.Text += child.InnerText;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load("C:\\Users\\ahmed_000\\Documents\\Visual Studio 2012\\Projects\\NGramsParser\\NGramsParser\\testHTML.html");
            richTextBox1.Text = htmlDoc.DocumentNode.InnerText;
        }
    }
}
