using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float count = 0;
    public GameObject subBullet;
    public Transform firePoint;
    // Start is called before the first frame update
   public 
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count>1.0f)
        {
            count = 0;
            GameObject sBullet = Instantiate(subBullet);
            sBullet.transform.position = firePoint.position;

        }
        
    }


       
    
}
