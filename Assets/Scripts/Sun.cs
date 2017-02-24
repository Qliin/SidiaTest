using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour 
{
	Material sun_Material;
	Color originalColor;
	Color intenseColor = new Color(188 / 255.0f, 121/ 255.0f, 121/ 255.0f, 255/ 255.0f);
	private float speed = 0.5f;

	void Awake () 
	{
		sun_Material = GetComponent<MeshRenderer>().material;
		originalColor = sun_Material.GetColor("_Color");
	}

	void Update () 
	{
		float t = Mathf.Sin((Time.time * speed) + 1) / 2;

		Color currColor = Color.Lerp(originalColor, intenseColor, t);
		sun_Material.SetColor("_Color", currColor);
	}
}
