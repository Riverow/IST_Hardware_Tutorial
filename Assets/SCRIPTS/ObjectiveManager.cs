using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{

	//Events in order

	public AudioClip[] VoiceClips;
	public AudioSource Speaker;

	public bool ComputerCasePlaced;
	public bool UnScrewable;
	public bool MotherboardInstalled;
	public bool PowerSupplyInstalled;
	public bool PlaceCPU;
	public bool HeatsinkInstalled;
	public bool RAMInstalled;
	public bool HardDriveInstalled;
	public bool GraphicAdapterCardInstalled;
	public bool DisplayConnected;

	public bool Delidable;
	public float Screws;

	public GameObject Motherboard;
	public GameObject HardDisk;
	public GameObject Ram_Stick;
	public GameObject Power_Supply;
	public GameObject CPU;
	public GameObject Heat_Sink_Fan;
	public GameObject Graphics_Card;

	public Material M_MonitorScreen;

	public Texture[] T_MonitorScreen;

	public GameObject HardwareSpawn;

	public GameObject[] Hardware;

	public GameObject PedestalSpotlight;
	public GameObject MonitorSpotlight;
	void Start () 
	{

			M_OpenIntro ();

	}

	void Update ()
	{

		if (ComputerCasePlaced == true) 
		{
			M_ComputerCasePlaced ();
		}

		if (MotherboardInstalled == true) 
		{
			M_InstallingCPU ();
			MotherboardInstalled = false;
		}

		if (PlaceCPU == true) 
		{
			M_InstallingHeatSink ();
			PlaceCPU = false;
		}

		if (HeatsinkInstalled == true) 
		{
			M_InstallingHardDisk ();
			HeatsinkInstalled = false;
		}

		if (HardDriveInstalled == true) 
		{
			M_InstallingRAM ();
			HardDriveInstalled = false;
		}

		if (RAMInstalled == true) 
		{
			M_InstallingPowerSupply ();

		}

		if (PowerSupplyInstalled == true) 
		{
			M_InstallingGraphicsCard ();
		}

		if (GraphicAdapterCardInstalled == true) 
		{
			//DONE?
			StartCoroutine(RemainingAudio());
			Debug.Log ("DONE!");
		}
	}

	void LateUpdate ()
	{
		if (Screws == 2) 
		{
			
			GameObject Lid = GameObject.FindGameObjectWithTag ("Lid");



			Lid.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.cyan);
			Lid.transform.parent = null;
			Delidable = true;
		}
	}


	IEnumerator RemainingAudio ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();
		//Controller Cards
		Speaker.clip = VoiceClips[14];
		Speaker.Play ();
		M_MonitorScreen.mainTexture = T_MonitorScreen[37];
		yield return new WaitForSeconds(16.85f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[38];
		yield return new WaitForSeconds(16.85f);

		//Expansion Slots
		Speaker.clip = VoiceClips[15];
		Speaker.Play ();
		M_MonitorScreen.mainTexture = T_MonitorScreen[41];
		yield return new WaitForSeconds(14.5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[39];
		yield return new WaitForSeconds(14.5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[40];
		yield return new WaitForSeconds(14.5f);
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();

		GameObject.Find ("Main Spotlight").SetActive (false);
		GameObject.Find ("ComputerCase").transform.position = new Vector3 (0.748f, 1.095f, -0.966f);
		GameObject.Find ("ComputerCase").transform.eulerAngles = new Vector3 (-90f, 180f, 0f);
		GameObject.Find ("Hidden End Lid").SetActive (true);
		GameObject.Find ("small Monitor").transform.position = new Vector3 (0.107f, 1.663f, -0.844f);
		GameObject.Find ("small Monitor").transform.eulerAngles = new Vector3 (-90f, 0f, -180f); 
		M_MonitorScreen.mainTexture = T_MonitorScreen[43];
		GameObject.Find ("Main Spotlight").SetActive (true);
		//Display
		Speaker.clip = VoiceClips[16];
		Speaker.Play ();
		yield return new WaitForSeconds (117);
		//Input & Output
		Speaker.clip = VoiceClips[17];
		Speaker.Play ();

	}


	//ORDER OF EVENTS

	void M_OpenIntro ()
	{

		//Play Opening Audio
		Speaker.clip = VoiceClips[0];
		Speaker.Play ();
	
		Invoke ("MonitorAppears", 8.5f);


	}

	void MonitorAppears()
	{
		
		StartCoroutine(M_MonitorSlideShow());
	
	}

	IEnumerator M_MonitorSlideShow()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();
		Speaker.clip = VoiceClips[1];
		Speaker.Play ();
		M_MonitorScreen.mainTexture = T_MonitorScreen[0];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[1];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[2];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[3];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[4];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[5];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[6];
		yield return new WaitForSeconds(1);
		M_MonitorScreen.mainTexture = T_MonitorScreen[7];
		yield return new WaitForSeconds(1.4f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[8];
		yield return new WaitForSeconds (1.5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[9];
		yield return new WaitForSeconds(2.5f);
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();

		yield return new WaitForSeconds(2.5f);
		Speaker.clip = VoiceClips[2];
		Speaker.Play ();
		yield return new WaitForSeconds(14);
		Speaker.clip = VoiceClips[3];
		Speaker.Play ();
		yield return new WaitForSeconds(4.6f);
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();
		M_MonitorScreen.mainTexture = T_MonitorScreen[10];
		Speaker.clip = VoiceClips[4];
		Speaker.Play ();
		Invoke("M_GrabbingComputerCase", 9);
	}

	void M_GrabbingComputerCase()
	{
		Speaker.clip = VoiceClips[5];
		Speaker.Play ();
		GameObject.Find ("ComputerCase").transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();

	}

	void M_ComputerCasePlaced()
	{
		
		//Play Audio Continued
		//REMOVE UNSCREW LID
		ComputerCasePlaced = false;

		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff();
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
		Speaker.clip = VoiceClips[6];
		Speaker.Play ();

		Invoke ("M_RemovingCaseLid", 5f);

	}

	void M_RemovingCaseLid ()
	{
		foreach (GameObject Screws in GameObject.FindGameObjectsWithTag("LidScrew")) 
		{
		
			Screws.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.cyan);
			UnScrewable = true;

		}

	}


	public void M_InstallingMotherboard ()
	{
		//AUDIO

		Speaker.clip = VoiceClips[7];
		Speaker.Play ();
		Motherboard.SetActive (true);
		StartCoroutine (InstallingMotherboard_SlideShow ());
		Invoke ("M_InstallingMotherboardCont", 40.4f);

	}

	IEnumerator InstallingMotherboard_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[11];
		yield return new WaitForSeconds(15f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[12];
		yield return new WaitForSeconds(10f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[11];
		yield return new WaitForSeconds(15f);

		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}

	void M_InstallingMotherboardCont ()
	{
		GameObject.Find ("G_Motherboard").transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();
	}

	void M_InstallingCPU ()
	{

		//AUDIO
		Speaker.clip = VoiceClips[8];
		Speaker.Play ();
		CPU.SetActive (true);
		StartCoroutine (InstallingCPU_SlideShow ());
		Invoke ("M_InstallingCPUCont", 53.85f);

	}

	IEnumerator InstallingCPU_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[13];
		yield return new WaitForSeconds (22f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[14];
		yield return new WaitForSeconds(8f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[15];
		yield return new WaitForSeconds(5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[16];
		yield return new WaitForSeconds(5f);

		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}


	void M_InstallingCPUCont ()
	{
		Hardware [2].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();
	}

	void M_InstallingHeatSink ()
	{
		//AUDIO
		Speaker.clip = VoiceClips[9];
		Speaker.Play ();
		Heat_Sink_Fan.SetActive (true);
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();
		M_MonitorScreen.mainTexture = T_MonitorScreen[17];

		Invoke ("M_InstallingHeatSinkCont", 12f);

	}

	void M_InstallingHeatSinkCont () 
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
		Hardware [3].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();
	}

	void M_InstallingHardDisk ()
	{
		Speaker.clip = VoiceClips[10];
		Speaker.Play ();
		HardDisk.SetActive (true);
		StartCoroutine (InstallingHDD_SlideShow ());
		Invoke ("M_InstallingHardDiskCont", 70.7f);
	}

	IEnumerator InstallingHDD_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[18];
		yield return new WaitForSeconds (15f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[19];
		yield return new WaitForSeconds(5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[21];
		yield return new WaitForSeconds(3f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[20];
		yield return new WaitForSeconds(5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[22];
		yield return new WaitForSeconds(22.5f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[23];
		yield return new WaitForSeconds(15f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[24];
		yield return new WaitForSeconds(6.5f);

		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}

	void M_InstallingHardDiskCont ()
	{
		Debug.Log ("Hard Disk Light");
		Hardware [4].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();
	}

	void M_InstallingRAM () 
	{
		Speaker.clip = VoiceClips[11];
		Speaker.Play ();
		Ram_Stick.SetActive (true);

		StartCoroutine (InstallingRAM_SlideShow ());

		Invoke ("M_InstallingRAMCont", 66.6f);
	}

	IEnumerator InstallingRAM_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[25];
		yield return new WaitForSeconds (20f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[26];
		yield return new WaitForSeconds(10f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[27];
		yield return new WaitForSeconds(25f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[28];
		yield return new WaitForSeconds(11.6f);


		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}

	void M_InstallingRAMCont ()
	{

		Hardware [5].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();

	}

	void M_InstallingPowerSupply () 
	{
		Speaker.clip = VoiceClips[12];
		Speaker.Play ();
		Power_Supply.SetActive (true);

		StartCoroutine (InstallingPower_SlideShow ());

		Invoke ("M_InstallingPowerSupplyCont", 49.3f);
	}

	IEnumerator InstallingPower_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[29];
		yield return new WaitForSeconds (10f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[30];
		yield return new WaitForSeconds(20f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[31];
		yield return new WaitForSeconds(20f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[32];
		yield return new WaitForSeconds(19.3f);

		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}

	void M_InstallingPowerSupplyCont ()
	{

		Hardware [6].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();

	}

	void M_InstallingGraphicsCard () 
	{
		Speaker.clip = VoiceClips[13];
		Speaker.Play ();
		Graphics_Card.SetActive (true);

		StartCoroutine (InstallingGraphics_SlideShow ());

		Invoke ("M_InstallingGraphicsCardCont", 47.8f);
	}

	IEnumerator InstallingGraphics_SlideShow ()
	{
		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn ();

		M_MonitorScreen.mainTexture = T_MonitorScreen[33];
		yield return new WaitForSeconds (10f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[34];
		yield return new WaitForSeconds(20f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[35];
		yield return new WaitForSeconds(20f);
		M_MonitorScreen.mainTexture = T_MonitorScreen[36];
		yield return new WaitForSeconds(17.8f);

		MonitorSpotlight.GetComponent<Flickering_Light_bulb> ().LightOff ();
	}

	void M_InstallingGraphicsCardCont ()
	{

		Hardware [7].transform.position = HardwareSpawn.transform.position;
		PedestalSpotlight.GetComponent<Flickering_Light_bulb> ().LightOn();

	}
}
