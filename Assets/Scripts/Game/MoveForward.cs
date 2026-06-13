using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    public float brakeSpeed = 15f;       // як швидко об'Їкт скидаЇ швидк≥сть (чим б≥льше число, тим р≥зк≥ше гальмо)
    private bool isBraking = false;

    public MonoBehaviour targetScript;
    void Update()
    {
        if (targetScript != null && targetScript.enabled == false)
        {
            isBraking = true; // јктивуЇмо стан гальмуванн€
        }

        if (isBraking)
        {
            // якщо ув≥мкнене гальмуванн€ Ч плавно зменшуЇмо швидк≥сть до 0
            speed = Mathf.MoveTowards(speed, 0f, brakeSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
