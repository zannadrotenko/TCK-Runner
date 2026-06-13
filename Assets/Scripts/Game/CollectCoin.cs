using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour 
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        LevelInfo.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
