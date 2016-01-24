using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public abstract class TextDownload : MonoBehaviour {
	public static string url="https://libraryofbabel.info/book.cgi"; //url of web

	//regexp to parse html document
	private static string regexp="<div class = \"bookrealign\" id = \"real\"><PRE id = \"textblock\">[a-z.,\\s]*<\\/PRE><\\/div>";
	private static string titleregex="<\\/form><H3>[a-z,]*<\\/H3>";


	private IEnumerator GetPage2 (BookPosition book) {
		string url = generateUrl(book);
		WWW www = new WWW(url);
		yield return www;
		string text=TextDownload.ParsePage(www.text);
		OnPage (text);
	}

	private IEnumerator GetTitle2 (BookPosition book) {
		book.page = 1;
		string url = TextDownload.generateUrl(book);
		WWW www = new WWW(url);
		yield return www;
		string text=TextDownload.ParseTitle(www.text);
		OnTitle (text);
	}
	protected void GetPage(BookPosition book){
		StartCoroutine(GetPage2 (book));
	}
	protected void GetTitle(BookPosition book){
		StartCoroutine(GetTitle2 (book));
	}

	protected abstract void OnPage (string page);
	protected abstract void OnTitle (string title);



	private static string ParsePage(string html){
		string text;
		Regex regex = new Regex (regexp);
		Match res = regex.Match (html);
		text = res.Groups [0].Value;
		text=Regex.Replace(text,"<div class = \"bookrealign\" id = \"real\"><PRE id = \"textblock\">\n","");
		text=Regex.Replace(text,"</PRE></div>","");
		return text;
	}
	private static string ParseTitle(string html){
		Regex regex = new Regex (titleregex);
		Match res = regex.Match (html);
		string title = res.Groups [0].Value;
		title = Regex.Replace (title, "</form><H3>", "");
		title = Regex.Replace (title, "</H3>", "");
		return title;
	}
	private static string generateUrl(BookPosition book){
		string fullUrl = url + "?" + book.room + "-w" + book.wall + "-s" + book.shelf + "-v" + book.volume + ":" + book.page;
		return fullUrl;
	}

}

[System.Serializable]
public struct BookPosition{
	public string room;
	public int wall;
	public int shelf;
	public int volume;
	public int page;
}
