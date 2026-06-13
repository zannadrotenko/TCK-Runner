using UnityEngine;
using System.Collections;
public class CoinsDisplay : MonoBehaviour 
{
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject totalDisplay;

    private void Start()
    {
        int currentRun = PlayerPrefs.GetInt("CurrentRunCoins", 0);
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + currentRun;
        totalDisplay.GetComponent<TMPro.TMP_Text>().text = "" + totalCoins;
    }
}
