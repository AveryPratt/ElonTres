using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music1;
    public AudioSource Music2;
    public AudioSource Music3;

    public AudioSource Intro;
    
    public AudioSource Compost;
    public AudioSource Metal;
    public AudioSource Nuclear;
    
    public AudioSource Bin;
    public AudioSource Turbine;
    public AudioSource Solar;

    public Inventory Inventory;

    private void Update()
    {
        if (!Intro.isPlaying)
        {
            if (!Music1.isPlaying)
            {
                Music1.Play();
                Music2.Play();
                Music3.Play();
            }
            Music1.mute = true;
            Music2.mute = true;
            Music3.mute = true;
            if (Inventory.CarbonCount <= 450)
            {
                Music1.mute = false;
            }
            else if (Inventory.CarbonCount <= 480)
            {
                Music2.mute = false;
            }
            else
            {
                Music3.mute = false;
            }
        }
    }
}
