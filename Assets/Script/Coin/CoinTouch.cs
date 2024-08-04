using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinTouch : MonoBehaviour
{
    public TextMeshProUGUI CountCoinText;

    public static int CoinCount;
    public bool OneCount;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            HowMuchCoin();
        }
        else if (collision.gameObject.tag == "TsujinoTest")
        {
            SceneManager.LoadScene("Clear");
        }
    }

    public void HowMuchCoin()
    {
        OneCount = false;                                                                              
        CoinCount++;                                                                                       
        Debug.Log(CoinCount);
        CountCoinText.text = "Score : " + CoinCount.ToString();
        StartCoroutine("ReCoinCountCoroutine");
    }

    IEnumerator ReCoinCountCoroutine()
    {
        
       


        yield return new WaitForSeconds(0.5f);

        
        OneCount = true;
        

    }

    // Start is called before the first frame update
    void Start()
    {
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
