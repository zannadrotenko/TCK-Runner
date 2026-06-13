using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] AudioSource buttonSound;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(Button());
    }

    IEnumerator Button()
    {
        buttonSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);

    }
}
