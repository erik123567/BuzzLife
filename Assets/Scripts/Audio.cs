using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sfx1, sfx2, sfx3;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSfx1()
    {
        source.clip = sfx1;
        source.Play();
    }
    public void playSfx2()
    {
        source.clip = sfx2;
        source.Play();
    }
}
