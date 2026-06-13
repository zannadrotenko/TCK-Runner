using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> playlist;

    private int previousTrackIndex = -1;

    void Start()
    {
        if (playlist == null || playlist.Count == 0)
        {
            Debug.LogWarning("Список треків порожній! Додайте аудіокліпи в інспекторі.");
            return;
        }

        // Запускаємо нескінченний цикл програвання музики
        StartCoroutine(PlayMusicPlaylist());
    }

    private System.Collections.IEnumerator PlayMusicPlaylist()
    {
        while (true)
        {
            // Вибираємо випадковий трек
            int randomIndex = GetRandomIndex();
            audioSource.clip = playlist[randomIndex];

            // Вмикаємо його
            audioSource.Play();

            // Чекаємо, поки трек повністю дограє, перш ніж перейти до наступного
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }

    private int GetRandomIndex()
    {
        // Якщо трек один, просто повертаємо його індекс
        if (playlist.Count == 1) return 0;

        int newIndex;

        // Цикл гарантує, що наступний трек не буде повторювати той, що щойно відіграв
        do
        {
            newIndex = Random.Range(0, playlist.Count);
        }
        while (newIndex == previousTrackIndex);

        previousTrackIndex = newIndex;
        return newIndex;
    }
}
