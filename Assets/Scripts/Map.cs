using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    //Desvio, para que o mapa seja "Quadrado", nao "Losango"
    protected readonly float xOffset = 0.882f;
    protected readonly float zOffset = 0.764f;

    // Start is called before the first frame update
    private void Start(){
        GenerateMap();
    }

    //Objecto Tile
    public GameObject[] terrainHex;

    //Array de todos os Hex, sera util para saber posicao e criacao de tipos dif de mapas
    protected Hex[,] hexInfo;

    //Dicionario para conseguir referir ao Objecto, para decidir terrain
    protected Dictionary<Hex, GameObject> hexToObj;

    //Dimensao do mapa
    protected int dimX = 128;
    protected int dimY = 80;

    //Gera mapa com apenas mar
    virtual public void GenerateMap(){

        //Guarda Info de Hex
        hexInfo = new Hex[dimX, dimY];

        //Instancia dicionario, guarda todos os Hex
        hexToObj = new Dictionary<Hex, GameObject>();

        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++){

                //Cria obj Hex so de mar
                Hex h = new Hex(col, row, 7);

                //Guarda a Info
                hexInfo[col, row] = h;

                //Tirar espaços entre hexagonos
                float xPos = col * xOffset;

                //Tirar espaços entre hexagonos quando forem impares
                if (row % 2 == 1)
                    xPos += xOffset / 2.0f;

                //Criar controle de camera


                //Cria o hexagono, com as coordenadas do Unity
                GameObject terrain = (GameObject)Instantiate(terrainHex[7], new Vector3(xPos, 0, row * zOffset), Quaternion.identity);

                //Atribui/Altera nome do tile. Iremos colocar "coordenadas"
                terrain.name = "Hex_" + col + "_" + row;

                //Guarda Hex no dicionario com o tipo de terreno como objecto
                hexToObj[h] = terrain;

                //Apresentar, em mode debug, as coordenadas do hexagono com cor rosa
                terrain.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", col, row);

                //Organiza hierarquia, O objecto com este script sera "pai" dos "Hex_X_Y"
                terrain.transform.SetParent(this.transform);  
            }
        }
        StaticBatchingUtility.Combine(this.gameObject);
    }

    //Verifica se o Tile existe, se sim retorna a info deste.
    public Hex GetHex(int x, int y){
        if(hexInfo == null){
            //Array nao foi instanciado, nao criou mapa
            return null;
        }

        return hexInfo[x, y];
    }
}
