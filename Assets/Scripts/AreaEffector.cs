
/*
 * @Author: Maria Fernanda Lope
 * @Version: 2/05/2018
 * Script que modela las funciones de un area effector su funcion es desactivar y activar los efectos por determinado tiempo  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AreaEffector : MonoBehaviour {
    float time;
    public GameObject cd;
    bool flag;
	// Use this for initialization
	void Start () {
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 3)
        {
            cd.SetActive(flag);
            time = 0;
            flag = !flag;
            
        }
        
		
	}
}
