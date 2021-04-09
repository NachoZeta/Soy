using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Fire1-->A, Fire2-->B, Fire3-->X, Fire4-->Y, Fire5-->Gatillo izquierdo
public class Mover2 : MonoBehaviour
{

    public FixedJoystick joystick;
    public float speed;
    public float jumpForce;

    public float velocidadEscalada;

    private Animator animator;
    private Rigidbody2D rb2d;
    private float x;
    private float y;

    private bool estaEnElSuelo = false;

    public bool escalando = false;

    public float contadorSaltos;
    public float fuerzaSalto;

    public AudioSource audioSource;
    public AudioClip sonidoSalto;



    private GameObject jugador;

    private GestorPoderes gespo;

    private GameManager gameManager;





    private void Start()
    {
        gameManager = GameManager.Instance;

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //gameManager = GameManager.Instance;

    }
    void Update()
    {
        if (gameManager.IsAndroid() == false)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
        else
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }
        if (x > 0.001f) x = 1;
        if (x < -0.001f) x = -1;
        if (Mathf.Abs(x) > 0.001f)



        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }



        if (y > 0.001f) y = 1;
        if (y < -0.001f) y = 1;
        if (Mathf.Abs(y) > 0.001f)

        {
            transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
        }
        //Si el valor absoluto de x es > 0, ejecuta la animación de andar
        //(si el valor absoluto de x es = 0, para la ejecución de andar)
        if (Mathf.Abs(x) > 0.001f)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        //Saltar
        if (Input.GetButtonDown("Jump"))
        {
            Salta();
        }

        if (Mathf.Abs(y) > 0.001f)
        {

            Escala();
        }


    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Time.deltaTime * speed * x, rb2d.velocity.y);
    }
    // private void Salta()
    //{
    //  print("Saltos hechos: " + contadorSaltos);
    // if (contadorSaltos < 2)
    //{
    //  rb2d.velocity = new Vector2(rb2d.velocity.x, fuerzaSalto);
    // contadorSaltos++;
    //}
    //}

    private void Salta()
    {
        {
            GameManager gm = GameManager.Instance;
            print("Saltos Hechos:" + contadorSaltos);

            if (contadorSaltos < 1)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, fuerzaSalto);
                contadorSaltos++;
                audioSource.PlayOneShot(sonidoSalto);

            }
            else if (contadorSaltos < 2 && gm.HasItem(Item.ItemValues.DobleSalto))
            {
                print("Tengo el doble salto");
                rb2d.velocity = new Vector2(rb2d.velocity.x, fuerzaSalto);
                contadorSaltos++;
                audioSource.PlayOneShot(sonidoSalto);
            }

        }
    }

    public void Escala()
    {
        GameManager gm = GameManager.Instance;
        if (escalando && gm.HasItem(Item.ItemValues.Escalator))
        {
            //transform.Translate(new Vector2(0, 0.2f) * Time.deltaTime * velocidadEscalada);
            print("escalo true");
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(0, velocidadEscalada);
            escalando = !escalando;


            //if (Input.GetButtonUp("Fire1"))
            //{
            //  escalando = !escalando;
            //}
        }

        if (!escalando)
        {

            //rb2d.velocity = new Vector2(0, 0);
            rb2d.gravityScale = 2;


        }

    }




    private void OnTriggerStay2D(Collider2D other)
    {
        estaEnElSuelo = true;
        contadorSaltos = 0;
        if (other.CompareTag("Escalante") && Input.GetButton("Vertical"))
        {
            escalando = true;
        }

        if (other.CompareTag("Escalante") && Input.GetButtonUp("Vertical"))
        {
            escalando = false;
            Escala();
        }
        else
        {
            if (other.CompareTag("Escalante") && gameManager.IsAndroid() == true)
            {

                escalando = true;

            }
        }



    }


    private void OnTriggerExit2D(Collider2D other)
    {
        estaEnElSuelo = false;
        if (other.CompareTag("Escalante"))
        {
            escalando = false;
            Escala();
        }

    }

}
