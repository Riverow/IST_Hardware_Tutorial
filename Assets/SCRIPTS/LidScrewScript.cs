using UnityEngine;
using System.Collections;

public class LidScrewScript : MonoBehaviour {
	public Transform ScrewLocation;
	public bool Unscrew;
	float unscrewtime;
	// Use this for initialization
	void Start () {
		transform.SetParent(null);

	
	}

	void Update ()
	{
		if (Unscrew == true) 
		{
			
			unscrewtime += 6 * Time.deltaTime;
			if (unscrewtime <= 1) 
			{
				transform.Translate (Vector3.forward * 1 * Time.deltaTime);
				transform.Rotate (Vector3.right * 2 * Time.deltaTime);

			}
			Destroy (gameObject, 0.5f);
		}
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		
		Debug.Log ("Screw!!!!");
		if (Unscrew == false) 
		{
			transform.position = ScrewLocation.position;
			transform.rotation = ScrewLocation.rotation;
		}
	}
	void OnDestroy ()
	{
		GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().Screws += 1;
	}
}
