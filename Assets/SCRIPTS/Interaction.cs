using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	
	public float Reach;
	public GameObject HeldObject;
	public float RotateX;
	public float RotateY; 
	// Use this for initialization

	void Update ()
	{
		//Rotation of object controls
		RotateX = Input.GetAxisRaw ("RotateX") * 100;
		RotateY = Input.GetAxisRaw ("RotateY") * 100;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		HeldObject.transform.Rotate (-Vector3.up * RotateX * Time.deltaTime, Space.World);
		HeldObject.transform.Rotate (Vector3.right * RotateY * Time.deltaTime, Space.World);
	}	
	// Update is called once per frame
	void FixedUpdate () 
	{
	
		//Letting Object Go
		if (Input.GetMouseButtonDown (0)) 
		{
			if (HeldObject != null) 
			{
				//HeldObject.GetComponent<Rigidbody> ().isKinematic = false;
				//HeldObject.GetComponent<Rigidbody> ().useGravity = true;
				HeldObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				foreach (Material mat in HeldObject.GetComponent<Renderer> ().materials) {
					mat.SetColor ("_EmissionColor", Color.black);
					mat.color = Color.white;
				}
			
				HeldObject.transform.SetParent (null);
				HeldObject = null;
				return;
			}
		}

		//Setting object rotation
	


		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),out hit, Reach)) 
		{

			//Debug.Log (hit.transform.name);

			//Sellecting Object location in World
			if (hit.transform.gameObject != HeldObject && HeldObject != null)
			{
				HeldObject.transform.position = hit.point;
			}

	
				
			//Grabbing a Object
			if(Input.GetMouseButtonDown(0))
			{
				
				if (hit.transform.tag == "LidScrew") {
					Debug.Log ("Clicking on Screw");
					if (GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().UnScrewable == true) {
						
						hit.transform.gameObject.GetComponent<LidScrewScript> ().Unscrew = true;




					}
				}
					if (hit.transform.tag == "Lid") {

						if (GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().Delidable == true) {
							Debug.Log (hit.transform.name);
							hit.transform.gameObject.GetComponent<LidRemoval> ().DeLid();



						
						}

				}

				if (hit.transform.tag == "Hardware") 
				{
					HeldObject = hit.transform.gameObject;
					//HeldObject.GetComponent<Rigidbody> ().isKinematic = true;
					//HeldObject.GetComponent<Rigidbody> ().useGravity = false;
					HeldObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
					foreach (Material mat in HeldObject.GetComponent<Renderer> ().materials) {
						mat.SetColor ("_EmissionColor", Color.cyan);
						mat.color = Color.cyan;
					}
				
				
					HeldObject.transform.parent = transform;
				}



			}
		
		}



	}

 }