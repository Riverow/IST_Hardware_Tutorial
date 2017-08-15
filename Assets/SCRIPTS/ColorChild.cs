using UnityEngine;
using System.Collections;

public class ColorChild : MonoBehaviour {

	public GameObject Case;

	void Update () 
	{
		if (Case.GetComponent<Renderer> ().material.color == Color.white) 
		{
			GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.black);
		} else 
		{
			GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.cyan);
		}

	}
}
