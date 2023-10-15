using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUINICIAL : MonoBehaviour
{
    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void salir(){
        Debug.Log("Saliendo..");
        Application.Quit();
    }
}
