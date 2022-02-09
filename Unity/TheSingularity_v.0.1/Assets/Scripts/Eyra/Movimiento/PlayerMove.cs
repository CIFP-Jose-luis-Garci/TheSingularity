using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float dashSpeed;
    public Rigidbody rb;
    public Material dash;
    public Material run;
    public Material damage;

    public float desplZ;
    public float desplX;
    public bool dashColor;
    public IAGhoul iAGhoul;
    public CharacterController controller;
    Animator animator;
    public bool atackjugador;
    float cronometro;
    // Start is called before the first frame update
    void Start()
    {
        dashColor = false;
        rb = GetComponent<Rigidbody>();
        iAGhoul = GetComponent<IAGhoul>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        atackjugador = false;
    }

    // Update is called once per frame
    public void Update()
    {

        desplX = Input.GetAxis("Vertical");
        desplZ = Input.GetAxis("Horizontal");
   
        transform.Translate(0, 0, desplX * speed * Time.deltaTime);
        transform.Translate(desplZ * speed * Time.deltaTime, 0, 0);

        if(desplX < 0)
        {
            animator.SetBool("Correr", true);
        }
        if (desplX > 0)
        {
            animator.SetBool("Correr", true);
        }
        if (desplX == 0)
        {
            animator.SetBool("Correr", false);
        }
        if (desplX == 0)
        {
            animator.SetBool("Correr", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Ataco");
        }
    }

    IEnumerator Ataco()
    {
        animator.SetBool("Ataque", true);
        atackjugador = true;

        yield return new WaitForSeconds(2);

        atackjugador = false;
        animator.SetBool("Ataque", false);

        StopCoroutine("Ataco");
        
    }
    public void Dash()
    {

        rb.AddForce(0, 0, dashSpeed);
        animator.SetBool("Dash", true);
        animator.SetBool("Correr", false);
        StartCoroutine("DashEnd");


    }

    IEnumerator DashEnd()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Dash", false);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 8)
        {

                player.GetComponent<Renderer>().material = damage;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<Renderer>().material = run;
    }
    void Pausar()
    {
        rb.velocity = Vector3.zero;
    }


}
