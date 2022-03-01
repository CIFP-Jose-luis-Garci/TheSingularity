using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGhoul : MonoBehaviour
{
    PlayerMovement PlayerMove;
    public float vida;
    [SerializeField] Animator anim;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9 && PlayerMove.atackjugador == true)
        {
            StartCoroutine("Daño");
            anim.SetBool("Hit", true);
        }
        else
        {
            hit = false;
            anim.SetBool("Hit", false);
        }
    }

    IEnumerator Daño()
    {
        yield return new WaitForSeconds(0.5f);

        vida = vida - 34;
        hit = true;
        

        StopCoroutine("Daño");
    }
}
