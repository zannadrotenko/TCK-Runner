using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
