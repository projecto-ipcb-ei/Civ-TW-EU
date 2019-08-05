using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour{

    public Vector3 destination;
    float speed = 1;

    // Start is called before the first frame update
    void Start(){
        destination = transform.position;
    }

    // Update is called once per frame
    void Update(){
        //Dados importantes, relativos a distancia, direcao, destino, velocidade, relacionados tb ao tempo real
        Vector3 dir = destination - transform.position;
        Vector3 vel = dir.normalized * speed * Time.deltaTime;

        //Velocidade nao pode exceder a distancia percorrida
        //Senao ira sair "disparado"
        vel = Vector3.ClampMagnitude(vel, dir.magnitude);

        //TODO: Esta a criar jibber (pequenos saltos, collider, rigidbody e gravidade)
        //Move a unidade
        //FIX?
        transform.Translate(vel);
    }
}
