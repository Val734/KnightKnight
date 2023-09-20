using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DoorBehavior : MonoBehaviour
{
    private Animator _anim;
    public UnityEvent OnOpened;
    public UnityEvent Next_level;
    //public UnityEvent Coins; 

   // private GameObject objectcoins;
   // private GameObject door2; 
    //private GameObject door3;
    public Transform next_level;

    public Transform StartPlay;
    public List<GameObject> coinCounts;
   // private int i;
   // private bool coinsdesactivated;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
       // i = 0;
        //objectcoins = GameObject.Find("coin_count1");
       // door2= GameObject.Find("coin_count2");
       // door3= GameObject.Find("coin_count3");
       // coinsdesactivated= true;
    }

    // Update is called once per frame
    void Update()
    {
        bool allCoinsDeactivated = true;

      //  while (i < door2.transform.childCount && coinsdesactivated==true)
      //  {
      //      if (door2.transform.GetChild(i).gameObject.activeInHierarchy)
      //      {
      //          coinsdesactivated= false;
      //      } 
      //      else {coinsdesactivated= true;}
      //      i++; 
      //  }
      //  if(coinsdesactivated)
      //  {
      //      _anim.SetInteger("door", 8);
      //      OnOpened.Invoke();
      //  }
      //  else
      //  {
      //      coinsdesactivated= true;
      //      i = 0;
      //  }
/////////////////////////////////////////////////////////////
      //  while (i < objectcoins.transform.childCount && coinsdesactivated==true)
      //  {
      //      if (objectcoins.transform.GetChild(i).gameObject.activeInHierarchy)
      //      {
      //          coinsdesactivated= false;
      //      } 
      //      else {coinsdesactivated= true;}
      //      i++; 
      //  }
      //  if(coinsdesactivated)
      //  {
      //      _anim.SetInteger("door", 8);
      //      OnOpened.Invoke();
      //  }
      //  else
      //  {
      //      coinsdesactivated= true;
      //      i = 0;
      //  }
//////////////////////////////////////////////////////
    //  while (i < door3.transform.childCount && coinsdesactivated==true)
    //  {
    //      if (door3.transform.GetChild(i).gameObject.activeInHierarchy)
    //      {
    //          coinsdesactivated= false;
    //      } 
    //      else {coinsdesactivated= true;}
    //      i++; 
    //  }
    //  if(coinsdesactivated)
    //  {
    //      _anim.SetInteger("door", 8);
    //      OnOpened.Invoke();
    //  }
    //  else
    //  {
    //      coinsdesactivated= true;
    //      i = 0;
    //  }

        foreach (GameObject coinCount in coinCounts)
        {
            bool coinsDeactivated = true;
            for (int i = 0; i < coinCount.transform.childCount; i++)
            {
                GameObject coin = coinCount.transform.GetChild(i).gameObject;
                if (coin.activeSelf)
                {
                    coinsDeactivated = false;
                    break;
                }
            }
            if (!coinsDeactivated)
            {
                allCoinsDeactivated = false;
                break;
            }
        }
        if (allCoinsDeactivated)
        {
            _anim.SetInteger("door", 8);
            OnOpened.Invoke();
        }

    }
///////////////////////////////////////
    public void Resetcoins(GameObject objectscoins)
    {

        foreach (GameObject coinCount in coinCounts)
        {
            for (int i = 0; i < coinCount.transform.childCount; i++)
            {
                GameObject coin = coinCount.transform.GetChild(i).gameObject;
                coin.SetActive(true);
            }
        }
        //for(int i = 0; i < objectscoins.transform.childCount;i++)
        //{
        //    GameObject son = objectscoins.transform.GetChild(i).gameObject;
//
        //    if(!son.activeSelf)
        //    {
        //        son.SetActive(true);
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            Camera.main.transform.SetPositionAndRotation(next_level.transform.position, next_level.transform.rotation);
            GameObject player = GameObject.Find("Player");
            player.transform.SetPositionAndRotation(StartPlay.transform.position, StartPlay.transform.rotation);
            Next_level.Invoke();
            //Start(); 

    }


    public void ResetDoor()
    {
        _anim.SetInteger("door",7);
        //coinsdesactivated=false; 
       // Start(); 
       Start();

    }
}