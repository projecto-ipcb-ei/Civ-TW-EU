using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Pangea : Map{
    
    override public void generateMap(){
        //Corre o GenerateMap da class Map
        base.generateMap();

        //Corre novo metodo que ira criar um mapa tipo Pangea
        generatePangea();

        //
    }

    void generatePangea(){
        for (int col = 0; col < 1; col++){
            int num = Random.Range(4, 8);
            for (int row = 0; row < num; row++){
                int range = Random.Range(5, 8);
                int y = Random.Range(range, rows - range);
                int x = Random.Range(5, 8);
            }
        }
}
