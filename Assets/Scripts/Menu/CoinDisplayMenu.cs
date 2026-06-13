using UnityEngine;

public class CoinDisplayMenu : MonoBehaviour
{
    [SerializeField] GameObject totalCoinsDisplay;

    void Awake()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinsDisplay.GetComponent<TMPro.TMP_Text>().text = "" + totalCoins;
    }
}
