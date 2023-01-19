using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSound : MonoBehaviour
{

    [SerializeField] AudioClip good, bad;
    [SerializeField] AudioSource SFX;

    public void GoodHit()
    {
        SFX.clip = good;
        SFX.Play();
    }

    public void BadHit()
    {
        SFX.clip = bad;
        SFX.Play();
    }
}
