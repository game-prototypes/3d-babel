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
	//result text
	private string text;


			// Use this for initialization
	IEnumerator Start () {
		string url = generateUrl();
		WWW www = new WWW(url);
		yield return www;
		Parse(www.text);
		Debug.Log (text);
	}
	
	void Parse(string html){
		Regex regex = new Regex (regexp);
		Match res = regex.Match (html);
		text = res.Groups [0].Value;
		text=Regex.Replace(text,"<div class = \"bookrealign\" id = \"real\"><PRE id = \"textblock\">\n","");
		text=Regex.Replace(text,"</PRE></div>","");
	}

	string generateUrl(){
		string fullUrl = url + "?" + room + "-w" + wall + "-s" + shelve + "-v" + volume + ":" + page;
		return fullUrl;
	}
}
