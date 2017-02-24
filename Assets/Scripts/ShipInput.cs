using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour 
{		
	public float MoveDirection {get; private set;}

	public void MoveUp()
	{
		MoveDirection = 1;
	}

	public void MoveDown()
	{
		MoveDirection = -1;
	}

	public void Stop()
	{
		MoveDirection = 0;
	}
}
