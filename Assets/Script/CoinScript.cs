using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinScript : MonoBehaviour
{
    public UnityEvent OnDestroyed = new UnityEvent();

    // Start is called before the first frame update

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
        Debug.Log("ÉRÉCÉìälìæÅI");
        Destroy(gameObject, 0.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnDestroy();
        }
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
