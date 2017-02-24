using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour 
{
	private Camera mainCamera;
	float canvasDistance = 10;

	void Awake () 
	{
		mainCamera = Camera.main;
	}

	void Update () 
	{
		transform.LookAt(mainCamera.transform.position);
		transform.Rotate(0, 180, 0);
		transform.position = Vector3.Lerp(transform.position, mainCamera.transform.position + mainCamera.transform.rotation * Vector3.forward * canvasDistance, 0.2f);
	}

	void ResetPosition()
	{
		transform.position = Vector3.zero;
		gameObject.SetActive(false);
	}
}
