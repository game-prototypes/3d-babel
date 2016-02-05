using UnityEngine;
using System.Collections;

public class BookShelf : TextDownload {
	
	void Start () {
	
	}
	
	void Interaction(){
		Debug.Log ("Interaction");
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
	}
	
	protected override void OnTitle (string title)
	{
		Debug.Log ("On Title:" + title);
	}
}
