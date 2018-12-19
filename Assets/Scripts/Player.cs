using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float health = 3.0f;
    public float moveSpeed = 7.0f;
    public float points = 0.0f;
    public GameObject bulletSpawner;
    public GameObject bullet;
    private Vector3 initial;
    private GameObject Life;
    private GameObject Score;
    public GameObject GUI;
    public float ghostwalk;
    bool ghost;
    bool walker;

    // Use this for initialization
    void Start () {
        GUI = GameObject.FindGameObjectWithTag("GUI");
        Life = GameObject.FindGameObjectWithTag("Life");
        Score = GameObject.FindGameObjectWithTag("Score");
        initial = transform.position;
        ghostwalk = 4;
        ghost = false;
        walker = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R) && walker == true)
        {
            gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
            ghost = true;
            walker = false;
        }
        if (ghost == true)
        {
            ghostwalk -= Time.deltaTime;
        }
        if (ghostwalk < 0)
        {
            gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
            ghostwalk = 4;
            
        }
        //Player movement
        boundCheck();
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //transform.GetChild(0).LookAt(Vector3.forward, Vector3.up);
            //transform.GetChild(0).RotateAround(transform.position, transform.up, 0);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //transform.GetChild(0).RotateAround(transform.position, transform.up, -90);
            //if(Input.GetKeyDown(KeyCode.A))
                transform.GetChild(0).rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            //transform.GetChild(0).RotateAround(transform.position, transform.up, 180);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //transform.GetChild(0).RotateAround(transform.position, transform.up, 90);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if(GUI.activeInHierarchy)
        {
            Life.GetComponent<Text>().text = health.ToString();
            Score.GetComponent<Text>().text = points.ToString();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1.0f;
            int x = Random.Range(0, 15);
            int z = Random.Range(0, 15);
            transform.Translate(new Vector3(x,0,z), Space.World);
            if (health < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
        if (other.gameObject.tag == "Ghost")
        {
            walker = true;
            int x = Random.Range(0, 15);
            int z = Random.Range(0, 15);
            other.gameObject.transform.Translate(new Vector3(x, 0, z), Space.World);
        }
    }
    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
    void boundCheck()
    {
        if (transform.position.z > 15)
        {            
            transform.Translate(new Vector3(0, 0, -15), Space.World);
        }
        if (transform.position.z < -15 )
        {
            transform.Translate(new Vector3(0, 0, 15), Space.World);
        }
        if (transform.position.x > 15 )
        {
            transform.Translate(new Vector3(-15, 0, 0), Space.World);
        }
        if (transform.position.x < -15 )
        {
            transform.Translate(new Vector3(15, 0, 0), Space.World);
        }
        if (transform.position.y != 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
   
}
