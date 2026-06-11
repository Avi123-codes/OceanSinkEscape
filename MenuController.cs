using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;

    [Header("Audio")]
    public AudioMixer masterMixer;

    public AudioClip clickSound;

    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private AudioSource audioSource;

    void Awake()
    {
        if (masterMixer == null)
            Debug.LogError("Mixer missing.");

        if (musicSlider == null)
            Debug.LogError("Music Slider missing.");

        if (sfxSlider == null)
            Debug.LogError("SFX Slider missing.");
    }

    void Start()
    {
        audioSource =
            GetComponent<AudioSource>();

        float savedMusic =
            PlayerPrefs.GetFloat(
                "MusicVolume",
                1f
            );

        float savedSFX =
            PlayerPrefs.GetFloat(
                "SFXVolume",
                1f
            );

        musicSlider.value =
            savedMusic;

        sfxSlider.value =
            savedSFX;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
    }

    public void StartGame()
    {
        PlayClick();

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            "Main_Sink_Level"
        );
    }

    public void OpenOptions()
    {
        PlayClick();

        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        PlayClick();

        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void SetMusicVolume(float value)
    {
        float dB =
            Mathf.Log10(value) * 20f;

        masterMixer.SetFloat(
            "MusicVol",
            dB
        );

        PlayerPrefs.SetFloat(
            "MusicVolume",
            value
        );
    }

    public void SetSFXVolume(float value)
    {
        float dB =
            Mathf.Log10(value) * 20f;

        masterMixer.SetFloat(
            "SFXVol",
            dB
        );

        PlayerPrefs.SetFloat(
            "SFXVolume",
            value
        );
    }

    private void PlayClick()
    {
        if (audioSource != null &&
            clickSound != null)
        {
            audioSource.PlayOneShot(
                clickSound
            );
        }
    }
}
