﻿using System;
using System.IO;
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
            int mouseX = (int)(e.X / cellSize), mouseY = (int)(e.Y / cellSize);
            Console.WriteLine("{0}, {1}", mouseX, mouseY);
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
        
        private void FindPatterns(object sender, EventArgs e)
        {
            string filepath = $@"..\..\..\Game of Life Pattern Identifier\TXTPatterns";
            DirectoryInfo d = new DirectoryInfo(filepath);

            this.PatternsComboBox.Items.Clear();
            Console.WriteLine("Seeking");
            Console.WriteLine(d.FullName);
            foreach (var file in d.GetFiles("*.txt"))
            {
                Console.WriteLine(file.Name);
                this.PatternsComboBox.Items.Add(file.Name.Replace(".txt",""));
            }
        }

        private void GetPatternToPlace(object sender, EventArgs e)
        {
            int x, y;
            if (System.IO.File.Exists($@"..\..\..\Game of Life Pattern Identifier\TXTPatterns\{this.PatternsComboBox.SelectedItem}.txt"))
            {
                if (this.CenterPatternBox.Checked)
                {
                    int patternX = 0;
                    string[] lines = System.IO.File.ReadAllLines($@"..\..\..\Game of Life Pattern Identifier\TXTPatterns\{this.PatternsComboBox.SelectedItem}.txt");
                    foreach (string line in lines)
                    {
                        patternX = Math.Max(patternX, line.Length);
                    }
                    x = (int)((this.n - patternX) / 2);
                    y = (int)((this.n - lines.Length) / 2);
                }
                else
                {
                    x = (int) CustomXPattern.Value;
                    y = (int) CustomYPattern.Value;
                }
                PlacePattern((string)this.PatternsComboBox.SelectedItem, x, y);
            }
        }
        private void PlacePattern(string patternName, int x, int y)
        {

            string[] lines = System.IO.File.ReadAllLines($@"..\..\..\Game of Life Pattern Identifier\TXTPatterns\{patternName}.txt");
            int nbLines = lines.Length;
            int xCell, yCell;

            for (int j = 0; j < nbLines; j++)
            {
                int linesLength = lines[j].Length;
                for (int i = 0; i < linesLength; i++)
                {
                    xCell = x + i; yCell = y + j;
                    if (0 <= xCell && xCell < this.n && 0 <= yCell && yCell < this.n)
                    {
                        if (lines[j][i] == '0')
                        {
                            game.grid.TabCells[xCell, yCell].ComeAlive();
                        }
                        else
                        {
                            game.grid.TabCells[xCell, yCell].PassAway();
                        }
                        game.grid.TabCells[xCell, yCell].Update();
                    }
                    
                }
            }
            this.CanvasBox.Refresh();
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

        private void CenterPatternBox_Clicked(object sender, EventArgs e)
        {
            this.CustomXPattern.Enabled = !this.CenterPatternBox.Checked;
            this.CustomYPattern.Enabled = !this.CenterPatternBox.Checked;
            
            
        }
    }
}
