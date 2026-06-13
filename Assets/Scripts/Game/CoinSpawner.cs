using System.Security.Cryptography;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coinGroup;
    [SerializeField] float speed = 15f;
    [SerializeField] float maxSpeed = 30f;
    public float speedAcceleration = 0.05f;
    [SerializeField] float spawnInterval = 4.0f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval); //InvokeRepeating - це "будильник" з автоповтором."SpawnCar" Ч назва функц≥њ, €ку треба запускати. 0f Ч через ск≥льки секунд почати перший запуск(0 = миттЇво).spawnInterval Ч через €кий ≥нтервал повторювати.
    }

    private void Update()
    {
        if (speed < maxSpeed)
        {
            speed += speedAcceleration * Time.deltaTime;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void SpawnCoin()
    {
        int randomCoinIndex = Random.Range(0, coinGroup.Length);
        GameObject selectedCoin = coinGroup[randomCoinIndex]; //рандом виб≥р з моделей

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); //спавн машини
        GameObject spawnedCoin = Instantiate(selectedCoin, spawnPos, selectedCoin.transform.rotation);
        spawnedCoin.SetActive(true);
    }
}