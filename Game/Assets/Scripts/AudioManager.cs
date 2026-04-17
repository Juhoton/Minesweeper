using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip gridClick;
    [SerializeField] private AudioClip bombClick;
    [SerializeField] private AudioClip winGame;
    [SerializeField] private AudioClip loseGame;

    [Header("Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float sfxVolume = 1f;

    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 1f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (sfxSource == null)
            sfxSource = gameObject.AddComponent<AudioSource>();

        if (musicSource == null)
            musicSource = gameObject.AddComponent<AudioSource>();

        sfxSource.playOnAwake = false;
        musicSource.playOnAwake = false;

        sfxSource.volume = sfxVolume;
        musicSource.volume = musicVolume;
    }

    
    // PUBLIC CALLABLE METHODS
    

    public void PlayButtonClick()
    {
        PlaySFX(buttonClick);
    }

    public void PlayGridClick()
    {
        PlaySFX(gridClick);
    }

    public void PlayBombClick()
    {
        PlaySFX(bombClick);
    }

    public void PlayWinGame()
    {
        PlaySFX(winGame);
    }

    public void PlayLoseGame()
    {
        PlaySFX(loseGame);
    }
    
    // CORE SFX FUNCTION
    
    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    // MUSIC

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // VOLUME CONTROL

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        sfxSource.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        musicSource.volume = value;
    }
}