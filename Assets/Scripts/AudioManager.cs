using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioClip _coinSound;

    private AudioSource _audioSource;

    public static AudioManager instance { get; private set; }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
        }
        _coinSound = Resources.Load<AudioClip>("Sounds/coin01");

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoin()
    {
        _audioSource.PlayOneShot(_coinSound);
    }
}
