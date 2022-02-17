using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject zombi;
    Vector3 instanciador;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        instanciador = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("crearEnemigos");

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator crearEnemigos()
    {
 

            if (i < 5)
            {
            //Instancio el enemigo en una posición aleatoria del tablero
            Vector3 posicionEnemigo = new Vector3(instanciador.x + Random.Range(-10, 10), instanciador.y, instanciador.z + Random.Range(-10, 10));    

                Instantiate(zombi, posicionEnemigo, Quaternion.identity);

                i++;

                print(i);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(1);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(1);
        }
    }

