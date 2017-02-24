using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{
	private static Color[] possibleColors = {Color.green, Color.red, Color.cyan, Color.gray, Color.magenta};

	private float secTexXOffset = 0.5f;
	private MeshRenderer pl_Renderer;
	private Material pl_Material;
	private MaterialPropertyBlock pl_PropBlock;
	public Transform sun;
	private float rotationSpeed = 30f;
	private float translationSpeed = 5f;

	void Awake () 
	{
		pl_Renderer = GetComponent<MeshRenderer>();
		pl_Material = pl_Renderer.material;
		pl_PropBlock = new MaterialPropertyBlock();

		pl_Renderer.GetPropertyBlock(pl_PropBlock);
		pl_PropBlock.SetColor("_Color", possibleColors[Random.Range(0, possibleColors.Length)]);
		pl_Renderer.SetPropertyBlock(pl_PropBlock);
	}	

	void Update () 
	{
		float secTexYOffset = Mathf.Repeat(Time.time * 0.1f, 1);
		pl_Material.SetTextureOffset("_SecondTex", new Vector2(secTexXOffset, secTexYOffset));

		//Rotate around the Sun
		transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
		transform.RotateAround(sun.transform.position, Vector3.up, translationSpeed * Time.deltaTime);
	}
}
