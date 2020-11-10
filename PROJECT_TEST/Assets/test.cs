using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject wall;
    public bool isActive;
    public Material M0, M1;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = M1;
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            gameObject.GetComponent<Renderer>().material = M0;
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("Wall");
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(wall.transform.position.y <20)
            wall.transform.position += new Vector3(0f, 10* Time.deltaTime, 0f);
        }

        else
        {
            if(wall.transform.position.y>3)
                wall.transform.position += new Vector3(0f, -10 * Time.deltaTime, 0f);
        }
    }
}
