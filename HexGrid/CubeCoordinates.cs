using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Barbar.HexGrid;

public struct CubeCoordinates(int q, int r, int s)
{
	public readonly int Q = q;
	public readonly int R = r;
	public readonly int S = s;

	public override bool Equals(object obj)
	{
		Debug.Assert(obj != null, nameof(obj) + " != null");
		var another = (CubeCoordinates)obj;
		return another.Q == Q && another.R == R && another.S == S;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + Q;
			hash = hash * 23 + R;
			hash = hash * 23 + S;
			return hash;
		}
	}

	public override string ToString()
	{
		return $"[Q={Q},R={R},S={S}]";
	}

	public static CubeCoordinates operator +(CubeCoordinates a, CubeCoordinates b)
	{
		return new CubeCoordinates(a.Q + b.Q, a.R + b.R, a.S + b.S);
	}

	public static CubeCoordinates operator -(CubeCoordinates a, CubeCoordinates b)
	{
		return new CubeCoordinates(a.Q - b.Q, a.R - b.R, a.S - b.S);
	}
        
	public static CubeCoordinates operator *(CubeCoordinates a, int k)
	{
		return new CubeCoordinates(a.Q * k, a.R * k, a.S * k);
	}

	public static readonly IList<CubeCoordinates> Directions = new ReadOnlyCollection<CubeCoordinates>(new List<CubeCoordinates> { new(1, 0, -1), new(1, -1, 0), new(0, -1, 1), new(-1, 0, 1), new(-1, 1, 0), new(0, 1, -1) });

	public static CubeCoordinates Neighbor(CubeCoordinates hex, int direction)
	{
		return hex + Directions[direction];
	}

	public static readonly IList<CubeCoordinates> Diagonals = new ReadOnlyCollection<CubeCoordinates>(new List<CubeCoordinates> { new(2, -1, -1), new(1, -2, 1), new(-1, -1, 2), new(-2, 1, 1), new(-1, 2, -1), new(1, 1, -2) });

	public static CubeCoordinates DiagonalNeighbor(CubeCoordinates hex, int direction)
	{
		return hex + Diagonals[direction];
	}
	public int Length
	{
		get { return (Math.Abs(Q) + Math.Abs(R) + Math.Abs(S)) / 2; }
	}

	public static int Distance(CubeCoordinates a, CubeCoordinates b)
	{
		return (a - b).Length;
	}
}