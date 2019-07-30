using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayer : MonoBehaviour{

    //Iniciar jogo com as configuracoes desejadas
    public void Back(){
        SceneManager.LoadScene(0);
    }

    //Iniciar jogo com as configuracoes desejadas
    public void Play(){
        SceneManager.LoadScene(2);
    }
}
