using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: Guardar posicao e tipo de tile, saber vizinhanca(?)
//Possivel meter em "fogo" quando invadido
//Ou outros efeitos em outras situacoes
public class Hex : MonoBehaviour{

    //Coordenadas do Objecto
    public int x;
    public int y;
    public int type;

    public Hex(int col, int row, int type){
        x = col;
        y = row;
        this.type = type;
    }

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

    public void setTerrain(int type){
        this.type = type;
    }

    public int getTerrain(){
        return type;
    }
}
