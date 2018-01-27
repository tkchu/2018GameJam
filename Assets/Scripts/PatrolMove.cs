using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : MoveController {

	public GameObject[] Point;
	private int Pos = 0;

	void Start()
	{
		base.Start ();
		base.target = Point[Pos];
	}


	override public void UpdateMove()
	{
		if (GetDist () <= 2f) 
		{
			Pos = (Pos + 1) % Point.Length;
			base.SetTarget (Point[Pos]);	
		}

		base.UpdateMove ();
	}
}
