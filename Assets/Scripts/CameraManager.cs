using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Necessario para UI, eventos, entre outros

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        //Se o rato estiver sobre o UI, nao devera interagir com o "jogo"
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        //Teste na consola, para mostrar posicao do rato (pelo ecra)
        Debug.Log("Posicao do rato: " + Input.mousePosition);

        //Teste para posicao do rato (pelos tiles)
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Variavel vazia, ira ser preenchida quando o raio atingir algo
        //Raio apenas atinge se tiver fisicas
        //Guardara a info de todo o obj
        RaycastHit hitInfo;

        //Parametro com out e uma variavel com apontador
        if(Physics.Raycast(r, out hitInfo)){
            //Guarda Objecto e atributos
            GameObject objHit = hitInfo.collider.transform.parent.gameObject;

            //Neste caso, o nosso mar, tem 2 componentes
            //Entao queremos o objeto na hierarquia superior
            if (objHit.name == "HexTile_Water")
                objHit = hitInfo.collider.transform.parent.parent.gameObject;

            //Teste na consola, para mostrar, o nome do tile, onde tem posicao
            Debug.Log("Raio atingiu: " + objHit.name);

            //Confirma se estamos num hexagono
            if (objHit.GetComponent<Hex>() != null){
                MouseOver_Hex(objHit);
            }
        }
    }

    //Clicar para selecionar
    //Le o rato, neste caso botao esquerdo, retorna true quando estiver em "baixo"
    //Faz isto apenas 1x, por click
    private void MouseOver_Hex(GameObject objHit){
        
        //Temos uma unidade? Cidade? Editar comportamento

        if (Input.GetMouseButtonDown(0)){
            MeshRenderer mr = objHit.GetComponentInChildren<MeshRenderer>();

            if (mr.material.color == Color.white)
                mr.material.color = Color.red;
            else
                mr.material.color = Color.white;
        }
    }
}
