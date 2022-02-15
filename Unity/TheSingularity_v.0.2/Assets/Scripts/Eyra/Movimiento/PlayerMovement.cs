using UnityEngine;

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
            print("no corro");
        }
        else
        {
            animator.SetBool("Correr", true);
        }
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

}
