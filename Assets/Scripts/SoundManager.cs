using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip score_sound;
    public AudioClip collision_sound;
    public AudioClip counter_explosion;
    public AudioClip button_sound;

    Manager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Cube").GetComponent<Manager>();
    }

    public void CounterExplosionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(counter_explosion);
    }

    public void ButtonSound()
    {
        GetComponent<AudioSource>().PlayOneShot(button_sound);
    }
    
    void Update()
    {
        if(manager.is_Passed)
        {
            GetComponent<AudioSource>().PlayOneShot(score_sound);
        }
        if(manager.is_Collide)
        {
            GetComponent<AudioSource>().PlayOneShot(collision_sound);
        }
    }
}
