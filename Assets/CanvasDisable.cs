using UnityEngine;
using System.Collections;

public class CanvasDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Canvas> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
