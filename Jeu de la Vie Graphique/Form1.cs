using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeu_de_la_Vie_Graphique
{
    public partial class Form1 : Form
    {
        private Game game;
        public int n;
        public int cellSize;
        private Timer MainTimer;
        private Random rnd;
        public Form1(int n)
        {
            this.n = n;
            this.cellSize = 4;
            this.game = new Game(this.n, this.cellSize);
            InitializeComponent(this.n);

            this.MainTimer = new Timer();
            this.MainTimer.Interval = (20);
            this.MainTimer.Tick += new EventHandler(MyTimer_Tick);
            this.rnd = new Random();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            game.grid.UpdateGrid();
            Refresh();
        }
        private void CanvasBox_Paint(object sender, PaintEventArgs e)
        {
            game.PaintGrid(e.Graphics);
        }
        private void CanvasBox_Move(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                CanvasBox_Click(sender, e);
            }
        }
        private void CanvasBox_Click(object sender, MouseEventArgs e)
        {
            int mouseX = (int)(e.Y / cellSize), mouseY = (int)(e.X / cellSize);
            if (0 <= mouseX && mouseX < this.n && 0 <= mouseY && mouseY < this.n)
            {
                Cell cell = game.grid.TabCells[mouseX, mouseY];
                if (e.Button == MouseButtons.Left)
                {
                    cell.ComeAlive();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    cell.PassAway();
                }
                cell.Update();
                CanvasBox.Refresh();
            }
        }
        private void PlayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)(sender)).Checked)
            {
                this.MainTimer.Start();
            }
            else
            {
                this.MainTimer.Stop();
            }
        }

        private void RandCellButton_Click(object sender, EventArgs e)
        {
            PlaceRandomCells((float) this.ProbaAlive.Value / 100);
        }

        private void PlaceRandomCells(float probaAlive)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rnd.NextDouble() < probaAlive)
                    {
                        game.grid.TabCells[i, j].ComeAlive();
                        game.grid.TabCells[i, j].Update();

                    }
                }
            }
            this.CanvasBox.Refresh();
        }

        private void ClearCanvas(object sender, EventArgs e)
        {
            foreach(Cell c in game.grid.TabCells)
            {
                c.PassAway();
                c.Update();
            }
            CanvasBox.Refresh();
        }

        private void placeSquare(object sender, EventArgs e)
        {
            int x0 = 59, y0 = 59;
            int squareX = 80, squareY = 80;

            for (int i = x0; i < squareX + x0; i++)
            {
                for (int j = y0; j < squareY + y0; j++)
                {
                    game.grid.TabCells[i, j].ComeAlive();
                    game.grid.TabCells[i, j].Update();

                }
            }
            this.CanvasBox.Refresh();
        }
    }
}
