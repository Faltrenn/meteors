using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private float spawnRate;
    private float timer;

    void Start() {
        InvokeRepeating("SpawnMeteor", 0f, spawnRate);
    }

    void SpawnMeteor() {
        int choice = UnityEngine.Random.Range(0,2);
        int choice2 = UnityEngine.Random.Range(0,2);
        float x, y;
        if(choice % 2 == 0) {
            x = (choice2 % 2 == 0 ? 1 : -1) * 10;
            y = UnityEngine.Random.Range(-6.5f, 6.5f);
        } else {
            x = UnityEngine.Random.Range(-9.5f, 9.5f);
            y = (choice2 % 2 == 0 ? 1 : -1) * 7;
        }

        Vector3 mPosition = new Vector3(x, y, 0f);
        GameObject m = Instantiate(meteor, mPosition, quaternion.identity);
        
        float targetX = UnityEngine.Random.Range(-8f, 8f);
        float targetY = UnityEngine.Random.Range(-5f, 5f);
        Vector3 targetPosition = new Vector3(targetX, targetY, 0f);

        m.transform.up = targetPosition - mPosition;
    }
}
