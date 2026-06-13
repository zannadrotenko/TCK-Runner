using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carModels;
    [SerializeField] float speed = 15f;
    [SerializeField] float maxSpeed = 30f;
    public float speedAcceleration = 0.05f;
    [SerializeField] float spawnInterval = 1.0f;

    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, spawnInterval); //InvokeRepeating - це "будильник" з автоповтором."SpawnCar" Ч назва функц≥њ, €ку треба запускати. 0f Ч через ск≥льки секунд почати перший запуск(0 = миттЇво).spawnInterval Ч через €кий ≥нтервал повторювати.
    }

    private void Update()
    {
        if (speed < maxSpeed)
        {
            speed += speedAcceleration * Time.deltaTime;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void SpawnCar()
    {
        float[] lanes = { -4f, 0f, 4f };
        float randomLane = lanes[Random.Range(0, lanes.Length)];

        int randomCarIndex = Random.Range(0, carModels.Length);
        GameObject selectedCar = carModels[randomCarIndex]; //рандом виб≥р з моделей

        Vector3 spawnPos = new Vector3(randomLane, transform.position.y, transform.position.z); //спавн машини
        GameObject spawnedCar = Instantiate(selectedCar, spawnPos, selectedCar.transform.rotation);
        spawnedCar.SetActive(true);
    }
   
}

