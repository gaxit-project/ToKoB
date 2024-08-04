using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreResult : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    private int CoinCount;
    public bool OneCount;
    public int CoinInBox=10;

    public void CoinDrop()
    {
        ResultText.text = "Your Score is " + CoinTouch.CoinCount.ToString();
    }

    IEnumerator CoinPopCoroutine()
    {
        
        GameObject obj = (GameObject)Resources.Load("ResultCoin");
        Instantiate(obj, new Vector3(0.0f, 5, 0.0f), Quaternion.identity);


   
        yield return new WaitForSeconds(1f);

     
        OneCount = true;
        CoinInBox = CoinInBox - 1;
      

    }

    // Start is called before the first frame update
    void Start()
    {
        CoinInBox = CoinTouch.CoinCount;
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*while (CoinInBox > 0)
        {
            StartCoroutine("CoinPopCoroutine");
        }*/
        if(CoinInBox > 0 && OneCount)
        {
            OneCount = false;
            StartCoroutine("CoinPopCoroutine");
        }
        else if(CoinInBox == 0)
        {
            CoinDrop();
        }
    }
}
