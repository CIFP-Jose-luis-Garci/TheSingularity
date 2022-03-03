using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class UI : MonoBehaviour
{
    int ActualScene;
   
    // Start is called before the first frame update
    void Start()
    {
         int GetScene = SceneManager.GetActiveScene().buildIndex;

        ActualScene = GetScene;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ActualScene)
        {
            case 0:
               // print("a");
                if (Input.GetKeyDown(KeyCode.P))
                {
                    CargarEscena(1);
                }
                
                break;
          //  case 1:
              //  print("o");
                if (Input.GetKeyDown(KeyCode.P))
                {
                    CargarEscena(0);
                }
                break;
            case 2:
                break;
            default:
                break;

        }
    }

    public void CargarEscena(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
