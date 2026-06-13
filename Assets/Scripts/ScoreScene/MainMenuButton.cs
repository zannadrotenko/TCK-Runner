using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] AudioSource buttonSound;
    public void MainMenu()
    {
        StartCoroutine(MenuButton());
    }

    IEnumerator MenuButton()
    {
        buttonSound.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
