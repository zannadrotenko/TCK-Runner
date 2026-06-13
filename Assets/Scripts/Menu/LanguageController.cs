using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageController : MonoBehaviour
{
    public GameObject LanguagePanel;
    public GameObject uaCanvas;
    public GameObject engCanvas;
    void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedLanguage"))
        {
            LanguagePanel.SetActive(false);
            ApplyLanguage(PlayerPrefs.GetString("SelectedLanguage"));
        }
        else
        {
            LanguagePanel.SetActive(true);
            uaCanvas.SetActive(false);
            engCanvas.SetActive(false);
        }
    }
    public void ChooseUkrainian()
    {
        SaveLanguage("ua");
    }
    public void ChooseEnglish()
    {
        SaveLanguage("eng");
    }
    private void SaveLanguage(string langCode)
    {
        // Запам'ятовуємо вибір мови між всіма сценками
        PlayerPrefs.SetString("SelectedLanguage", langCode);
        PlayerPrefs.Save();
        ApplyLanguage(langCode);
        LanguagePanel.SetActive(false);
    }
    private void ApplyLanguage(string lang)
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
    public void ChangeLanguage()
    {
           PlayerPrefs.DeleteKey("SelectedLanguage");
           LanguagePanel.SetActive(true);
           uaCanvas.SetActive(false);
           engCanvas.SetActive(false);
           Debug.Log("Тест: вибір скинуто.");
    }
}
