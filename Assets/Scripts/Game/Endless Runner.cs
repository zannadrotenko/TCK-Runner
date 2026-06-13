using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float maxSpeed = 30f; // ћаксимальна швидк≥сть, €ку може розвинути гравець
    public float speedAcceleration = 0.05f; //як швидко зб≥льшуЇтьс€ швидк≥сть кожну секунду
    public float laneChangeSpeed = 15f; // швидк≥сть переходу м≥ж смугами
    public float tiltAmount = 10f; // сила нахилу
    

    // 1 - л≥во, 2 - центр, 3 - право
    private int mainLane = 2; // початкова л≥н≥€ - центр
    private int widthLane = 4; // ширина смуг

    public float jumpHeight = 4f;    // ћаксимальна висота стрибка
    public float jumpSpeed = 10f;    // як швидко в≥н зл≥таЇ ≥ падаЇ
    private float targetY = -0.1f;   // ÷≥льова висота, куди ми пр€муЇмо
    public Animator anim;

    public float brakeSpeed = 20f;

    void Update()
    {
        if (playerSpeed < maxSpeed)
        {
            playerSpeed += speedAcceleration * Time.deltaTime;// «б≥льшуЇмо швидк≥сть з часом, але не вище за maxSpeed
        }

        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime); //пост≥йно рухаЇмо поточну позиц≥ю гравц€ (transform) вперед множачи на швидк≥сть гравц€ ≥ на час одного кадру

        // якщо натиснути праворуч
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) // €кщо (¬водна система. нопка Ќатиснута(Ќазва  нопки.ѕрава—тр≥лка))
        {
            if (mainLane < 3)
            {
                mainLane++; // то номер л≥н≥њ зб≥льшуЇтьс€. ѕочаткова 2, то буде 3
            }
        }
        // якщо натиснути л≥воруч
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
           if (mainLane >1)
            {
                mainLane--;
            }
        }
        // якщо натиснути проб≥л
        if (transform.position.y <= -0.05f) //перев≥рка чи гравець приземливс€
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetY = jumpHeight;
                anim.SetTrigger("Jump");
            }
        }
        if (transform.position.y >= jumpHeight - 0.1f) //€кщо гравець в прижку
        {
            targetY = -0.1f; //приземл€Їмо гравц€
        }

        // –озрахунок новоњ позиц≥њ гравц€
        Vector3 targetPosition = transform.position; //поточна позиц≥€

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
        float newY = Mathf.MoveTowards(transform.position.y, targetY, jumpSpeed * Time.deltaTime);
        float newX = Mathf.Lerp(transform.position.x, targetPosition.x, laneChangeSpeed * Time.deltaTime); //функц≥€ Ћерп - л≥н≥йна ≥нтерпол€ц≥€ дозво€лЇ плавно перем≥щати, а не ривками
        transform.position = new Vector3 (newX, newY, transform.position.z);

        float different = targetPosition.x - transform.position.x; // р≥зниц€ м≥ж ти де ми Ї ≥ куди пр€муЇмо
        Quaternion targetRotation = Quaternion.Euler(0, different *tiltAmount, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, laneChangeSpeed * Time.deltaTime);
    }
    public void ForceGround()
    {
        targetY = -0.1f; // Ќасильно кажемо, що наша ц≥ль Ч земл€
        playerSpeed = Mathf.MoveTowards(playerSpeed, 0f, brakeSpeed * Time.deltaTime);
        maxSpeed = 0f;
        speedAcceleration = 0f;
    }
}
