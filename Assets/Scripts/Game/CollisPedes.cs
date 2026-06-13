using UnityEngine;
using System.Collections;

public class CollisPedes : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerAnim;
    [SerializeField] GameObject pedestrianTrigger;
    [SerializeField] GameObject pedestrianAnim;
    [SerializeField] GameObject chaser;
    [SerializeField] GameObject chaserAnim;
    [SerializeField] AudioSource AudioFx;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject effect;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        AudioFx.Play();
        player.GetComponent<EndlessRunner>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("fall");
        pedestrianTrigger.GetComponent<Pedestrian>().enabled = false;
        pedestrianAnim.GetComponent<Animator>().Play("fall");
        chaser.GetComponent<TckBus>().enabled = false;
        chaserAnim.GetComponent<Animator>().enabled = false;
        fadeOut.SetActive(true);
        effect.SetActive(true);
        yield return new WaitForSeconds(0f);
    }
}
