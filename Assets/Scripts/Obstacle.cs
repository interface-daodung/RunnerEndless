using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Die();
        }
    }

    public Pool ownerPool;
    public void Release()
    {
        if (gameObject.activeSelf)
        {
            ownerPool.Release(gameObject);
        }
        // if (transform.gameObject.name.StartsWith("fence"))
        // {
        //     RoadSpawner.instance.fencePool.Release(gameObject);
        // }
        // else   if (transform.gameObject.name.StartsWith("pylon"))
        // {
        //     RoadSpawner.instance.pylonPool.Release(gameObject);
        // }
    }
}
