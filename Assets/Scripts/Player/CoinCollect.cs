using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CoinCollect : MonoBehaviour
{
    public UnityEvent OnGetCoin;
    public GameObject coin; 

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        coin.gameObject.GetComponent<DestroyBehavior>().DisableObject();
        OnGetCoin.Invoke(); 
    }
}


