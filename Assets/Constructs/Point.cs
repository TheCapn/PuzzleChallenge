using System;

public class Point
{
	private static Point _up = new Point(0, 1);
	public static Point up { get{ return _up; } }
	private static Point _right = new Point(1, 0);
	public static Point right { get{ return _right; } }
	
	public int x { get; private set; }
	public int y { get; private set; }
	
	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	
	public static Point operator +(Point p1, Point p2){ return new Point(p1.x + p2.x, p1.y + p2.y); }
	public static Point operator -(Point p1, Point p2){ return new Point(p1.x - p2.x, p1.y - p2.y); }
	public static Point operator *(Point p, int i){ return new Point(p.x * i, p.y * i); }
}