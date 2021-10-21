using System;

public class Cell
{
	private bool _isAlive;
	public bool IsAlive
	{
		get { return _isAlive; }
		private set { _isAlive = value; }
	}
	private bool _nextState { get; set; }

	public Cell(bool state)
	{
		this._isAlive = state;
		this._nextState = state;
	}

	public void ComeAlive()
    {
		this._nextState = true;
    }

	public void PassAway()
    {
		this._nextState = false;
	}

	public void Update()
    {
		this._isAlive = this._nextState;
    }
}
