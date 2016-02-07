using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CanvasController : MonoBehaviour {
	public BookShelf shelf;

	void Next(){
		shelf.NextPage ();
	}
	void Exit(){
		Text txt = this.GetComponentInChildren<Text> ();
		txt.text= "";
		this.GetComponent<Canvas> ().enabled = false;
	}
}
