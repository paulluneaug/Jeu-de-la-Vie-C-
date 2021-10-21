using System;

public class Coords
{
	private int _x;
	public int X 
	{ get { return _x; } }
	private int _y { get; }
    public int Y 
	{ get { return _y; } }


    public Coords(int X, int Y)
	{
		this._x = X;
		this._y = Y;
	}

	public override string ToString()
    {
		return $"{_x}/{_y}";
    }
    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Coords coord = (Coords)obj;
            return (_x == coord.X) && (_y == coord.X);
        }
    }
}
