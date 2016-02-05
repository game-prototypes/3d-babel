using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BookShelf : TextDownload {
	private GameObject canvas;
	private Canvas canvasComponent;
	void Start () {
		canvas = GameObject.Find ("Canvas");
		canvasComponent = canvas.GetComponent<Canvas> ();
	}
	
	void Interaction(){
		Debug.Log ("Interaction");
		canvasComponent.enabled = true;
		BookPosition book;
		book.room = "1";
		book.wall = 1;
		book.shelf = 1;
		book.volume = 1;
		book.page = 1;
		GetPage(book);
	}

	
	protected override void OnPage (string page)
	{
		Debug.Log ("On Page:" + page);
		Text txt = canvas.GetComponentInChildren<Text> ();
		txt.text = page;
	}
	
	protected override void OnTitle (string title)
	{
		Debug.Log ("On Title:" + title);
	}
}
