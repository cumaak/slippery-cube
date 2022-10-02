using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    Manager manager;
    Transform cube_pos;
    void Start()
    {
        cube_pos = GameObject.Find("Cube").transform;
        manager = GameObject.Find("Cube").GetComponent <Manager> ();
    }

    public IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.8f;
        float magnitude = 0.1f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            //float x = Random.onUnitSphere * magnitude;
            //float y = Random.onUnitSphere * magnitude;
            //transform.position = new Vector3(x, y, startPosition.z);
            transform.position = startPosition + Random.onUnitSphere * magnitude;

            yield return null;
        }
        transform.position = startPosition;
    }

    private void Update()
    {
        if(manager.is_Collide == true)
        {
            StartCoroutine(Shake());
            manager.is_Collide = false;
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, cube_pos.position.z - 3.3f);
    }
}
