using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Transform player;
    [SerializeField] float destroyDistance = 5f; // ¬≥дстань позаду гравц€, на €к≥й машина зникне

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // якщо позиц≥€ машини по Z менша за позиц≥ю гравц€ м≥нус дистанц≥€
        if (transform.position.z < player.position.z - destroyDistance)
        {
            gameObject.SetActive(false); //Destroy(gameObject);
        }
    }
}
//if (