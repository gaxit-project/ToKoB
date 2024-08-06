using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _textCountdown;
	public bool start=false;
    public UnityEvent CT = new UnityEvent();


    void Start()
	{
		_textCountdown.text = "";
        CT.Invoke();
        StartCoroutine(CountdownCoroutine());
	}
 
	IEnumerator CountdownCoroutine()
	{
          
		_textCountdown.text = "    3 ";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "    2 ";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "    1 ";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "   GO!";
		yield return new WaitForSeconds(1.0f);
		
 
		_textCountdown.text = "";
		start=true;
	}
}