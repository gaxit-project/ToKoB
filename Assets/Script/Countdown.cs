using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
 
public class Countdown : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _textCountdown;
	public bool start=false;
 
	
	void Start()
	{
		_textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());
	}
 
	IEnumerator CountdownCoroutine()
	{
 
		_textCountdown.text = " 3 ";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = " 2 ";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = " 1 ";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);
		
 
		_textCountdown.text = "";
		start=true;
	}
}