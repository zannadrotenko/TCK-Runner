using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float maxSpeed = 30f;
    public float speedAcceleration = 0.05f; //як швидко зб≥льшуЇтьс€ швидк≥сть кожну секунду
    public float laneChangeSpeed = 15f; // швидк≥сть переходу м≥ж смугами
    public float tiltAmount = 10f; // сила нахилу при поворотах


    // 1 - л≥во, 2 - центр, 3 - право
    private int mainLane = 2;// початкова л≥н≥€ - центр
    private int previousLane = 2;
    private int widthLane = 4; // ширина смуг

    public float jumpHeight = 4f;    // ћаксимальна висота стрибка
    public float jumpSpeed = 10f;    // як швидко в≥н зл≥таЇ ≥ падаЇ
    private float targetY = -0.1f;   // точка в €ку вертаЇмось п≥сл€ стрибка
    public Animator anim;
    //властивост≥ буса “цк
    public GameObject tckObject;     
    public float tckDuration = 4f;   // —к≥льки секунд охоронець буде б≥гти за нами
    private float tckTimer = 0f;     // таймер зворотного в≥дл≥ку
    private bool isTckActive = false;

    [SerializeField] GameObject fadeOut;

    void Update()
    {   //зб≥льшенн€ швидкост≥ гравц€ ≥ рух вперед
        if (playerSpeed < maxSpeed)
        {
            playerSpeed += speedAcceleration * Time.deltaTime;// «б≥льшуЇмо швидк≥сть з часом, але не вище за maxSpeed
        }

        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime); //пост≥йно рухаЇмо поточну позиц≥ю гравц€ (transform) вперед множачи на швидк≥сть гравц€ ≥ на час одного кадру

        //таймер тцк
        if (isTckActive)
        {
            tckTimer -= Time.deltaTime; // ожен кадр зменшуЇмо таймер на час, що минув
            if (tckTimer <= 0)
            {
                isTckActive = false;
                tckObject.SetActive(false);
            }
        }
        // якщо натиснути праворуч
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) // €кщо (¬водна система. нопка Ќатиснута(Ќазва  нопки.ѕрава—тр≥лка))
        {
            if (mainLane < 3)
            {
                previousLane = mainLane; // «јѕјћ'я“ќ¬”™ћќ поточну смугу €к попередню перед рухом праворуч
                mainLane++; // то номер л≥н≥њ зб≥льшуЇтьс€. ѕочаткова 2, то буде 3
            }
        }
        // якщо натиснути л≥воруч
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (mainLane > 1)
            {
                previousLane = mainLane;
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
        transform.position = new Vector3(newX, newY, transform.position.z);

        //плавн≥сть повороту м≥ж смугами
        float different = targetPosition.x - transform.position.x; //р≥зниц€ м≥ж ти де ми Ї ≥ куди пр€муЇмо
        Quaternion targetRotation = Quaternion.Euler(0, different * tiltAmount, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, laneChangeSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        // ѕерев≥р€Їмо, чи об'Їкт, в €кий ми вр≥залис€, маЇ тег "tck"
        if (other.CompareTag("tck"))
        {
            Debug.Log("«ачепили боковий тригер!");

            // ¬≤ƒ— ≤ : вертаЇмо гравц€ на безпечну смугу, з €коњ в≥н починав рух
            mainLane = previousLane;
            isTckActive = true;
            tckTimer = tckDuration; // ¬иставл€Їмо таймер (наприклад, 4 секунди)
            tckObject.SetActive(true); // ¬микаЇмо об'Їкт охоронц€ на сцен≥
           
        }
    }
}
