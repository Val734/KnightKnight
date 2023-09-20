using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementBehavior _mvb; //con el _ sabes que es privado
    private Vector3 dir; 

    //neceitamos acceder al state que está dentro del animator, por lo tanto: 
    private Animator _anim;// a partir de aquí hacemos el get component

    private SpriteRenderer _spr; 
//cambiamos el sprite con el sprite renderer porque es un componente hacer el get component, 

    public float jumpSpeed; 

    public LayerMask groundLayer; 
    /// esto de arriba lo que hace es SI

    public bool grounded;//para que salga si toca el suelo o no

    private float lifes;
    //private bool flip; 
        //public GameObject respawn; 
        public Transform player_spawn; 

        public GameObject cam; 
        private HealthBehavior _hb;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        _mvb = GetComponent<MovementBehavior>(); 
        _anim=GetComponent<Animator>(); //aqui pillamos el get component del animator
        _spr= GetComponent<SpriteRenderer>(); 
        _hb = GetComponent<HealthBehavior>();
        //_anim.SetInteger("State", 0);  

       // healthBehavior.OnDie.AddListener(OnPlayerDeath);
        //transform.position = player_spawn.position;


    }


       // _hb= GetComponent<HealthBehavior>(); 
        //flip=false;
    
    

    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"),0,0);//sistema antiguo de unity 
        //pillas el eje horizontal que esta formado por las teclas que hacen que vaya de izq a der
        //me devuelve un valor entre -1 y 1, -1 indica la izq y 1 la derecha
        //está hecho que automaticamente el horizontal este definido por la A y la D no tienes que configurar nada
        //estamos poniendo 0 en la y y la gravedad afecta entonces la física afecta al suelo
        //como la y vale 0 yla y cambia * la gravedad pues claro cae mal con la gravedad mala 
        //la solución es conservar la gravedad en Y 
//////////////////////////////////////////////////////////////////////////////////////////////////
//_spr.flipX=true; //o false; si mi collider no es simétrico al girarlo no gira el collider 

//la forma buena es esta:  PARA GIRAR TODO, ESCALAR EL PJ PONIENDO UN -1 EN TODDOOO
//transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        if(Input.GetKeyDown(KeyCode.Space) && grounded==true )//si salto y estoy tocando el suelo salto sino no
        {
            //transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z); esto es para hacer el giro
            //flip=false;
            _mvb.Jump(jumpSpeed);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////
        //if(Input.GetKeyDown(KeyCode.W) )
        //{
        //    _mvb.Jump(jumpSpeed);
        //}
//
        if(Input.GetKeyDown(KeyCode.D))
        {
           //transform.localScale = new Vector3(1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _spr.flipX= false; 
        
        }
        if(Input.GetKeyDown(KeyCode.A) )
        {
            _spr.flipX= true; 
            //transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (!Input.anyKey)
        {
            _mvb.StopMovement();
            _anim.SetInteger("State", 0);//cuando paro de moverme=0
            //nuestro state es un integer que recibe 2 parámetros 
            //1--> nombre de la varible (state), 2--> el valor que querramos darle que hemos configurado en el animator 
        }
        if (dir.x != 0)//dir.x porque solo afecta la X 
        {
            _anim.SetInteger("State", 1);
        }  
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetInteger("State",2);
        }
       //if(_hb.GetHealth()==0)
       //{
       //    _anim.SetInteger("State",3);
       //}
 ///////////////////////////////////////////////////////////////////////////////////////////////////////
         //el rayo lko lanzamos desde el updarte con la función physics y cast es lanzar.
         //tiene un punto de origen en que dirección hay que distancia y tamaño y copn que capa comprobamos la colision
         //se lanza desde el player por eso el transfom.position, la dirección es hacia abajo por eso el vector2.down
         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f/*rayo*/, groundLayer); //ponerlo en 0.1
         //para no poner el new vector2(0,1) todo el rato ponemos el vector2.down
         //devuelve el raycast hit 2d y decimos que eso puede que sea algo o que el rayo no colisione con nada por eso pondremos: 

        if(hit)//si hay colision entonces tocamos el suelo
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
         
    }

    private void FixedUpdate()//funcion que se ejecuta automáticamente pero controla el tema de las físicas
    {
        _mvb.MoveRB(dir);//move.Rb recibe 2 parametros; la dirección de movimiento y la speed
    }

    public void Player_Hit()
    {
        lifes = _hb.GetHealth();

            if(lifes > 0)
            {
                 _anim.SetTrigger("hit");
                 
            }
        
    }
   //public void Respawn()
   //{
   //    GameObject player = GameObject.Find("respawn"); 
   //    player.transform.position = respawn.transform.position;
   //}
    public void StartPlayer()
    {
        GameObject currentLevel = GameObject.FindGameObjectWithTag("CurrentLevel");
        transform.position = player_spawn.transform.position;
        Camera.main.transform.SetPositionAndRotation(currentLevel.transform.position, currentLevel.transform.rotation);

        //ponerle la camara al player 
    }
}
