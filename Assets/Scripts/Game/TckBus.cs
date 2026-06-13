using UnityEngine;
using UnityEngine.UIElements;

public class TckBus : MonoBehaviour
{

    [SerializeField] float speed = 15f;
    [SerializeField] float maxSpeed = 30f;
    public float speedAcceleration = 0.05f;

    public Transform playerTransform;
    public float laneChangeSpeed = 10f;

    private void Update()
    {
        if (speed < maxSpeed)
        {
            speed += speedAcceleration * Time.deltaTime;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (playerTransform != null)
        {
            Vector3 targetPosition = transform.position;
            float newX = Mathf.Lerp(targetPosition.x, playerTransform.position.x, laneChangeSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, targetPosition.y, targetPosition.z);
        }
    }

}