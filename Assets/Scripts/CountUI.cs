using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountUI : MonoBehaviour
{
    public TextMeshProUGUI Counter_txt;
    public int Counter;

    Manager manager;
    
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Cube").GetComponent<Manager>();
        Counter = manager.Count;
        StartCoroutine(UpdateCounter());
    }

    IEnumerator UpdateCounter()
    {
        while (Counter >= 0)
        {
            Counter_txt.text = "" + (int)Counter;
            yield return new WaitForSeconds(1f);
            Counter--;
        }
        yield return null;
    }

    private void Update()
    {
       if(Counter == 0)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().CounterExplosionSound();
            manager.Death();
            Counter = -1;
        }
       if(manager.is_Passed == true)
        {
            Counter = 6;
            manager.is_Passed = false;
        }
       if(manager.is_Collide == true)
        {
            StopCoroutine(UpdateCounter());
            Counter = -1;
            manager.is_Collide = false;
        }
    }
}
