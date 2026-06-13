using UnityEngine;

public class Anim : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject tck1;
    [SerializeField] GameObject tck2;
    [SerializeField] GameObject tck3;
    private void Start()
    {
        player.GetComponent<Animator>().Play("win");
        tck1.GetComponent<Animator>().Play("lose");
        tck2.GetComponent<Animator>().Play("lose");
        tck3.GetComponent<Animator>().Play("lose");
    }
}
