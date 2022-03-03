using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class Listeners : MonoBehaviour, ISelectHandler
{

    GameObject volumeMenu;
    GameObject defaultMenu;
    GameObject controlMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        volumeMenu = GameObject.Find("opcionesMenu");
        defaultMenu = GameObject.Find("defaultMenu");
        controlMenu = GameObject.Find("controlMenu");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        string nombreBtn = this.gameObject.name;
        Debug.Log("Se ha seleccionado el boton: " + nombreBtn);
        //Dependiendo del nombre, o el tag, podemos tomar decisiones
        if (nombreBtn == "Opciones")
        {
            //Accedemos al objeto que contiene los sliders de volumen y lo desactivamos

            volumeMenu.SetActive(true);
            defaultMenu.SetActive(false);
            controlMenu.SetActive(false);

        } else if(nombreBtn=="Controles") {
            volumeMenu.SetActive(false);
            defaultMenu.SetActive(false);
            controlMenu.SetActive(true);
        }
        else
        {
            volumeMenu.SetActive(false);
            defaultMenu.SetActive(true);
            controlMenu.SetActive(false);
        }
    }
}
