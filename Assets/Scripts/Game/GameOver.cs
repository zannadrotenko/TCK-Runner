using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Tck1;
    [SerializeField] GameObject Tck2;
    private void OnEnable()
    {
        StartCoroutine(LoadLevel());
        Tck1.SetActive(true);
        Tck2.SetActive(true);
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2.5f);
        int coinsThisRun = LevelInfo.coinCount;
        PlayerPrefs.SetInt("CurrentRunCoins", coinsThisRun);
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins += coinsThisRun;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }
}
