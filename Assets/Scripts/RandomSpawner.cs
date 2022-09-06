using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private GameObject area;
    private List<Tuple<int,int>> randomPos = new List<Tuple<int,int>>();
    private void Start()
    {
        Spawn(20);
    }

    void Update()
    {
        if (area.transform.childCount == 0)
        {
            randomPos.Clear();
            Spawn(20);
        }
    }

    private void Spawn(int x)
    {
        for (var i = 0; i < x; i++)
        {
            SpawnCollectables();
        }
    }

    private void SpawnCollectables()
    {
        var posX = GenerateRandomPos().Item1;
        var posZ = GenerateRandomPos().Item2;
        var randomSpawnPosition = new Vector3(posX, -0.4215912f, posZ);
        var newCollectable = Instantiate(collectablePrefab, randomSpawnPosition, Quaternion.identity);
        newCollectable.transform.parent = area.transform;
    }

    private Tuple<int,int> GenerateRandomPos()
    {
        int x,z;
        do {
            x = Random.Range(-9, 10);
            z = Random.Range(4, 15);
        } while (randomPos.Contains(new Tuple<int, int>(x,z)));
        randomPos.Add(new Tuple<int, int>(x,z));
        return new Tuple<int, int>(x,z);
    }

}
