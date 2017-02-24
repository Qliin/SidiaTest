using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour 
{
	private static Color[] possibleColors = {Color.green, Color.red, Color.black, Color.blue, Color.cyan, Color.gray, Color.magenta};

	private Rigidbody a_Rigidbody;
	private Transform spawner;
	private GameObject gameManager;
	private MeshRenderer lv_Renderer;
	private MaterialPropertyBlock lv_PropBlock;
	private float moveSpeed = 1000;

	void Awake () 
	{

		lv_Renderer = GetComponent<MeshRenderer>();

		a_Rigidbody = GetComponent<Rigidbody>();
		spawner = GameObject.FindWithTag("Spawner").transform;
		gameManager = GameObject.FindWithTag("GM");
	}	

	void FixedUpdate () 
	{
		a_Rigidbody.velocity = new Vector3(-moveSpeed * Time.deltaTime, a_Rigidbody.velocity.y, a_Rigidbody.velocity.z);
	}

	void Initialize(Transform lane)
	{
		transform.position = lane.position;
		transform.rotation = lane.rotation;

		//Set a different color
		lv_PropBlock = new MaterialPropertyBlock();

		lv_Renderer.GetPropertyBlock(lv_PropBlock);
		lv_PropBlock.SetColor("_Color", possibleColors[Random.Range(0, possibleColors.Length)]);
		lv_Renderer.SetPropertyBlock(lv_PropBlock);
	}

	void OnCollisionEnter(Collision coll)
	{	
		if(coll.gameObject.tag == "Ship")
		{
			coll.gameObject.SendMessage("OnGameOver");
			gameManager.SendMessage("OnGameOver");
		}

		transform.position = spawner.position;
		a_Rigidbody.velocity = Vector3.zero;
		gameObject.SetActive(false);
	}
}
