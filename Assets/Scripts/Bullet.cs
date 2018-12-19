using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Members
    public float moveSpeed = 7.0f;
    private float passedTime = 0.0f;
    private float damage = 1.0f;
    public GameObject[] Locs;

    private GameObject triggerEnemy;
    private void Awake()
    {
        Locs = GameObject.FindGameObjectsWithTag("Enemy");
        
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        passedTime += 1 * Time.deltaTime;
        if(passedTime >= 5)
        {
            Destroy(this.gameObject);
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int x = Random.Range(0, 2);
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Enemy>().agent.enabled = false;
            triggerEnemy.transform.position = Locs[x].gameObject.GetComponent<Enemy>().StartPos;
            triggerEnemy.GetComponent<Enemy>().agent.enabled = true;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            this.gameObject.transform.Rotate(180, 0, 0, Space.World);
        }
    }

    
}
