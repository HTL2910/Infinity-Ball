using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public TextMeshProUGUI countBallText;
    public TextMeshProUGUI timeText;
    public Button homeButton;
    public Transform hearts;
    public Sprite heart;
    public Sprite normalHeart;

    public GameObject Dialog;
    public TextMeshProUGUI countTextDialog;
    public TextMeshProUGUI timeTextDialog;

    public Button playAgainButton;
    public Button aceSpeedButton;

    public AudioSource audioSource;
    public AudioSource audioSourceGame;
    public AudioClip clipCollider;
    public AudioClip clipMove;
    public AudioClip clipGameOver;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
     
        Dialog.SetActive(false);
        audioSource.clip = clipMove;
        audioSource.Play();
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
