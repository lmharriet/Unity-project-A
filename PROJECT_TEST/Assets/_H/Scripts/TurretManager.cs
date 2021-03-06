﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject turretLeft;
    public GameObject turretRight;

    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;

            if(isActive)
            {
                turretLeft.SetActive(true);
                turretRight.SetActive(true);
            }

            else
            {
                turretLeft.SetActive(false);
                turretRight.SetActive(false);
            }
        }
    }
}
