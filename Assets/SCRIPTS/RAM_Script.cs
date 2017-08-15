using UnityEngine;
using System.Collections;

public class RAM_Script : MonoBehaviour {
	public Material blue;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().materials [0] = blue;
	
		GetComponent<Renderer>().materials[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
		GetComponent<Renderer>().materials[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
		GetComponent<Renderer>().materials[0].SetInt("_ZWrite", 1);
		GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHATEST_ON");
		GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHABLEND_ON");
		GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
		GetComponent<Renderer>().materials[0].renderQueue = -1;
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col)
	{

		if (col.transform.tag == "RAM") 
		{
			Debug.Log("HARD!!!");

			Material[] Mats = col.gameObject.GetComponent<Renderer> ().materials;
			Mats[0].SetFloat("_Mode", 0);
			Mats[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			Mats[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			Mats[0].SetInt("_ZWrite", 1);
			Mats[0].DisableKeyword("_ALPHATEST_ON");
			Mats[0].DisableKeyword("_ALPHABLEND_ON");
			Mats[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
			Mats[0].renderQueue = -1;





			GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().RAMInstalled = true;
			GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff();
			Destroy (gameObject);
		}

	}
}
