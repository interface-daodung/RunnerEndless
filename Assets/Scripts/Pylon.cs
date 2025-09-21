using UnityEngine;

public class pylon : MonoBehaviour
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
}
