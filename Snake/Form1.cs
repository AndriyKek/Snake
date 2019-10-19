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
    public partial class Form1 : Form
    {
        private PictureBox[] snake = new PictureBox[400];
        private int ri,rj;
        private PictureBox fruit;     
        private int dirX;             
        private int dirY;             
        private int _width = 600;     
        private int _height = 600;    
        private int _SizeOfSize = 40;      
        private int Score=0;
        private Label labelScore;

        /// <summary>
        /// ogólne konfiguracji
        /// </summary>
        public Form1()
        {
            
            InitializeComponent();

            this.Text = "Snake";
            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(610, 10); 
            this.Controls.Add(labelScore);
            this.Width = _width;
            this.Height = _height;
            dirX = 1;
            dirY = 0;
            
            snake[0]= new PictureBox();                                                        
            snake[0].Location = new Point(201,201);                    
            snake[0].Size = new Size(_SizeOfSize-1, _SizeOfSize-1);    
            snake[0].BackColor = Color.Green;                          
            this.Controls.Add(snake[0]);                               
            
            fruit = new PictureBox();
            fruit.BackColor = Color.Red;
            fruit.Size = new Size(_SizeOfSize,_SizeOfSize);
            Map();
            _genFruit();
            timer.Tick += new EventHandler(_update);  
            timer.Interval = 200;                    
            timer.Start();
            this.KeyDown += new KeyEventHandler(OKP); 
        }

        /// <summary>
        /// ruch całej struktury węża
        /// </summary>
        private void _moveSnake()   
        {
            for (int i = Score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + dirX * (_SizeOfSize), snake[0].Location.Y + dirY * (_SizeOfSize));
            _eatSnake();
        }

        /// <summary>
        /// losowe generowanie "owocu"
        /// </summary>
        private void _genFruit()
        {
            Random r = new Random();
            ri = r.Next(0, _height - _SizeOfSize);      
            int tempi = ri % _SizeOfSize;
            ri -= tempi;

            rj = r.Next(0, _height - _SizeOfSize);
            int tempj = rj % _SizeOfSize;
            rj -= tempj;

            rj++;
            ri++;

            fruit.Location = new Point(ri, rj);      
            this.Controls.Add(fruit);
        }
        
        /// <summary>
        /// sprawdzanie granic pola zgodnie z wężem i rachunek
        /// </summary>
        private void _checkWalls()
        {
            if (snake[0].Location.X < 0)          
            {
                for (int _i = 1; _i <= Score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Score = 0;
                labelScore.Text = "Score" + Score;
                dirX = 1;   
            }
            if (snake[0].Location.X > _height)
            {
                for (int _i = 1; _i <= Score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Score = 0;
                labelScore.Text = "Score" + Score;
                dirX = -1;                                   
            }
            if (snake[0].Location.Y < 0)                    
            {
                for (int _i = 1; _i <= Score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Score = 0;
                labelScore.Text = "Score" + Score;
                dirY = 1;
            }
            if (snake[0].Location.Y > _height)
            {
                for (int _i = 1; _i <= Score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }
                Score = 0;
                labelScore.Text = "Score" + Score;
                dirY = -1;
            }

        }

        /// <summary>
        /// zakończenia gry
        /// </summary>
        private void _eatSnake()
        {
           for (int _i = 1; _i < Score; _i++)
            {
                if (snake[0].Location == snake[_i].Location)
                {
                    for (int _j = _i; _j <= Score; _j++)
                    this.Controls.Remove(snake[_j]);
                    Score = Score - (Score - _i + 1);
                   Form Form2 = new Form2();
                    Form2.Show();
                    Hide();
                    Application.Restart();                       

                }
            }
        }

        /// <summary>
        /// zbieranie "warzyw"
        /// </summary>
        private void _eatFruit()
        {
            if (snake[0].Location.X == ri && snake[0].Location.Y == rj)
            {
                labelScore.Text = "Score:" + ++Score;
                snake[Score] = new PictureBox();
                snake[Score].Location = new Point(snake[Score - 1].Location.X + 40 * dirX, snake[Score - 1].Location.Y - 40 * dirY);
                snake[Score].Size = new Size(_SizeOfSize-1, _SizeOfSize-1);
                snake[Score].BackColor= Color.Green;
                this.Controls.Add(snake[Score]);
                _genFruit();
            }
        }

        /// <summary>
        /// generowanie mapy
        /// </summary>
        private void Map()
        {
            for (int i = 0; i <= _width / _SizeOfSize; i++)               
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, _SizeOfSize * i);
                pic.Size = new Size(_width, 1);                                 
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= _height / _SizeOfSize; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point( _SizeOfSize * i,0);         
                pic.Size = new Size(1,_width );
                this.Controls.Add(pic);
            }
        }

        private void _update(Object myObject, EventArgs eventArgs)
        {
            _moveSnake();
            _eatFruit();
            _checkWalls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ruch węża
        /// </summary>
        private void OKP(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());  

            switch (e.KeyCode.ToString())
            {
                 case "D":

                    dirX = 1;   
                    dirY = 0;  
                    break;
                case "A":

                    dirX = -1;
                    dirY = 0;
                    break;
                case "W":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "S" :

                    dirY = 1;
                    dirX = 0;
                    break;
                }
        }
    }
}
