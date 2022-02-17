using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaGolem : MonoBehaviour
{
    PlayerMovement PlayerMove;
    public float vida;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            anim.SetBool("Muero", true);
            Destroy(gameObject, 5);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9 && PlayerMove.atackjugador == true)
        {
            StartCoroutine("Daño");
        }
    }

    IEnumerator Daño()
    {
        yield return new WaitForSeconds(0.5f);

        vida = vida - 34;

        StopCoroutine("Daño");
    }
}
