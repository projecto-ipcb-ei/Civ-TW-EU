using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Continents : Map{

    override public void GenerateMap(){
        //Corre o GenerateMap da class Map
        base.GenerateMap();

        //Corre novo metodo que ira criar um mapa tipo Pangea
        GenerateContinents(20, 20, 5);

        //Atualiza mapa
        UpdateMap();
    }

    void GenerateContinents(int x, int y, int reach){

        Hex iniCoordenate = GetHex(x, y);

        Hex[] newTiles = GetConjHex(iniCoordenate, reach);

        foreach(Hex h in newTiles){
            h.SetTerrain(4);
        }
    }
}
