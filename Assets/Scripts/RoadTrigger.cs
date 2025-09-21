using UnityEngine;

public class roadTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoadSpawner.instance.SpawnRoad();
            // Destroy(transform.parent.gameObject, 2f);
            // delay 2s trước khi Release
            Invoke(nameof(ReleaseParent), 2f);
        }
    }

    private void ReleaseParent()
    {
        RoadSpawner.instance.roadPool.ReleaseRoad(transform.parent.gameObject);
    }
}
