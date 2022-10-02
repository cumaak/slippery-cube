using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Transform Plane_1, Plane_2;

    public bool is_Collide = false;
    public bool is_Passed = false;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;

    public GameObject ExplosionEffect;

    List<GameObject> obstacles;

    Transform cubePos;
    float Distance = 19f;

    CamMovement cameraShake;

    public GameObject RestartUI;
    public GameObject CountUI;
    public int score_point = 0;
    public int Count;


    private void Awake()
    {
        Count = 6;
    }
    void Start()
    {
        Plane_1 = GameObject.Find("Plane1").transform;
        Plane_2 = GameObject.Find("Plane2").transform;

        cubePos = gameObject.GetComponent<Transform>();

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamMovement>();

     

        obstacles = new List<GameObject>();

        obstacle1 = Instantiate(obstacle1);
        obstacle1.SetActive(false);
        obstacle2 = Instantiate(obstacle2);
        obstacle2.SetActive(false);
        obstacle3 = Instantiate(obstacle3);
        obstacle3.SetActive(false);

        obstacles.Add(obstacle1);
        obstacles.Add(obstacle2);
        obstacles.Add(obstacle3);

    }

    void spawn_obstacle()
    {
        int rand = Random.Range(0, obstacles.Count);

        if (obstacles[rand].activeSelf == false)
        {
            obstacles[rand].SetActive(true);
            obstacles[rand].transform.position = new Vector3(0f, 0.55f, Distance);

            int random = Random.Range(0, 2);

            if (random == 0)
            {
                obstacles[rand].transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            }
            if (random == 1)
            {
                obstacles[rand].transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
            }
            Distance += 40f;
        }
        else
        {
            foreach (GameObject obj in obstacles)
            {
                if (obj.activeSelf == false)
                {
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(0f, 0.55f, Distance);

                    int random_2 = Random.Range(0, 2);

                    if (random_2 == 0)
                    {
                        obj.transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
                    }
                    if (random_2 == 1)
                    {
                        obj.transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
                    }

                    Distance += 40f;
                    return;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            is_Collide = true;
            
            CountUI.SetActive(false);
            Death();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Passed"))
        {
            
            score_point++;
            is_Passed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Plane1")
        {
            Plane_2.position = new Vector3(Plane_2.position.x, Plane_2.position.y, Plane_1.position.z + 40f);
            spawn_obstacle();
        }
        if (other.gameObject.name == "Plane2")
        {
            Plane_1.position = new Vector3(Plane_1.position.x, Plane_1.position.y, Plane_2.position.z + 40f);
            spawn_obstacle();
        }
    }


    public void Death()
    {
        GetComponent<CubeMovement>().enabled = false;
        gameObject.SetActive(false);
        CancelInvoke("spawn_obstacle");
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        //RestartUI.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        Invoke("Restart", 2.5f);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
 

    void Update()
    {
        foreach (GameObject obj in obstacles)
        {
            if (obj.transform.position.z < cubePos.transform.position.z - 2f)
            {
                obj.SetActive(false);
            }
            
        }
    }
}
