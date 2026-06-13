using UnityEngine;
using System.Collections;

public class Jingle : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;

    void Start()
    {
        audioSource.clip = sound1;
        audioSource.Play();
        StartCoroutine(AudioLoop());
    }

    IEnumerator AudioLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);

            if (Random.Range(0, 2) == 0)
            {
                audioSource.clip = sound1;
            }
            else
            {
                audioSource.clip = sound2;
            }
            audioSource.Play();
        }
    }
}
