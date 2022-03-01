using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

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
    [SerializeField] Rigidbody rb;
    public float espera;
    public bool ataco;
    Vector3 newGoal;
    Vector3 posicion;
    public Transform Ghoul;

    VidaGhoul vida;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.speed = 40;
        espera = Random.Range(0, 6);
        vida = GetComponent<VidaGhoul>();
    }

    private void FixedUpdate()
    {
        if(vida.vida <= 0)
        {
            agent.enabled = false;
            rb.AddForce(Vector3.back * 300);
        }
        else
        {
            Vivo();
        }
    }

    // Update is called once per frame
    void Vivo()
    {
        print(rutina);
        dist = Vector3.Distance(goal.position, transform.position);
        posicion = transform.position;

        if (dist <= 100 && animator.GetBool("Atacar") == false && dist > 9 && vida.hit == false)
        {
            Destino();

                agent.enabled = true; 

        }
        if(dist > 100)
        {
            Comportamiento();
            agent.enabled = true;
        }
        if (dist <= 9 && vida.hit == false)
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
    


    IEnumerator FinAtaque()
    {
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Atacar", false);
        rb.velocity = Vector3.zero;
        rutina = 1;
        if(dist < 9)
        {
            Atacar();
            agent.enabled = false;
        }
        if(dist > 9)
        {
            Destino();
            agent.enabled = true;
        }
        StopCoroutine("FinAtaque");
    }
    private void Atacar()
    {

            animator.SetBool("Atacar", true);
            StartCoroutine("FinAtaque");
            animator.SetBool("Idle", false);
            animator.SetBool("Corre", false);
            animator.SetBool("Idle2", false);


    }
    public void Comportamiento()
    {

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= espera)
        {
            rutina = Random.Range(0, 2);
            espera = Random.Range(0, 6);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                animator.SetBool("Corre", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Idle2", false);
                agent.enabled = false;
                
                break;

            case 1:
                float newX = transform.position.x + Random.Range(-50, 50);
                float newZ = transform.position.z + Random.Range(-50, 50);

                newGoal = new Vector3(newX, transform.position.y, newZ);
                agent.enabled = true;
                rutina++;
                break;

            case 2:
                agent.enabled = true;
                agent.SetDestination(newGoal);
                animator.SetBool("Corre", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle2", false);

                if(newGoal == Ghoul.position)
                {
                    print("ya llegue");
                    rutina = 0;
                }
                
                break;

        }

    }


}
