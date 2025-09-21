using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BMGSource;
    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip gameOverSound;
    void Start()
    {
        BMGSourceStart();
    }

    public void BMGSourceStart()
    {
        BMGSource.clip = backgroundMusic;
        BMGSource.Play();
    }

    public void PlayCoinCollectSound()
    {
        SFXSource.PlayOneShot(coinCollectSound);
    }
    public void PlayJumpSound()
    {
        SFXSource.PlayOneShot(jumpSound);
    }
    public void PlayGameOverSound()
    {
        BMGSource.Stop();
        BMGSource.clip = gameOverSound;
        BMGSource.Play();
    }
}
