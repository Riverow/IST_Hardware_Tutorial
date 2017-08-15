using UnityEngine;
using System.Collections;

public class Computer_Place_Objective : MonoBehaviour {

	bool Tabled;

	void OnCollisionEnter (Collision collision)
	{
		if (Tabled == false) {
			if (collision.gameObject.tag == "Table") {

				//transform.SetParent(collision.transform);

				GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().ComputerCasePlaced = true;
				Tabled = true;
			}

		}
	}

}
