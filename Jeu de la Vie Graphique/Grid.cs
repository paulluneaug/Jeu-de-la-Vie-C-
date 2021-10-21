using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Grid
{
	private int _n { get; set; } //Number of cells per row and per column
	public Cell[,] TabCells; //2 dimensional array that stores all the cells 
	public Grid(int nbCells, List<Coords> aliveCellsCoords)
	{
		this._n = nbCells;
		this.TabCells = new Cell[this._n, this._n];
		//Creates all the cells and check if they are alive or not
		for (int i = 0; i < _n; i++)
        {
			for (int j = 0; j < _n; j++)
			{
				bool found = false;
				for (int c = 0; c < aliveCellsCoords.Count && !found; c++)
				{
					found = aliveCellsCoords[c].ToString() == new Coords(i,j).ToString();
				}
				TabCells[i, j] = new Cell(found);
			}
		}
	}
	public int GetNbAliveNeighboor(int i, int j)
	{
		return GetCoordsNeighboorAlive(i, j).Count;
	}

	public List<Coords> GetCoordsNeighboor(int i, int j)
	{
		List<Coords> coordsNeighboor = new List<Coords>();
		for (int x = -1; x <= 1; x++)
        {
			for (int y = -1; y <= 1; y++)
			{
				if (!(x == 0 && y == 0))
                {
					int xCell = i + x, yCell = j + y;
					if (0 <= xCell && xCell < _n && 0 <= yCell && yCell < _n)
					{
						coordsNeighboor.Add(new Coords(xCell, yCell));
					}
                }
			}
		}
		return coordsNeighboor;
	}

	public List<Coords> GetCoordsNeighboorAlive(int i, int j)
	{
		List<Coords> coordsNeighboor = GetCoordsNeighboor(i, j);
		List<Coords> coordsNeighboorAlive = new List<Coords>();
		foreach (Coords c in coordsNeighboor)
        {
			if (TabCells[c.X, c.Y].IsAlive)
            {
				coordsNeighboorAlive.Add(c);
            }
		}
		return coordsNeighboorAlive;
	}
	public void DisplayGrid()
	{
		//Displays the grid and all the cells
		string sep = "+";
		string line;
		sep += String.Concat(Enumerable.Repeat("---+",_n));
		for (int y = 0; y < _n; y++)
        {
			line = "|";
			for (int x = 0; x < _n; x++)
            {
				string cell = TabCells[x, y].IsAlive ? "███" : "   ";
				line += $"{cell}|";
            }

			Console.WriteLine(sep);
			Console.WriteLine(line);
		}
		Console.WriteLine(sep);
	}
	public void UpdateGrid()
	{
		//Updates the grid by killing the cells that are surrounded by more than 3 cells or less than 2 and giving birth to cells that are surrounded by 3 cells
		DisplayGrid();
		int nbAliveNeighboor;
		for (int y = 0; y < _n; y++)
		{
			for (int x = 0; x < _n; x++)
			{
				nbAliveNeighboor = GetNbAliveNeighboor(x, y);
				if (nbAliveNeighboor == 3) { TabCells[x, y].ComeAlive(); }
				else if (nbAliveNeighboor < 2 || nbAliveNeighboor > 3) { TabCells[x, y].PassAway(); }
			}
		}
		foreach(Cell c in TabCells)
        {
			c.Update();
        }


	}
}
