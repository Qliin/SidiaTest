using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour 
{
	private Material[] r_Materials = new Material[5];
	private float scrollSpeed = 0.1f;
	private float sideScrollSpeed = 2f;

	void Awake () 
	{		
		MeshRenderer[] r_Renderers = GetComponentsInChildren<MeshRenderer>();

		int i = 0;
		foreach(MeshRenderer r_renderer in r_Renderers)
		{
			r_Materials[i] = r_renderer.material;
			i++;
		}
	}

	void Update ()
	{
		float roadOffsetX = Mathf.Repeat(Time.time * scrollSpeed, 1);
		float roadSideOffsetX = Mathf.Repeat(Time.time * sideScrollSpeed, 1);

		//Road
		r_Materials[0].mainTextureOffset = new Vector2(-roadOffsetX, 0);

		//Both sides
		r_Materials[1].mainTextureOffset = new Vector2(-roadSideOffsetX, 0);
		r_Materials[3].mainTextureOffset = new Vector2(-roadSideOffsetX, 0);
	}
}
