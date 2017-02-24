using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour 
{
	private Camera mainCamera;
	private Vector3 r_OrigScale;

	void Awake () 
	{
		mainCamera = Camera.main;
		r_OrigScale = transform.localScale;
	}
	

	void Update () 
	{
		RaycastHit hit;
		float distance;
		if(Physics.Raycast(new Ray(mainCamera.transform.position, mainCamera.transform.rotation * Vector3.forward), out hit))
		{
			distance = hit.distance;
		}
		else
		{
			distance = mainCamera.farClipPlane;
		}

		transform.LookAt(mainCamera.transform.position);
		transform.Rotate(0, 180, 0);
		transform.position = Vector3.Lerp(transform.position, mainCamera.transform.position + mainCamera.transform.rotation * Vector3.forward * distance, 0.9f);

		transform.localScale = r_OrigScale * distance;
	}
}
