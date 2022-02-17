using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    float inputX;
    float inputZ;
    Vector3 movement;
    [SerializeField] float speed;
    public CharacterController character;
    public Transform meshPlayer;
    public Animator animator;
    private float gravity;
    public bool atackjugador;

    public float cooldownTime = 2f;
    private float nextFireTime = 0;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    float i = 0;
    float cronometro;

    [SerializeField] GameObject vfx;
    [SerializeField] Transform sword;

    private void Start()
    {

        gravity = 0.5f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tempPlayer.transform.GetChild(0);
        character = tempPlayer.GetComponent<CharacterController>();
        animator = meshPlayer.GetComponent<Animator>();
    }
    private void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if(inputX == 0 && inputZ == 0)
        {
            animator.SetBool("Correr", false);
            
        }
        else
        {
            animator.SetBool("Correr", true);
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_1"))
        {
            animator.SetBool("Ataque", false);
            StartCoroutine("Slash");
            
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_2"))
        {
            animator.SetBool("Ataque2", false);
            StartCoroutine("Slash");

        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_3"))
        {
            animator.SetBool("Ataque3", false);
            StartCoroutine("Slash");

        }
        
            if (Input.GetButton("Fire1"))
            {
                Atacar();
                
                speed = 0.5f;
                atackjugador = true;

            }
        else
        {
            noOfClicks = 0;
            speed = 1;
            atackjugador = false;
        }


        vfx.transform.position = sword.position;
        vfx.transform.rotation = sword.rotation;
    }

    private void FixedUpdate()
    {

        if (character.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }

        movement = new Vector3(inputX * speed, movement.y, inputZ * speed);
        character.Move(movement);

        if (inputX == 0 && inputZ == 0)
        {

        }
        else
        {
            Vector3 lookDir = new Vector3(movement.x, 0, movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
    }
    void Atacar()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        
        if(noOfClicks == 1)
        {
            animator.SetBool("Ataque", true);
        }

        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_1"))
        {
            animator.SetBool("Ataque", false);
            animator.SetBool("Ataque2", true);
        }
        if (noOfClicks >= 3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack_2"))
         {
            animator.SetBool("Ataque2", false);
            animator.SetBool("Ataque3", true);
        }
    }
  
    IEnumerator Slash()
    {
        
        cronometro += 1 * Time.deltaTime;

        if (cronometro >= 0.5f)
        {
            Instantiate(vfx, sword.position, sword.rotation);
            cronometro = 0;
        }
        yield return new WaitForSeconds(1);
    }
}
