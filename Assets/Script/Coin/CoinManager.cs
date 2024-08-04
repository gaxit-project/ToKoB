using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public CoinScript target; // CoinScript 型に修正

    public TextMeshProUGUI CountCoinText;

    private int CoinCount;
    public bool OneCount;

    // Start is called before the first frame update
    void Start()
    {
        OneCount = true;
    }

    void OnDisable()
    {
        if (target != null)
        {
            target.OnDestroyed.RemoveAllListeners();
        }
    }

    void OnEnable()
    {
        if (target != null)
        {
            target.OnDestroyed.AddListener(() => {
                if (OneCount)
                {
                    HowMuchCoin();
                }
            });
        }
    }

    public void HowMuchCoin()
    {
        OneCount = false;                                                                              
        CoinCount++;                                                                                       
        Debug.Log(CoinCount);
        CountCoinText.text = "Score : " + CoinCount.ToString();
        StartCoroutine(ReCoinCountCoroutine());
    }

    IEnumerator ReCoinCountCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        OneCount = true;
    }
}
