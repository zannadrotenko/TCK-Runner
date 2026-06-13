using UnityEngine;

public class SpecialCoinBuy : MonoBehaviour
{
    public int coinLevel = 0;
    public int maxLevel = 4;

    void Start()
    {
        coinLevel = PlayerPrefs.GetInt("SpecialCoinLevel", 0);

    }
    public void BuyCoinUpgrade()
    {
        // Перевіряємо, чи рівень ще не максимальний
        if (coinLevel < maxLevel)
        {
            coinLevel++;
            PlayerPrefs.SetInt("SpecialCoinLevel", coinLevel);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Максимальний рівень уже досягнуто!");
        }
    }
}
