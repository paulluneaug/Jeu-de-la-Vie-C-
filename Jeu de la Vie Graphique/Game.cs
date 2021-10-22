using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

public class Game
{
	private int n;
	private int iter;
	public Grid grid;
	private readonly List<Coords> AliveCellsCoords;
	public Game(int nbCells)
	{
		this.n = nbCells; //Number of cells per row and per column
		this.AliveCellsCoords = new List<Coords>(); // Coordinates of the cells, alive at the beginning
		List<(int, int)> AliveCells = new List<(int, int)>() //List of the coordinates of the cells used to create a glider gun
		{ (0,5),(0,6),(1,5),(1,6),(10,5),(10,6),(10,7),(11,4),(11,8),(12,3),(12,9),(13,3),(13,9),(14,6),(15,4),(15,8),(16,5),(16,6),(16,7),(17,6),(20,3),(20,4),(20,5),(21,3),(21,4),(21,5),(22,2),(22,6),(24,1),(24,2),(24,6),(24,7),(34,3),(34,4),(35,3),(35,4)};
		
		foreach ((int, int) coor in AliveCells)
        {
			AliveCellsCoords.Add(new Coords(coor.Item1, coor.Item2));
        }


		grid = new Grid(this.n, this.AliveCellsCoords);
	}
	public Game(int nbCells, int nbIterations) : this (nbCells)
	{
		this.iter = nbIterations; //Number of iterations before stopping the simulation
	}
	public void RunGameConsole()
    {
		for (int i = 0; i < iter; i++)
		{
			grid.UpdateGrid();
			Thread.Sleep(40);
        }
	}
	public void PaintGrid(Graphics g)
	{
		SolidBrush whiteBrush = new SolidBrush(Color.White);
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (grid.TabCells[i, j].IsAlive)
				{
					g.FillRectangle(whiteBrush, j * 5, i * 5, 5, 5);
				}
			}
		}
	}
}
