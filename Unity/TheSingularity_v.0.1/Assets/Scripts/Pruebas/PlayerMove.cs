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

    // Start is called before the first frame update
    void Start()
    {
        dashColor = false;
        rb = GetComponent<Rigidbody>();
        iAGhoul = GetComponent<IAGhoul>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        desplX = Input.GetAxis("Vertical");
        desplZ = Input.GetAxis("Horizontal");

        transform.Translate(desplX * -speed * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, desplZ * speed * Time.deltaTime);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    public void Dash()
    {
        rb.velocity = Vector3.one;
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
        if(collision.gameObject.name == "Ghoul")
        {

                player.GetComponent<Renderer>().material = damage;
                rb.AddForce(Vector3.back * 100 * Time.deltaTime);
            
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
