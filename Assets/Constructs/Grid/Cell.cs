using System;
using UnityEngine;

//===========================================
// Written By: Joshua Morgan 9/19/2013
//
// A Cell is a component of a grid
// A Cell has 4 neighbors which is how you transverse the grid
// Cells are immutable data sets with mutable tiles
// 
// TODO:
// ---? - how will tiles find where other tiles are? good question,
// 	 == Cells are going to have to hold onto tiles.
// ???? - is cell an overideable component?
// ???? - should cells contain the grid?
// ---? - what about edge cells
//   == Cells are going to track if they are an edge and which edge they are
//      this can be done by checking null on neighbors as they are initialized.
//===========================================
public class Cell
{
	private Tile _tile;
	public Tile tile { get { return _tile; } set { _tile = value; _tile.cell = this; } }
	
	public Point location { private set; get; }
	
	public Cell up { private set; get; }
	public Cell down { private set; get; }
	public Cell left { private set; get; }
	public Cell right { private set; get; }
	
	public bool isTopEdge { private set; get; }
	public bool isBottomEdge { private set; get; }
	public bool isLeftEdge { private set; get; }
	public bool isRightEdge { private set; get; }
	
	public Cell (Point loc)
	{
		location = loc;
	}
	
	public void initializeNeighbors(Grid grid)
	{
		down = grid.GetCell(location + Point.up);
		up = grid.GetCell(location - Point.up);
		right = grid.GetCell(location + Point.right);
		left = grid.GetCell(location - Point.right);
		
		if(down == null) isBottomEdge = true;
		if(up == null) isTopEdge = true;
		if(right == null) isRightEdge = true;
		if(left == null) isLeftEdge = true;
	}
	
	public void swapTiles(Cell cell)
	{
		Tile oldTile = tile;
		tile = cell.tile;
		cell.tile = oldTile;
	}
}