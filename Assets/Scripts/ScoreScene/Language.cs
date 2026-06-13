using UnityEngine;

public class Language : MonoBehaviour
{
    public GameObject uaCanvas;
    public GameObject engCanvas;

    void Awake()
    {
        string savedLang = PlayerPrefs.GetString("SelectedLanguage", "eng");

        if (savedLang == "ua")
        {
            uaCanvas.SetActive(true);
            engCanvas.SetActive(false);
        }
        else if (savedLang == "eng")
        {
            uaCanvas.SetActive(false);
            engCanvas.SetActive(true);
        }
    }
}
