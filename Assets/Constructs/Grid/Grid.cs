using UnityEngine;
using System;
using System.Collections.Generic;

//==================================================
// Writen by Joshua Morgan - 9/19/2013
//
// A grid is a collection of cells that is ordered from top left to bottom right 
// x being the horizontal space and y being vertical
// - A grid should be immutable once
// - The grid class should be overridden by a specific type of grid that has its own functions for 
//=================================================
public abstract class Grid
{
	public List<List<Cell>> cells { private set; get; }
	
	public Grid()
	{
		cells = BuildGrid();
		foreach(List<Cell> rows in cells)
		{
			foreach(Cell cell in rows)
			{
				cell.initializeNeighbors(this);
			}
		}
	}
	
	public abstract List<List<Cell>> BuildGrid();
	
	public Cell GetCell(Point loc)
	{
		return cells[loc.x][loc.y];
	}
}