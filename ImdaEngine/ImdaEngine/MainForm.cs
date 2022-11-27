/*
By InnieSharp(ix4/i#)
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImdaEngine
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public const int tilesize = 32;
		public const int mapwidth = 40;
		public const int mapheight = 24;
		public Color default_background_color = Color.Black;
		public const int speed = 25; // чем меньше тем быстрее
		public int xa = 48;
		public int ya = 48;
		public int lxa = 48;
		public int lya = 48;
		public string[] map;
		public int direct;
		public bool draa;
		public int xi = 0;
		public int yi = 0;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void MainFormLoad(object sender, EventArgs e)
		{
			this.Hide();
			this.Size = new Size(tilesize * mapwidth, tilesize * mapheight);
			this.BackColor = default_background_color;
			this.Name = "ImdaEngine";
			this.ShowIcon = false;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			move.Interval = speed;
			move.Tick += Move0;
			player.Image = Image.FromFile(@"textures\player.png");
			player.Size = new Size(16, 16);
			player.Location = new Point(xa, ya);
			this.KeyDown += Move1;
			this.KeyUp += Move2;
			this.SizeGripStyle = SizeGripStyle.Hide;
			player.MouseDown += drag0;
			player.MouseMove += drag1;
			player.MouseUp += drag2;
			draa = false;
			
			this.Show();
			LoadMap(@"maps\map1.txt");
			Draw();
		}
		
		void LoadMap(string path)
		{
			map = File.ReadAllLines(path);
		}
		
		void Draw()
		{
			Dictionary<char, Image> images = new Dictionary<char, Image>()
			{
				{ '#', Image.FromFile(@"textures\wall.png") },
			    { '.', Image.FromFile(@"textures\floor.png") },
			    { ' ', Image.FromFile(@"textures\empty.png") }
			};
			Dictionary<char, string> tags = new Dictionary<char, string>()
			{
				{ '#', "wall" },
			    { '.', "floor" },
			    { ' ', "empty" }
			};
			int y = 0;
			foreach (string str in map)
			{
			    int x = 0;
			    foreach (char c in str)
			    {
			        Controls.Add(new PictureBox
			        {
			            Image = images[c],
			            Tag = c.ToString(),
			            Size = new Size(32, 32),
			            Location = new Point(x * 32, y * 32)
			        });
			        ++x;
			    }
			    ++y;
			}
		}
		
		void Move0(object sender, EventArgs e)
		{
			lxa = player.Left; lya = player.Top;
			if(direct == 1)
			{
				if(player.Left == 0)
				{
					
				}
				else
				{
					player.Left -= 1;
					xa--;
				}
			}
			if(direct == 2)
			{
				if(player.Left == tilesize * mapwidth)
				{
					
				}
				else
				{
					player.Left += 1;
					xa++;
				}
			}
			if(direct == 3)
			{
				if(player.Top == tilesize * mapheight)
				{
					
				}
				else
				{
					player.Top += 1;
					ya++;
				}
			}
			if(direct == 4)
			{
				if(player.Top == 0)
				{
					
				}
				else
				{
					player.Top -= 1;
					ya--;
				}
			}
			CollisionCheck();
		}
		
		void Move1(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.A)
			{
				direct = 1;
				move.Enabled = true;
			}
			if(e.KeyCode == Keys.D)
			{
				direct = 2;
				move.Enabled = true;
			}
			if(e.KeyCode == Keys.W)
			{
				direct = 4;
				move.Enabled = true;
			}
			if(e.KeyCode == Keys.S)
			{
				direct = 3;
				move.Enabled = true;
			}
		}
		void Move2(object sender, KeyEventArgs e)
		{
			move.Enabled = false;
		}
		
		void CollisionCheck()
		{
			foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
					if ((string)x.Tag == "#")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                        	player.Left = lxa; player.Top = lya;
                        }
                    }
                }
            }
		}
		void PosTick(object sender, EventArgs e)
		{
			int bx = player.Left / 32;
			int by = player.Top / 32;
			this.Text = "X:" + bx + " Y:" + by;
		}
		
		void drag0(object sender, MouseEventArgs e)
		{
			xi = e.X; yi = e.Y;
		}
		void drag2(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) // или любую другую, какая удобнее
		    {
		        Point pos = new Point(Cursor.Position.X - xi, Cursor.Position.Y - yi);
		        player.Location = PointToClient(pos);
		    }
		}
		void drag1(object sender, MouseEventArgs e)
		{
			
		}
	}
}
