using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    //Desvio, para que o mapa seja "Quadrado", nao "Losango"
    readonly float xOffset = 0.882f;
    readonly float zOffset = 0.764f;

    // Start is called before the first frame update
    private void Start(){
        GenerateMap();
    }

    public GameObject[] terrainHex;

    public void GenerateMap(){
        int dimX = 128;
        int dimY = 80;

        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++) {

                //Tirar espaços entre hexagonos
                float xPos = col * xOffset;

                //Tirar espaços entre hexagonos quando forem impares
                if (row % 2 == 1)
                    xPos += xOffset / 2.0f;

                //Numero Random para decidir tile
                //int tile = UnityEngine.Random.Range(0, terrainHex.Length);

                //Cria o hexagono, com as coordenadas do Unity
                GameObject terrain = (GameObject)Instantiate(terrainHex[7], new Vector3(xPos, 0, row * zOffset), Quaternion.identity);
                    
                //Atribui/Altera nome do tile. Iremos colocar "coordenadas"
                terrain.name = "Hex_" + col + "_" + row;

                //Apresentar, em mode debug, as coordenadas do hexagono com cor rosa
                terrain.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", col, row);

                //Organiza hierarquia, O objecto com este script sera "pai" dos "Hex_X_Y"
                terrain.transform.SetParent(this.transform);

                //Parametros que posibilitam o hexagono saber a sua posicao
                //hex.GetComponent<Hex>().x = col; // TODO: CONFIRMAR
                //hex.GetComponent<Hex>().y = row; // TODO: CONFIRMAR
            }
        }
    }
}
