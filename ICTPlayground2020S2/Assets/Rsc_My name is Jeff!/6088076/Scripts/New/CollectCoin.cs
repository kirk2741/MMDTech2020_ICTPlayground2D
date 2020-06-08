using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    public AudioSource collectSound;
    public int scoreCoin = 50;

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoreSystem.theScore += scoreCoin;
        Destroy(gameObject);
    }

}
