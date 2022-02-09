using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float DesplY = Input.GetAxis("Vertical") * speed;
        transform.Translate(Vector3.back * -DesplY * Time.deltaTime);

        float DesplX = Input.GetAxis("Horizontal") * speed;
        transform.Translate(Vector3.left * -DesplX * Time.deltaTime);

        if(DesplX == 0)
        {
            animator.SetBool("Corre", false);
        }
        if (DesplY == 0)
        {
            animator.SetBool("Corre", false);
        }

        if (DesplX < 0)
        {
            animator.SetBool("Corre", true);
        }
        if (DesplY < 0)
        {
            animator.SetBool("Corre", true);
        }

        if (DesplX > 0)
        {
            animator.SetBool("Corre", true);
        }
        if (DesplY > 0)
        {
            animator.SetBool("Corre", true);
        }

    }
}
