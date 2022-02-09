using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAparicion : MonoBehaviour
{
    Material materials;
    PlayerMove PlayerMove;
    public float first;
    public float last;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = FindObjectOfType<PlayerMove>();
        
        materials.SetFloat("_Dissolve", first);
    }

    // Update is called once per frame
    void Update()
    {

            materials.SetFloat("_Dissolve", first);
        
    }
}
