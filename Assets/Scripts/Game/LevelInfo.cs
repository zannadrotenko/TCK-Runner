using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;

    public static float scoreCount = 0;
    [SerializeField] GameObject scoreDisplay;
    [SerializeField] Transform playerTransform;

    private float startZ;

    void Start()
    {
        startZ = playerTransform.position.z;
    }

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + coinCount;

        float distance = playerTransform.position.z - startZ;
        float score = distance / 50f;

        if (score > scoreCount)
        {
            scoreCount = score;
        }

        scoreDisplay.GetComponent<TMPro.TMP_Text>().text = "" + Mathf.FloorToInt(scoreCount);
    }
}
