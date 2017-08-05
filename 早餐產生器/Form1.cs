using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 早餐產生器
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            breakfast Random = new breakfast();
            Random.LoadMenu();
            textBox1.Text = Random.a;
            textBox2.Text = Random.b;
            textBox3.Text = Random.c;
        }

    }

    class breakfast : Form1
    {
        List<string> maincourse = new List<string>();
        List<string> Thismeal = new List<string>();
        List<string> Drink = new List<string>();

        public string a = null;
        public string b = null;
        public string c = null;

        private void OpenLoad()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, Encoding.Default);

                string line_Step1 = file.ReadToEnd();

                segmentation_CRLF(line_Step1, maincourse, Thismeal, Drink);
            }

        }
        private void segmentation_CRLF(String menu, List<string> maincourse, List<string> Thismeal, List<string> Drink)
        {
            int i = 0, j = 0, k = 0;
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = menu.Split(stringSeparators, StringSplitOptions.None);
            foreach (string s in lines)
            {
                if (s == "")
                {
                    continue;
                }
                else if (s == "##主餐##")
                {
                    i = 1;
                    j = 0;
                    k = 0;
                    continue;
                }
                else if (s == "##副餐##")
                {
                    i = 0;
                    j = 1;
                    k = 0;
                    continue;
                }
                else if (s == "##飲料##")
                {
                    i = 0;
                    j = 0;
                    k = 1;
                    continue;
                }


                if (i == 1)
                { maincourse.Add(s); }
                else if (j == 1)
                { Thismeal.Add(s); }
                else if (k == 1)
                { Drink.Add(s); }

            }
        }

        private void Randommenu()
        {
            Random rnd = new Random();
            a = maincourse[rnd.Next(maincourse.Count)].ToString();
            b = Thismeal[rnd.Next(Thismeal.Count)].ToString();
            c = Drink[rnd.Next(Drink.Count)].ToString();

            return;
        }
        
        public void LoadMenu()
        {
            OpenLoad();

            Randommenu();

            return;
        }


    }
}