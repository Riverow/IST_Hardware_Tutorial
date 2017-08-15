using UnityEngine;
using System.Collections;

public class Camera_Controls : MonoBehaviour {
	public float M_Speed;
	public float L_Speed;

	float X_mouse = 5.0f;
	float Y_mouse = 5.0f;
	// Update is called once per frame
	void Update () {

		//Controls
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float z = Input.GetAxis ("Forward");
		X_mouse += Input.GetAxis ("Mouse X") * L_Speed;
		Y_mouse += Input.GetAxis ("Mouse Y") * -1 * L_Speed;

		//Move
		transform.Translate (new Vector3 (h, v, z) * M_Speed * Time.deltaTime);

		//Look Rotation
		transform.eulerAngles = new Vector3 (Y_mouse, X_mouse, transform.rotation.z);
	} 
}
