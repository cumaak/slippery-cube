using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public AudioClip _button;
   public void Restart_btn()
    {
        GetComponent<AudioSource>().PlayOneShot(_button);
        //SceneManager.LoadScene(0);
    }
}
