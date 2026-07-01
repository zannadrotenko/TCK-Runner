using UnityEngine;

public class SpecialCoinController : MonoBehaviour
{
    [SerializeField] GameObject bar0;
    [SerializeField] GameObject bar3;
    [SerializeField] GameObject bar7;
    [SerializeField] GameObject bar15;
    [SerializeField] GameObject bar30;
    [SerializeField] GameObject notEnoughMoney;
    [SerializeField] GameObject howMuchMissing;
    private void Start()
    {
        notEnoughMoney.SetActive(false);
        howMuchMissing.SetActive(false);
        int currentLevel = PlayerPrefs.GetInt("SpecialCoinLevel", 0);
        if (currentLevel == 0)
        {
            bar0.SetActive(true);
            bar3.SetActive(false);
            bar7.SetActive(false);
            bar15.SetActive(false);
            bar30.SetActive(false);
        }
        else if (currentLevel == 1)
        {
            bar0.SetActive(false);
            bar3.SetActive(true);
            bar7.SetActive(false);
            bar15.SetActive(false);
            bar30.SetActive(false);
        }
        else if (currentLevel == 2)
        {
            bar0.SetActive(false);
            bar3.SetActive(false);
            bar7.SetActive(true);
            bar15.SetActive(false);
            bar30.SetActive(false);
        }
        else if (currentLevel == 3)
        {
            bar0.SetActive(false);
            bar3.SetActive(false);
            bar7.SetActive(false);
            bar15.SetActive(true);
            bar30.SetActive(false);
        }
        else if (currentLevel == 4)
        {
            bar0.SetActive(false);
            bar3.SetActive(false);
            bar7.SetActive(false);
            bar15.SetActive(false);
            bar30.SetActive(true);
        }
    }
    public void BuySpecialCoinUpgrade()
    {
        int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        int currentLevel = PlayerPrefs.GetInt("SpecialCoinLevel", 0);


        if (currentLevel == 0 && currentCoins >= 100)
        {
            PlayerPrefs.SetInt("TotalCoins", currentCoins - 100);
            PlayerPrefs.SetInt("SpecialCoinLevel", 1);           
            PlayerPrefs.Save();
            bar0.SetActive(false);
            bar3.SetActive(true);
            Debug.Log("Куплено Рівень 1 (3%)");
        }
        
        else if (currentLevel == 1 && currentCoins >= 250)
        {
            PlayerPrefs.SetInt("TotalCoins", currentCoins - 250);
            PlayerPrefs.SetInt("SpecialCoinLevel", 2);
            PlayerPrefs.Save();
            bar3.SetActive(false);
            bar7.SetActive(true);
            Debug.Log("Куплено Рівень 2 (7%)");
        }
        
        else if (currentLevel == 2 && currentCoins >= 1000)
        {
            PlayerPrefs.SetInt("TotalCoins", currentCoins - 1000);
            PlayerPrefs.SetInt("SpecialCoinLevel", 3);
            PlayerPrefs.Save();
            bar7.SetActive(false);
            bar15.SetActive(true);
            Debug.Log("Куплено Рівень 3 (15%)");
        }
        
        else if (currentLevel == 3 && currentCoins >= 3000)
        {
            PlayerPrefs.SetInt("TotalCoins", currentCoins - 3000);
            PlayerPrefs.SetInt("SpecialCoinLevel", 4);
            PlayerPrefs.Save();
            bar15.SetActive(false);
            bar30.SetActive(true);
            Debug.Log("Куплено Рівень 4 (30%)");
        }
        else
        {
            notEnoughMoney.SetActive(true);
            howMuchMissing.SetActive(true);
            howMuchMissing.GetComponent<TMPro.TMP_Text>().text = "" + 100;
            Debug.Log("Недостатньо монет або вже максимальний рівень!");
        }
    }
}
