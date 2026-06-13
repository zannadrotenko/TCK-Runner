using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private float playerSpeed = 5.5f; //float = x.1/yf - неціле число; int playerSpeed = x; - ціле число;     [SerializeField] - дозволяє бачити playerSpeed в інспекторі;

    void Update() //програмний метод, який викликається кожен кадр
    {
        float horizontal = Input.GetAxis("Horizontal"); //Input.GetAxis("Horizontal" - зчитує рух клавіатури по горизонталі; A/D або 1 чи -1
        float vertical = Input.GetAxis("Vertical"); // W/S або 1 чи -1

        Vector3 direction = new Vector3(horizontal, 0f, vertical); //рух по діагоналі
        transform.Translate(direction * playerSpeed * Time.deltaTime); //взиває до transform в Unity; метод translate плюсує до вже наявних координат; 1/-1 * швидкість 5.5 * на час одного кадру
                                                   
    }
}
