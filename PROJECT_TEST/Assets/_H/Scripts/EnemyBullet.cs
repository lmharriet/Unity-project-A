using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{

    private GameObject target;
    public Vector3 dir;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") == null)
        {
            dir = Vector3.down;
        }

        else
        {
            target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //dir = target.transform.position - transform.position;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().GetDamage(1);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
