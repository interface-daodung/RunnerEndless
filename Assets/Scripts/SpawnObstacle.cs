using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpawnObstacle : MonoBehaviour
{
    private List<Pool> ObstaclePool = new List<Pool>();
    private Pool CoinPool;
    private List<Transform> SpawnPosList;

    void Awake()
    {
        ObstaclePool.Add(FindAnyObjectByType<PylonPool>());
        ObstaclePool.Add(FindAnyObjectByType<FencePool>());
        CoinPool = FindAnyObjectByType<CoinPool>();
    }

    public void Spawn()
    {

        if (RoadSpawner.instance.roadCount < 3) return;

        SpawnPosList = transform.Cast<Transform>()
                                   .Where(t => t.name == "SpawnPos")
                                   .ToList();
        Pool ownerPool;
        // spawn obstacle
        if (Random.Range(0, 3) == 0)
        {
            // first
            ownerPool = ObstaclePool[Random.Range(0, ObstaclePool.Count)];
            InstantiateObstacle(ownerPool)
                .GetComponent<Obstacle>().ownerPool = ownerPool;
            //second
            ownerPool = ObstaclePool[Random.Range(0, ObstaclePool.Count)];
            InstantiateObstacle(ownerPool)
                .GetComponent<Obstacle>().ownerPool = ownerPool;
        }
        else
        {
            ownerPool = ObstaclePool[Random.Range(0, ObstaclePool.Count)];
            InstantiateObstacle(ownerPool)
                .GetComponent<Obstacle>().ownerPool = ownerPool;
        }
        // spawn coin
        SpawnPosList.AddRange(transform.Cast<Transform>()
                               .Where(t => t.name == "SpawnPosCoin")
                               .ToList());

        int len = Random.Range(1, 6);
        for (int i = 0; i < len; i++)
        {
            InstantiateObstacle(CoinPool).transform.position += Vector3.up * 1.4f;
        }
    }

    GameObject InstantiateObstacle(Pool Pool)
    {
        Transform SpawnPos = SpawnPosList[Random.Range(0, SpawnPosList.Count)];

        GameObject tmp = Pool.Get();
        tmp.transform.SetParent(transform);
        tmp.transform.position = SpawnPos.position;
        SpawnPosList.Remove(SpawnPos);
        return tmp;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoadSpawner.instance.SpawnRoad();
            // delay 2s trước khi Release
            Invoke(nameof(Release), 2f);
        }
    }

    private void Release()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
            {
                child.gameObject.GetComponent<Obstacle>().Release();
                // child.SetParent(null);
            }
            else if (child.CompareTag("Coin"))
            {

                child.gameObject.GetComponent<Coin>().Release();
                // child.SetParent(null);
            }
        }
        RoadSpawner.instance.roadPool.Release(gameObject);
    }
}
