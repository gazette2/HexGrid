using System.Diagnostics;

namespace Barbar.HexGrid;

public struct OffsetCoordinates(int column, int row)
{
	public readonly int Column = column;
	public readonly int Row = row;

	public override bool Equals(object obj)
	{
		Debug.Assert(obj != null, nameof(obj) + " != null");
		var another = (OffsetCoordinates)obj;
		return another.Column == Column && another.Row == Row;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + Column;
			hash = hash * 23 + Row;
			return hash;
		}
	}

	public override string ToString()
	{
		return $"[C={Column},R={Row}]";
	}
}