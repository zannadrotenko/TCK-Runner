using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    [SerializeField] GameObject pedestrian;
    [SerializeField] GameObject animPedestrian;
    [SerializeField] float speed = 10f;
    [SerializeField] float targetXPosition = 0f;

    private Vector3 targetPosition;
    private bool isTriggered = false;

    void Awake()
    {
        pedestrian.GetComponent<Animator>().Play("lose");
        targetPosition = new Vector3(targetXPosition, pedestrian.transform.position.y, pedestrian.transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pedestrian.GetComponent<Animator>().Play("running");
            isTriggered = true;
        }
    }

    void Update()
    {
        if (isTriggered)
        {
            float newX = Mathf.MoveTowards(pedestrian.transform.position.x, targetPosition.x, speed * Time.deltaTime);
            pedestrian.transform.position = new Vector3(newX, pedestrian.transform.position.y, pedestrian.transform.position.z);
        }
    }
}
