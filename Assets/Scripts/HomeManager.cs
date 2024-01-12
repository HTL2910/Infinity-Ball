using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private GameObject PanelDialog;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private Slider music;
    private void Start()
    {
        PanelDialog?.SetActive(false);
        PlayerPrefs.GetFloat("audioVolume", 0.5f);
        PlayerPrefs.GetFloat("musicVolume", 0.5f);
        audioSlider.onValueChanged.AddListener(HandleSliderMusicValueChanged);
        music.onValueChanged.AddListener(HandleSliderAudioValueChanged);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OK()
    {
        PanelDialog?.SetActive(false);
    }
    public void Setting()
    {
        PanelDialog?.SetActive(true);
    }
    private void HandleSliderMusicValueChanged(float value)
    {
        
        PlayerPrefs.SetFloat("musicVolume", music.value);

    }
    private void HandleSliderAudioValueChanged(float value)
    {
        PlayerPrefs.SetFloat("audioVolume", audioSlider.value);
    }
}
