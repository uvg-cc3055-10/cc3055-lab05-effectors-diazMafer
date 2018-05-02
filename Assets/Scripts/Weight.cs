
/*
 * @Author: Maria Fernanda Lope
 * @Version: 2/05/2018
 * Dibuja la linea por la cual se mueve la pesa de la escena 2 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {
    LineRenderer line;
    DistanceJoint2D distanceJ;
	// Use this for initialization
	void Start () {
        distanceJ = GetComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //se colocan dos puntos uno en la posicion inicial y el otro en la posicion final la cual es el inicio de la pesa
        line.SetPosition(0, transform.position);
        line.SetPosition(1, distanceJ.connectedBody.transform.position);

    }
}
