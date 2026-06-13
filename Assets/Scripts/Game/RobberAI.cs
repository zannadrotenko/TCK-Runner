using UnityEngine;

public class RobberAI : MonoBehaviour
{
    public float speed = 10f;
    public float laneChangeSpeed = 15f;
    public float tiltAmount = 10f;

    public float rayDistance = 5f;

    // 1 - ліво, 2 - центр, 3 - право
    private int mainLane = 2; // початкова лінія - центр
    private int widthLane = 4;// ширина смуг

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 targetPosition = transform.position; //поточна позиція

        if (mainLane == 1)
        {
            targetPosition.x = -widthLane;
        }
        else if (mainLane == 2)
        {
            targetPosition.x = 0;
        }
        else if (mainLane == 3)
        {
            targetPosition.x = widthLane;
        }
        
        float distanceToLane = Mathf.Abs(transform.position.x - targetPosition.x);

        if (distanceToLane < 0.1f)

            CheckForObstacles();
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);

        float different = targetPosition.x - transform.position.x;
        Quaternion targetRotation = Quaternion.Euler(0, different * tiltAmount, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, laneChangeSpeed * Time.deltaTime);
    }

    void CheckForObstacles()
    {
        RaycastHit hit;
        // Пускаємо промінь вперед від рівня грудей (Vector3.up)
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                AvoidObstacle();
            }
        }
    }

    void AvoidObstacle()
    {
        if (mainLane == 2)
        {
            mainLane = Random.value > 0.5f ? 3 : 1;
        }
        else
        {
            mainLane = 2;
        }
    }
}
