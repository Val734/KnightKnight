using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehavior : MonoBehaviour
//{
//    [SerializeField]
//    private float maxhealth;
//
//    [SerializeField]
//    private float health;
//
//    public UnityEvent<float> OnChangeHealth;
//    public UnityEvent OnDie;
//
//
//    private void Start()
//    {
//        health = maxhealth;
//        OnChangeHealth.Invoke(health);
//    }
//
//
//    public float GetMaxHealth()
//    {
//        return maxhealth;
//    }
//
//    public float GetCurrenthealth()
//    {
//        return health;
//    }
//
//    public void Hurt(float damage)
//    {
//        health -= damage;
//        if (health <= 0)
//            OnDie.Invoke();
//        OnChangeHealth.Invoke(health);
//    }
//
//    public void Heal(int heal)
//    {
//        health += heal;
//        if (health > maxhealth)
//            health = maxhealth;
//        OnChangeHealth.Invoke(health);
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////anadir
//using UnityEngine.Events;
//
//
//
//public class HealthBehaviorScript : MonoBehaviour
{
    public UnityEvent OnDie;//Evento
    public UnityEvent<float> OnChangeHealth;//Evento
    public float CurrentHealth;
    public float MaxHealth;

    public AudioSource audioSource;
    public AudioClip hurt;

    private void OnEnable()

    {
        CurrentHealth=MaxHealth;
        OnChangeHealth.Invoke(CurrentHealth);


    }

    public void Heal(float health)
        {
            CurrentHealth+=health;
            if(CurrentHealth>MaxHealth)
            {
                CurrentHealth=MaxHealth;
            }
        OnChangeHealth.Invoke(CurrentHealth);       
        }
    public void Hurt(float damage)
        {
            CurrentHealth-=damage;    
            if(CurrentHealth<=0)
            {
                OnDie.Invoke();//Avisar de que llega a 0
                CurrentHealth=0;
            }
        OnChangeHealth.Invoke(CurrentHealth);

            if (audioSource != null && hurt != null)
            {
                audioSource.PlayOneShot(hurt);
            }
        }
    public float GetHealth()
    {
        return CurrentHealth;
    }
}

