using System.Collections;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerAnim;
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

        EndlessRunner runnerScript = player.GetComponent<EndlessRunner>();
        if (runnerScript != null)
        {
            // 2. Наказуємо йому плавно впасти на землю (-0.1f) і зупинити швидкість вперед
            runnerScript.ForceGround();
        }
        yield return new WaitForSeconds(0.01f);
        player.GetComponent<EndlessRunner>().enabled = false;
        chaser.GetComponent<TckBus>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("fall");
        chaserAnim.GetComponent<Animator>().enabled = false;
        fadeOut.SetActive(true);
        effect.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

