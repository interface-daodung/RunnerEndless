using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> ObstaclePrefab;
    [SerializeField] private GameObject CoinPrefab;
    private List<Transform> SpawnPosList;

    public void Spawn()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
            {
                child.SetParent(null);
                child.gameObject.SetActive(false);
            }
        }
        if (RoadSpawner.instance.roadCount < 3) return;

        SpawnPosList = transform.Cast<Transform>()
                                   .Where(t => t.name == "SpawnPos")
                                   .ToList();
        // spawn obstacle
        if (Random.Range(0, 3) == 0)
        {
            // first
            InstantiateObstacle(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Count)]);
            //second
            InstantiateObstacle(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Count)]);
        }
        else
        {
            InstantiateObstacle(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Count)]);
        }
        // spawn coin
        SpawnPosList.AddRange(transform.Cast<Transform>()
                               .Where(t => t.name == "SpawnPosCoin")
                               .ToList());

        int len = Random.Range(0, 6);
        for (int i = 0; i < len; i++)
        {
            InstantiateObstacle(CoinPrefab).transform.position += Vector3.up * 1.4f;
        }
    }

    GameObject InstantiateObstacle(GameObject Prefab)
    {
        Transform SpawnPos = SpawnPosList[Random.Range(0, SpawnPosList.Count)];

        GameObject ObstacleTmp = Instantiate(Prefab, SpawnPos.position, Quaternion.identity);
        ObstacleTmp.transform.SetParent(transform);
        SpawnPosList.Remove(SpawnPos);
        return ObstacleTmp;
    }
}
