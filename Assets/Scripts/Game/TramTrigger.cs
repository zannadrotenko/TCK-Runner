using UnityEngine;

public class TramTrigger : MonoBehaviour
{
    [SerializeField] GameObject tram;
    [SerializeField] AudioSource tramHonor;
    [SerializeField] float speed = 15f;

    [SerializeField] float targetXPosition = 0f;

    private bool isTriggered = false;
    private Vector3 targetPosition;

    void Awake()
    {
        targetPosition = new Vector3(targetXPosition, tram.transform.position.y, tram.transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            tramHonor.Play();
        }
    }

    void Update()
    {
        if (isTriggered)
        {
            float newX = Mathf.MoveTowards(tram.transform.position.x, targetPosition.x,speed * Time.deltaTime);//Mathf.MoveTowards(поточне_значенн€, ц≥ль, максимальний_крок). Mathf.MoveTowards Ч це одна з функц≥й в Unity дл€ створенн€ плавного руху.
                                                                                                               //ransform.position = targetPos, трамвай телепортуЇтьс€ на дорогу миттЇво
            tram.transform.position = new Vector3(newX, tram.transform.position.y, tram.transform.position.z);
        }
    }
}
