using UnityEngine;

public class Rotation : MonoBehaviour 
{
    
    [SerializeField] float rotateSpeed = 0.3f;

    private void Update()
    {
        transform.Rotate(0,rotateSpeed,0, Space.World);
    }
}
