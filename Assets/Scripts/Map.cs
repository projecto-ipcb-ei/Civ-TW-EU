using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    //Desvio, para que o mapa seja "Quadrado", nao "Losango"
    readonly float xOffset = 0.882f;
    readonly float zOffset = 0.764f;

    // Start is called before the first frame update
    private void Start()
    {
        generateMap();
    }

    //Objecto e Dimensao do mapa
    public GameObject[] terrainHex;
    public int dimX = 128;
    public int dimY = 80;

    private Hex[,] hexInfo;
    private Dictionary<Hex, GameObject> hexToObj;

    //Gera mapa com apenas mar
    virtual public void generateMap(){

        //Guarda Info de Hex
        hexInfo = new Hex[dimX, dimY];

        //Usa Hex para obter Objecto
        hexToObj = new Dictionary<Hex, GameObject>();

        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++){

                //Cria obj Hex
                Hex h = new Hex(col, row);

                //Guarda a Info
                hexInfo[col, row] = h;

                //Tirar espaços entre hexagonos
                float xPos = col * xOffset;

                //Tirar espaços entre hexagonos quando forem impares
                if (row % 2 == 1)
                    xPos += xOffset / 2.0f;

                //Numero Random para decidir tile
                //int tile = UnityEngine.Random.Range(0, terrainHex.Length);

                //Criar controle de camera

                //Cria o hexagono, com as coordenadas do Unity
                GameObject terrain = (GameObject)Instantiate(terrainHex[7], new Vector3(xPos, 0, row * zOffset), Quaternion.identity);

                //Atribui/Altera nome do tile. Iremos colocar "coordenadas"
                terrain.name = "Hex_" + col + "_" + row;

                hexToObj[h] = terrain;


                //Apresentar, em mode debug, as coordenadas do hexagono com cor rosa
                terrain.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", col, row);

                //Organiza hierarquia, O objecto com este script sera "pai" dos "Hex_X_Y"
                terrain.transform.SetParent(this.transform);

                //Parametros que posibilitam o hexagono saber a sua posicao
                terrain.GetComponent<HexComponent>().Hex = h; // TODO: CONFIRMAR
                terrain.GetComponent<HexComponent>().Map = this; // TODO: CONFIRMAR
            }
        }
    }

    public void UpdateMap(){
        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++){

                
            }
        }
    }
}
