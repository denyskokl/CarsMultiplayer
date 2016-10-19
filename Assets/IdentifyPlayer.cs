using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class IdentifyPlayer : NetworkBehaviour {

	[SyncVar]
	public string pname = "player";

	[SyncVar]
	public Color playerColor = Color.white;
	public int a1 = 50;
	public int a2 = 3;

	void OnGUI()
	{
		if (isLocalPlayer) 
		{
			pname = GUI.TextField (new Rect (25, Screen.height - 40, 100, 30), pname);
			if (GUI.Button (new Rect (130, Screen.height - 40, 80, 30), "Change")) 
			{
				CmdChangeName (pname);
			}
		}

	}

	[Command]
	public void CmdChangeName (string newName)
	{
		pname = newName;
		this.GetComponentInChildren<TextMesh> ().text = pname;
	}

	// Use this for initialization
	void Start () 
	{
		if (isLocalPlayer) 
		{
			GetComponent<Drive> ().enabled = true;
			Camera.main.transform.position = this.transform.position - this.transform.forward * a1 + this.transform.up * a2;
			Camera.main.transform.LookAt (this.transform.position);
			Camera.main.transform.parent = this.transform;
		}
		Renderer[] rends = GetComponentsInChildren<Renderer> ();
		foreach (Renderer item in rends) 
			item.material.color = playerColor;

		this.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
	}

	void Update()
	{
			this.GetComponentInChildren<TextMesh> ().text = pname;
	}
	

}
