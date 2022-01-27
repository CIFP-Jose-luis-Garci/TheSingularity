using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAGhoul : MonoBehaviour
{
    [SerializeField] Transform goal;
    [SerializeField] NavMeshAgent agent;
    float dist;
    public Animator animator;
    public float rutina;
    public float grado;
    public Quaternion angulo;
    float cronometro;
    Rigidbody rb;
    public float espera;
    public bool ataco;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.speed = 40;
        espera = Random.Range(0, 6);
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        dist = Vector3.Distance(goal.position, transform.position);
        
        if(dist <= 40 && animator.GetBool("Atacar") == false && dist > 5)
        {
            Destino();

                agent.enabled = true; 

        }
        if(dist > 40)
        {
            Comportamiento();
            agent.enabled = false;
        }
        if(dist <= 5)
        {
            Atacar();
            agent.enabled = false;
        }

        if(animator.GetBool("Atacar") == true)
        {
            ataco = true;
        }
        if(animator.GetBool("Atacar") == true)
        {
            ataco = false;
        }

    }

    public void Destino()
    {
        agent.SetDestination(goal.position);
        animator.SetBool("Corre", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Atacar", false);
        animator.SetBool("Idle2", false);
    }
    public void Comportamiento()
    {
        
        cronometro += 1 * Time.deltaTime;
        if(cronometro >= espera)
        {
            rutina = Random.Range(0, 3);
            espera = Random.Range(0, 6);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                animator.SetBool("Corre", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Idle2", false);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0);
                grado = 0;
                angulo = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.forward * 0 * 0);
                break;

            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 17 * Time.deltaTime);
                animator.SetBool("Corre", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle2", false);
                break;
            case 3:
                animator.SetBool("Corre", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle2", true);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0);
                grado = 0;
                angulo = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.forward * 0 * 0);
                break;

        }

    }


    IEnumerator FinAtaque()
    {
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Atacar", false);
        rb.velocity = Vector3.zero;
        rutina = 1;
    }
    private void Atacar()
    {

            animator.SetBool("Atacar", true);
            StartCoroutine("FinAtaque");
            animator.SetBool("Idle", false);
            animator.SetBool("Corre", false);
            animator.SetBool("Idle2", false);


    }


    }
