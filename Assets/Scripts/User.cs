using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {
	//private Camera camera
	// Use this for initialization
	void Start () {
		//camera = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject obj=GetFrontObject ();
			if(obj!=null) sendAction (obj);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void sendAction(GameObject target){
		Debug.Log (target.name);
		target.SendMessageUpwards ("Interaction");
	}
	//Raycast in camera direction, returns gameobject
	GameObject GetFrontObject(){
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (transform.position, fwd, out hit,100)) {
			return hit.transform.gameObject;
		} else
			return null;
	}
}
