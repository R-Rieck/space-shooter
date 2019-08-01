using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float delay = 0;
    private AudioSource _explosionSound;


    void Start()
    {
        _explosionSound = gameObject.GetComponent<AudioSource>();
        _explosionSound.Play(0);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
