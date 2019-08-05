using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour{

    //Coordenadas do Objecto
    public int x;
    public int y;  

    public Hex[] getVizinhos(){

        //Apenas encontro vizinhos no eixo do X
        //Vizinho a sua esquerda
        GameObject left = GameObject.Find("Hex_" + (x - 1) + "_" + y);

        //Vizinho a sua direita
        GameObject right = GameObject.Find("Hex_" + (x + 1) + "_" + y);

        //TODO
        //Para encontrar no eixo dos y, depende se é uma linha par ou impar
        //y % 2 = 0 ou 1
        //x-1,x ou x,x+1

        return null;
    }
}
