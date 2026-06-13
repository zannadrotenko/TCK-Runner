using UnityEngine;

public class NPS_anim : MonoBehaviour 
{

    [SerializeField] GameObject tck;
    [SerializeField] GameObject animTck;
    [SerializeField] GameObject tck1;
    [SerializeField] GameObject animTck1;
    [SerializeField] GameObject tck2;
    [SerializeField] GameObject animTck2;
    [SerializeField] GameObject angry;
    [SerializeField] GameObject animAngry;
    [SerializeField] GameObject player;
    [SerializeField] GameObject animPlayer;

    private void Start()
    {
        player.GetComponent<Animator>().Play("fall");
        tck.GetComponent<Animator>().Play("lose");
        tck1.GetComponent<Animator>().Play("lose");
        tck2.GetComponent<Animator>().Play("lose");
        angry.GetComponent<Animator>().Play("win");
    }
}
