using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform gameManager;
    int maxCountBall;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").transform;
    }
    private void Start()
    {
        UIManger.Instance.countBallText.text = "Count: " + gameManager.transform.childCount;

        maxCountBall = PlayerPrefs.GetInt("maxCount", 0);
        UIManger.Instance.countTextDialogMax.text = "Count: " + maxCountBall;
        InvokeRepeating("Spawn", 5f, 10f);
    }
    private void Spawn()
    { 
        if(gameManager.transform.childCount<50)
        {
            GameObject game=Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            game.transform.parent = gameManager.transform;
        }
        UIManger.Instance.countBallText.text = "Count: " + gameManager.transform.childCount;
        if(maxCountBall<gameManager.transform.childCount)
        {
            PlayerPrefs.SetInt("maxCount",gameManager.transform.childCount);
        }
        UIManger.Instance.countTextDialogMax.text = "Count: " + PlayerPrefs.GetInt("maxCount", 0);
    }

}

