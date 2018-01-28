using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : MoveController {

	public GameObject[] Point;
	private int Pos = 0;
	private bool Patrol;

	void Awake()
	{
		base.Awake ();
		base.target = Point[Pos];
		Patrol = true;
	}


	override public void UpdateMove()
	{
		
		if (Patrol && Point[Pos] != base.target) 
		{
			Patrol = false;
		}
		if (Patrol && GetDist () <= 0.5f) 
		{
			Pos = (Pos + 1) % Point.Length;
			base.SetTarget (Point[Pos]);	
		}

		base.UpdateMove ();
	}
}
