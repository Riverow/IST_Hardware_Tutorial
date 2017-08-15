using UnityEngine;
using System.Collections;

public class Flickering_Light_bulb : MonoBehaviour {

	AudioSource FlickerSound;
	public Animator FlickerAC;

	void Start () 
	{
		FlickerSound = GetComponent<AudioSource> ();
		FlickerAC = GetComponent<Animator> ();
	}
		
	public void LightOn ()
	{

		FlickerSound.Play ();
		FlickerAC.SetBool ("Light", true);

	}

	public void LightOff ()
	{
		FlickerAC.SetBool ("Light", false);
	}

}
