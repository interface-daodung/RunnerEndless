using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int pointValue = 1;
    [SerializeField] private float rotationSpeed = 90f; // degrees per second
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Increment the player's coin count
            GameManager.Instance.AddScore(pointValue);
            FindAnyObjectByType<AudioManager>().PlayCoinCollectSound();
            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
