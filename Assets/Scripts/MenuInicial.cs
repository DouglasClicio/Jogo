using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("O jogo fechou");
    }
}
