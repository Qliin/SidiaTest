using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour 
{
	ShipInput s_Input;
	Rigidbody s_Rigidbody;
	Animator s_Animator;
	public GameObject shipExplosion;

	float s_MoveSpeed = 10;
	Vector3 targetScale = Vector3.one;

	void Awake () 
	{
		s_Rigidbody = GetComponent<Rigidbody>();
		s_Input = GetComponent<ShipInput>();
		s_Animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		s_Rigidbody.velocity = new Vector3(0, s_Rigidbody.velocity.y, s_MoveSpeed * s_Input.MoveDirection);
	}

	void Update () 
	{
		transform.LookAt(Camera.main.transform);
		transform.Rotate(0, 180, 0);
		s_Animator.SetFloat("velocityZ", s_Rigidbody.velocity.z);

		//Shrink when hit
		transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
	}

	void OnGameOver()
	{
		targetScale = Vector3.zero;
		Instantiate(shipExplosion, transform.position, Quaternion.identity);
		StartCoroutine(WaitAndDisable());
	}

	IEnumerator WaitAndDisable()
	{
		yield return new WaitForSeconds(2);
		gameObject.SetActive(false);
	}
}
