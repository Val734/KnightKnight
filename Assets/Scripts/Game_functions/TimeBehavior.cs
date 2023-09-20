using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeBehavior : MonoBehaviour
{
    private float time;
    public float initialTime;
    public bool countDown;
    public UnityEvent<float> OnTime;
    public UnityEvent OnTimeOut;
    private bool dead; 
    // Start is called before the first frame update
    void Start()
    {
        time = initialTime;
        OnTime.Invoke(time);

    }

    public void StopTime()
    {
        time = 0;
        dead=true;
        
    }
    public void RestartTime()
    {
        time = initialTime;
        dead=false; 
        OnTime.Invoke(time);
    }
    // Update is called once per frame
    void Update()
    {
        if(dead==false)
        {
            Debug.Log("sfsdfg");
            if (countDown)
            {
                time -= Time.deltaTime;
                if (time <=0)
                {
                    OnTimeOut.Invoke();
                    StopTime();
                }
            }
            else
                time += Time.deltaTime;
                OnTime.Invoke(time); 
        }

    }
}
