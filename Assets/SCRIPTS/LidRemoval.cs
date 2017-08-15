using UnityEngine;
using System.Collections;

public class LidRemoval : MonoBehaviour {
	public Transform LidLocation;
	public bool Delidding;
	float DeLidTime;
	// Use this for initialization
	void Start () {
		


	}

	void Update ()
	{


	}

	// Update is called once per frame
	void LateUpdate () 
	{


		if (Delidding == false) 
		{
			transform.position = LidLocation.position;
			transform.rotation = LidLocation.rotation;
		}
		if (Delidding == true)
		{
			DeLidTime += 6 * Time.deltaTime;
			if (DeLidTime <= 1) {
				transform.Translate (Vector3.right * 2 * Time.deltaTime);


			}
			Destroy (gameObject, 0.5f);
		}
	}
	void OnDestroy ()
	{
		GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().M_InstallingMotherboard();
	}

	public void DeLid ()
	{
		Delidding = true;

	}
}