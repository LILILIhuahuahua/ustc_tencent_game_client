using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public AudioSource ads;
    public AudioClip eat;
    public AudioClip die;
    private void Awake()
    {
        _instance = this;
    }
    public void PlayEat()
    {
        ads.PlayOneShot(eat);
    }
    public void PlayDie()
    {
        ads.Stop();
        ads.PlayOneShot(die);
    }
}
