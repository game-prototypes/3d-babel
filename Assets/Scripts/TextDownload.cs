/*Text Download for libraryofbabel.info
 * by Andres Ortiz Corrales 
 */


using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;


//TODO: parse also title
public class TextDownload : MonoBehaviour {
	public string url="https://libraryofbabel.info/book.cgi"; //url of web
	public string room="2";
	public int wall=4;
	public int shelve=2;
	public int volume=17;
	public int page = 1;

	//regexp to parse html document
	private string regexp="<div class = \"bookrealign\" id = \"real\"><PRE id = \"textblock\">[a-z.,\\s]*<\\/PRE><\\/div>";
	private string titleregex="<\\/form><H3>[a-z,]*<\\/H3>";
	//result text
	private string text="";
	private string title=""; //title of book (only in first page(


			// Use this for initialization
	IEnumerator Start () {
		string url = generateUrl();
		WWW www = new WWW(url);
		yield return www;
		Parse(www.text);
		Debug.Log ("Title:" + title);
		Debug.Log (text);
	}
	
	void Parse(string html){
		Regex regex = new Regex (regexp);
		Match res = regex.Match (html);
		text = res.Groups [0].Value;
		text=Regex.Replace(text,"<div class = \"bookrealign\" id = \"real\"><PRE id = \"textblock\">\n","");
		text=Regex.Replace(text,"</PRE></div>","");

		if (page == 1) {
			regex = new Regex (titleregex);
			Match res2 = regex.Match (html);
			title = res2.Groups [0].Value;
			title = Regex.Replace (title, "</form><H3>", "");
			title = Regex.Replace (title, "</H3>", "");
		}
	}

	string generateUrl(){
		string fullUrl = url + "?" + room + "-w" + wall + "-s" + shelve + "-v" + volume + ":" + page;
		return fullUrl;
	}
}
