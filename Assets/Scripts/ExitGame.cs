using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SairDoJogo();
        }
    }

    public void SairDoJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}