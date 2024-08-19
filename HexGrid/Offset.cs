namespace Barbar.HexGrid;

public struct Offset
{
	internal readonly int Value;

	private Offset(int value)
	{
		Value = value;
	}

	public static readonly Offset Even = new(1);
	public static readonly Offset Odd = new(-1);
}