using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public Transform objectFollow = null;
    public float speed = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        objectFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectFollow == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, objectFollow.transform.position, speed * Time.deltaTime);
        transform.up = objectFollow.position - transform.position;
    }
}
