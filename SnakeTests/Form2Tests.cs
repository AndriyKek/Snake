using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Snake.Tests
{
    [TestClass()]
    public class Form2Tests
    {
        [TestMethod()]
        public void button1_ClickTest()
        {
            //arrange
            int expected = 0;            
            //act
            Form2 c = new Form2();
            c.Show();
            

            int result = c.k;
            Assert.AreEqual(expected,result);



            //assert

        }
    }
}