using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior1 : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.TryGetComponent<HealthBehavior>(out HealthBehavior h))
            h.Hurt(damage);
    }
}
