using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour{

    //Modo Jogador Unico, segue para outro menu com mais opcoes
    public void Singleplayer(){
        SceneManager.LoadScene(1);
    }

    //Carregar jogo que ja tenha sido previamente criado
    public void LoadGame(){
        SceneManager.LoadScene(3);
    }

    //Modo Multijogador(LAN?, Online?), segue para outro menu com mais opcoes
    public void Multiplayer(){
        SceneManager.LoadScene(4);
    }

    //Scenarios ou mapas prefeitos
    public void Scenario(){
        SceneManager.LoadScene(5);
    }

    //Menu de Opcoes, graficos, etc
    public void Options(){
        SceneManager.LoadScene(6);
    }

    //Sair do jogo
    public void Quit(){
        Application.Quit();
    }

}
