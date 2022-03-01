using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAGolem : MonoBehaviour
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
    Vector3 newGoal;
    public Transform Golem;
    VidaGolem vida;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.speed = 40;
        espera = Random.Range(0, 6);
        vida = GetComponent<VidaGolem>();
    }

    private void FixedUpdate()
    {
        if(vida.vida <= 0)
        {
            agent.enabled = false;
        }
        else
        {
            Vivo();
        }
    }

    // Update is called once per frame
    void Vivo()
    {

        dist = Vector3.Distance(goal.position, transform.position);

        if (dist <= 100 && animator.GetBool("Atacar") == false && dist > 12)
        {
            Destino();

            agent.enabled = true;

        }
        if (dist > 100)
        {
            Comportamiento();
            agent.enabled = true;
        }
        if (dist <= 12)
        {
            Atacar();
            agent.enabled = false;
        }

        if (animator.GetBool("Atacar") == true)
        {
            ataco = true;
        }
        if (animator.GetBool("Atacar") == true)
        {
            ataco = false;
        }


    }

    public void Destino()
    {
        agent.SetDestination(goal.position);
        agent.speed = 10;
        animator.SetBool("Corre", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Atacar", false);
    }
    public void Comportamiento()
    {

        cronometro += 1 * Time.deltaTime;
        agent.speed = 10;
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

                break;

            case 1:
                float newX = transform.position.x + Random.Range(-50, 50);
                float newZ = transform.position.z + Random.Range(-50, 50);

                newGoal = new Vector3(newX, transform.position.y, newZ);
                rutina++;
                break;

            case 2:
                agent.SetDestination(newGoal);
                animator.SetBool("Corre", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle2", false);

                if (newGoal == Golem.position)
                {
                    animator.SetBool("Corre", false);
                    animator.SetBool("Idle", true);
                    animator.SetBool("Idle2", false);
                }
                break;
        }

    }


    IEnumerator Ataque()
    {
        animator.SetBool("Atacar", true);

        yield return new WaitForSeconds(1.8f);

        if(dist <= 28)
        {
            animator.SetBool("Atacar", false);
            animator.SetBool("Atacar2", true);

            yield return new WaitForSeconds(2);

            animator.SetBool("Atacar2", false);
        }
        if(dist > 28)
        {
            animator.SetBool("Atacar", false);
        }

        rb.velocity = Vector3.zero;
        rutina = 1;
    }
    private void Atacar()
    {
        {

            StartCoroutine("Ataque");
            animator.SetBool("Idle", false);
            animator.SetBool("Corre", false);

        }
    }



}
