using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boss;
    public Transform minX, maxX;

    //private Transform temp;
    
    private float count;
    public float creatTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > creatTime)
        {
            count = 0;

            Vector3 pos;
            pos = minX.position;

            float ranX = Random.Range(minX.position.x, maxX.position.x);
            pos.x = ranX;

            Instantiate(Enemy, pos, Quaternion.identity);
        }

   
    }
}
