using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	private float turnSpeed_Touch = 1;
	//private float turnSpeed_Cam = 1;
	private Vector3 camRotation = Vector3.zero;
	private Vector2 lastTouchPos;
	private Vector2 currTouchPos;

	float Round2F(float num)
	{
		return Mathf.Round(num * 100) / 100f;
	}

	void Update () 
	{	
		//FOR MOUSE	
		//Vector3 camRotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * turnSpeed_Cam;

		//MOBILE WITH FINGER INPUT
		if(Input.touchCount > 0)
		{			
			Touch currTouch = Input.touches[0];
			currTouchPos = new Vector2(-currTouch.position.y, currTouch.position.x);

			if(currTouch.phase == TouchPhase.Began)
			{
				lastTouchPos = currTouchPos;
			}
			else if(currTouch.phase == TouchPhase.Ended || currTouch.phase == TouchPhase.Canceled)
			{
				lastTouchPos = Vector2.zero;
				currTouchPos = Vector2.zero;
			}
		}

		camRotation = currTouchPos - lastTouchPos;
		camRotation = new Vector2(Mathf.Clamp(camRotation.x, -1, 1), Mathf.Clamp(camRotation.y, -1, 1));

		lastTouchPos = currTouchPos;

		transform.Rotate(camRotation*turnSpeed_Touch);
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
	}
}
