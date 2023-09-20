using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody2D>(out _rb))//hayq ue poner rigibody 2D
            _rb = null;
    }
    public void Move(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Move(Vector3 dir, float speed)
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void MoveForward(float speed)
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
///////////////////////////////////////////////////////////////////////////////////////
    public void MoveRB(Vector3 dir, float speed)
    {
        if (_rb)
            _rb.velocity = dir * speed;
    }

    public void MoveRB(Vector3 dir)
    {
        //hay que manterner la velocidad de Y 
        if (_rb)
           // dir.y= _rb.velocity.y; // con esto hacemos que la velocidad en y nos deje la que ya tiene por defecto en la gravedad
           _rb.velocity=new Vector3(dir.x *speed,_rb.velocity.y,dir.z*speed);////moverte derecha o izquierda respetando la velocidad de caida, 
            //la Y no hay que multiplicarla por la velocidad en cambio la X y la Z si
    }
    
    public void StopMovement()//hacemos que la velocidad sea 0 
    {
        if (_rb)
        {
            _rb.velocity=new Vector3(0, _rb.velocity.y, 0);
        }
    }

    public void Jump(float jumpSpeed)//le pasamos el parametro de la velocidad de salto; 
    {
        if(_rb) //saltamos usando el riggibody
        {
            _rb.AddForce(new Vector2(0, jumpSpeed));
            //le añadimos fuerza hacia arriba, con new vector saltamos con el riggibody añade una fuerza que queremos hacia arriba. 
        }
    }
}
