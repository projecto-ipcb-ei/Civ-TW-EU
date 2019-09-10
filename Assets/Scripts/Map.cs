using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Map : MonoBehaviour{

    //Desvio, para que o mapa seja "Quadrado", nao "Losango"
    protected readonly float xOffset = 0.882f;
    protected readonly float zOffset = 0.764f;

    //Mesh
    public Mesh water;


    //Materiais
    public Material sea;
    public Material pasture;


    // Start is called before the first frame update
    private void Start(){
        GenerateMap();
    }

    //Objecto Tile - Existem 8, predefinidos
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
                Hex h = new Hex(col, row);

                //Estabelecer tipo de Hex
                h.SetTerrain(7);

                //Guarda a Info
                hexInfo[col, row] = h;

                //Tirar espaços entre hexagonos no eixo X
                float xPos = col * xOffset;

                //Tirar espaços entre hexagonos no eixo Z
                float zPos = row * zOffset;

                //Tirar espaços entre hexagonos quando forem impares
                if (row % 2 == 1)
                    xPos += xOffset / 2.0f;

                //Criar controle de camera


                //Cria o hexagono, com as coordenadas do Unity
                GameObject terrain = (GameObject)Instantiate(terrainHex[7], new Vector3(xPos, 0, zPos), Quaternion.identity);

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
        
        //Atualizacao do mapa
        UpdateMap();

        //Otimizacao do mapa
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

    //Substitui os Hex pelo tipo de mapa selecionado pelo jogador
    public Hex[] GetConjHex(Hex center, int reach){

        List<Hex> newTiles = new List<Hex>();

        for (int dx = -reach; dx <= reach; dx++){
            for (int dy = Mathf.Max(-reach, -dx - reach); dy <= Mathf.Min(reach, -dx + reach); dy++){
                newTiles.Add(hexInfo[center.x + dx, center.y + dy]);
            }
        }

        return newTiles.ToArray();
    }

    //Verifica tipo de terreno para criar o Hex correspondente
    public void UpdateMap(){

        for (int col = 0; col < dimX; col++){
            for (int row = 0; row < dimY; row++){

                //Tirar espaços entre hexagonos no eixo X
                //float xPos = col * xOffset;

                //Tirar espaços entre hexagonos no eixo Z
                //float zPos = row * zOffset;

                //Tirar espaços entre hexagonos quando forem impares
                //if (row % 2 == 1)
                //    xPos += xOffset / 2.0f;

                Hex h = hexInfo[col, row];

                //Instanciar GameObject
                GameObject terrain = hexToObj[h];

                MeshRenderer mr = terrain.GetComponentInChildren<MeshRenderer>();

                if (h.GetTerrain() == 0){
                    //Cria o hexagono, com as coordenadas do Unity
                    
                }
                else if (h.GetTerrain() == 1){
                    //Cria o hexagono, com as coordenadas do Unity
                    //terrain = (GameObject)Instantiate(terrainHex[1], new Vector3(xPos, 0, zPos), Quaternion.identity);
                }else if (h.GetTerrain() == 2){
                    //Cria o hexagono, com as coordenadas do Unity
                    //terrain = (GameObject)Instantiate(terrainHex[2], new Vector3(xPos, 0, zPos), Quaternion.identity);
                }else if (h.GetTerrain() == 3){
                    //Cria o hexagono, com as coordenadas do Unity
                    //terrain = (GameObject)Instantiate(terrainHex[3], new Vector3(xPos, 0, zPos), Quaternion.identity);
                }else if (h.GetTerrain() == 4){

                    mr.material = pasture;

                    // Instantiate the new game object at the old game objects position and rotation.
                    //GameObject newTerrain = Instantiate(terrainHex[4], new Vector3(xPos, 0, zPos), Quaternion.identity);

                    // If the old game object has a valid parent transform,
                    // (You can remove this entire if statement if you do not wish to ensure your
                    // new game object does not keep the parent of the old game object.
                    //if (terrain.transform.parent != null){
                    //    // Set the new game object parent as the old game objects parent.
                    //    newTerrain.transform.SetParent(terrain.transform.parent);
                    //}

                    // Destroy the old game object, immediately, so it takes effect in the editor.
                    //DestroyImmediate(terrain);
                }else if (h.GetTerrain() == 5){
                    //Cria o hexagono, com as coordenadas do Unity
                    //terrain = (GameObject)Instantiate(terrainHex[5], new Vector3(xPos, 0, zPos), Quaternion.identity);
                }else if (h.GetTerrain() == 6){
                    //Cria o hexagono, com as coordenadas do Unity
                    //terrain = (GameObject)Instantiate(terrainHex[6], new Vector3(xPos, 0, zPos), Quaternion.identity);
                }else{

                    mr.material = sea;

                    //Cria o hexagono, com as coordenadas do Unity
                    //GameObject go = terrain.GetComponentInChildren<GameObject>();
                    //go = terrainHex[7];

                    // Instantiate the new game object at the old game objects position and rotation.
                    //GameObject newTerrain = Instantiate(terrainHex[7], new Vector3(xPos, 0, zPos), Quaternion.identity);

                    // If the old game object has a valid parent transform,
                    // (You can remove this entire if statement if you do not wish to ensure your
                    // new game object does not keep the parent of the old game object.
                    //if (terrain.transform.parent != null){
                    //    // Set the new game object parent as the old game objects parent.
                    //    newTerrain.transform.SetParent(terrain.transform.parent);
                    //}

                    // Destroy the old game object, immediately, so it takes effect in the editor.
                    //DestroyImmediate(terrain);
                }

                MeshFilter mf = terrain.GetComponentInChildren<MeshFilter>();
                mf.mesh = water;

                //Atribui/Altera nome do tile. Iremos colocar "coordenadas"
                //terrain.name = "Hex_" + col + "_" + row;

                //Guarda Hex no dicionario com o tipo de terreno como objecto
                //hexToObj[h] = terrain;

                //Apresentar, em mode debug, as coordenadas do hexagono com cor rosa
                //terrain.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", col, row);

                //Organiza hierarquia, O objecto com este script sera "pai" dos "Hex_X_Y"
                //terrain.transform.SetParent(this.transform);
            }
        }
    }
}
