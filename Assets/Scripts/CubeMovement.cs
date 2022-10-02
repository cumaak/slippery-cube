using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    bool right = true;
    bool left = false;
    float speed = 18f;
    Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Cube").GetComponent<Manager>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Road1")
        {
            if (transform.localScale.x < 0.73f)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.0025f, transform.localScale.y + 0.0025f, transform.localScale.z + 0.0025f);
            }
        }
        if (collision.gameObject.tag == "Road2")
        {
            if (transform.localScale.x > 0.1f)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.0025f, transform.localScale.y - 0.0025f, transform.localScale.z - 0.0025f);
            }
            
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && right == false)
            {
                right = true;
                left = false;
            }
            else if(touch.phase == TouchPhase.Began && left == false)
            {
                left = true;
                right = false;
            }
        }
        if (right == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.5f, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }
        if (left == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.5f, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }

        if(transform.localScale.x > 0.3f)
        {
            transform.Translate(0, 0, transform.localScale.x * speed * Time.deltaTime);
        }
        if(transform.localScale.x <= 0.3f)
        {
            transform.Translate(0, 0, 6f * Time.deltaTime);
        }

        if (manager.score_point >= 10 && manager.score_point < 20)
        {
            speed = 21f;
        }
        if (manager.score_point >= 20)
        {
            speed = 24f;
        }

    }
}
