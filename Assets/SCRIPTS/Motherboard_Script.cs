using UnityEngine;
using System.Collections;

public class Motherboard_Script : MonoBehaviour {

	public Material blue;
	public Material Motherboard;
	public Material Ports;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().materials [0] = blue;
		GetComponent<Renderer> ().materials [1] = Ports;
		GetComponent<Renderer> ().materials [2] = Motherboard;

        GetComponent<Renderer>().materials[2].SetFloat("_Mode", 0);
        GetComponent<Renderer>().materials[2].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        GetComponent<Renderer>().materials[2].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        GetComponent<Renderer>().materials[2].SetInt("_ZWrite", 1);
        GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHATEST_ON");
        GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHABLEND_ON");
        GetComponent<Renderer>().materials[2].DisableKeyword("_ALPHAPREMULTIPLY_ON");
        GetComponent<Renderer>().materials[2].renderQueue = -1;
        GetComponent<Renderer>().materials[1].SetFloat("_Mode", 0);
        GetComponent<Renderer>().materials[1].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        GetComponent<Renderer>().materials[1].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        GetComponent<Renderer>().materials[1].SetInt("_ZWrite", 1);
        GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHATEST_ON");
        GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHABLEND_ON");
        GetComponent<Renderer>().materials[1].DisableKeyword("_ALPHAPREMULTIPLY_ON");
        GetComponent<Renderer>().materials[1].renderQueue = -1; GetComponent<Renderer>().materials[2].SetFloat("_Mode", 0);
        GetComponent<Renderer>().materials[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        GetComponent<Renderer>().materials[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        GetComponent<Renderer>().materials[0].SetInt("_ZWrite", 1);
        GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHATEST_ON");
        GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHABLEND_ON");
        GetComponent<Renderer>().materials[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
        GetComponent<Renderer>().materials[0].renderQueue = -1;
    }

	// Update is called once per frame
	void LateUpdate () {

		if (GetComponent<Renderer> ().materials [0].color == Color.white) 
		{
			GetComponent<Renderer> ().materials [0].color = new Color (0f, 0.15f, 1f, 1f);
		}

	}

	void OnCollisionEnter (Collision col)
    {

		if (col.transform.tag == "Motherboard") 
		{
			Debug.Log("MOTHERBOARD!!!");

			Material[] Mats = col.gameObject.GetComponent<Renderer> ().materials;
			Mats[0].SetFloat("_Mode", 0);
			Mats[0].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			Mats[0].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			Mats[0].SetInt("_ZWrite", 1);
			Mats[0].DisableKeyword("_ALPHATEST_ON");
			Mats[0].DisableKeyword("_ALPHABLEND_ON");
			Mats[0].DisableKeyword("_ALPHAPREMULTIPLY_ON");
			Mats[0].renderQueue = -1;

			Mats[1].SetFloat("_Mode", 0);
			Mats[1].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			Mats[1].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			Mats[1].SetInt("_ZWrite", 1);
			Mats[1].DisableKeyword("_ALPHATEST_ON");
			Mats[1].DisableKeyword("_ALPHABLEND_ON");
			Mats[1].DisableKeyword("_ALPHAPREMULTIPLY_ON");
			Mats[1].renderQueue = -1;

			Mats[2].SetFloat("_Mode", 0);
			Mats[2].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			Mats[2].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			Mats[2].SetInt("_ZWrite", 1);
			Mats[2].DisableKeyword("_ALPHATEST_ON");
			Mats[2].DisableKeyword("_ALPHABLEND_ON");
			Mats[2].DisableKeyword("_ALPHAPREMULTIPLY_ON");
			Mats[2].renderQueue = -1;

			GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().MotherboardInstalled = true;
			GameObject.Find ("GameManager").GetComponent<ObjectiveManager> ().PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff();
			Destroy (gameObject);
		}

    }

}
