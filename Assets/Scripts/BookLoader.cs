using UnityEngine;
using System.Collections;

public class BookLoader : TextDownload {
	public BookPosition book;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		GetPage (book);
		GetTitle (book);
	}
	
	// Update is called once per frame
	void Update () {
	
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
