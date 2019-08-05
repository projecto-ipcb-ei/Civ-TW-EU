using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Random : Map{

    override public void GenerateMap(){
        //Corre o GenerateMap da class Map
        base.GenerateMap();

        //Corre novo metodo que ira criar um mapa tipo Random
        GenerateRandom();
    }

    private void GenerateRandom(){
        //Guarda Info de Hex
        hexInfo = new Hex[dimX, dimY];

        //Instancia dicionario, guarda todos os Hex
        hexToObj = new Dictionary<Hex, GameObject>();

        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++){

                //Numero Random para decidir tile
                int tile = UnityEngine.Random.Range(0, terrainHex.Length);

                //Cria obj Hex
                Hex h = new Hex(col, row, tile);

                //Guarda a Info
                hexInfo[col, row] = h;

                //Tirar espaços entre hexagonos
                float xPos = col * xOffset;

                //Tirar espaços entre hexagonos quando forem impares
                if (row % 2 == 1)
                    xPos += xOffset / 2.0f;

                //Criar controle de camera


                //Cria o hexagono, com as coordenadas do Unity
                GameObject terrain = (GameObject)Instantiate(terrainHex[tile], new Vector3(xPos, 0, row * zOffset), Quaternion.identity);

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
}
