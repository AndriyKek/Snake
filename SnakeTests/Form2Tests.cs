using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Snake.Tests
{
    [TestClass()]
    public class Form2Tests
    {
        //[TestMethod()]
        //public void button1_ClickTest()
        //{
        //    //arrange
        //    int expected = 1 ;            
        //    //act
        //    Form2 c = new Form2();
        //    c.Show();
            

        //    int result = c.k;
        //    Assert.AreEqual(expected,result);



        //    //assert

        //}

        [TestMethod()]
        public void SnakeDeath()
        {
            //arrange
            Form1 form = new Form1();
            string expected = "snake eaten";
            form.Score = 1;
            form.snake = new PictureBox[400];
            form.snake[0] = new PictureBox();
            form.snake[1] = new PictureBox();

            //act

            form.snake[0].Location = new Point(521, 481);
            form.snake[1].Location = new Point(521, 481);
            
            //assert
            Assert.AreEqual(form._eatSnake(), expected);
        }
    }
}