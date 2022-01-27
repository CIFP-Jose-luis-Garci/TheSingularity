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

    // Start is called before the first frame update
    void Start()
    {
        dashColor = false;
        rb = GetComponent<Rigidbody>();
        iAGhoul = GetComponent<IAGhoul>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        desplX = Input.GetAxis("Vertical");
        desplZ = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, desplX * speed * Time.deltaTime);
        transform.Translate(desplZ * speed * Time.deltaTime, 0, 0);



        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    public void Dash()
    {
        rb.velocity = Vector3.one;
        print("das");
        rb.AddForce(desplX * -dashSpeed, 0, desplZ * dashSpeed);
        player.GetComponent<Renderer>().material = dash;
        StartCoroutine("DashEnd");


    }

    IEnumerator DashEnd()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.GetComponent<Renderer>().material = run;
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
