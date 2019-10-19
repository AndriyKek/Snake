using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form2 : Form
    {
        public int k = 0;
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// start gry
        /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            k = 1;
            Form1 Form1 = new Form1();
            Form1.Show();
            Hide();
        }

        

        /// <summary>
        /// wyjście z gry
        /// </summary>
        public void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       
    }

}
