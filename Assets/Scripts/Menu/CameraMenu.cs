using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    public float speed = 30f; // Ўвидк≥сть повороту
    private bool shouldRotate = false;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource dropSound;
    public void CameraButton()
    {
        shouldRotate = true;
        buttonSound.Play();
    }
    void Update()
    {
        if (shouldRotate)
        {
            Vector3 angles = transform.localEulerAngles; //Euler Angles- rotation
            angles.x = Mathf.MoveTowardsAngle(angles.x, 12.5f, speed * Time.deltaTime);
            transform.localEulerAngles = angles;
            if (Mathf.Approximately(angles.x, 12.5f))
            {
                dropSound.Play();
                shouldRotate = false;
            }
        }
    }
}

