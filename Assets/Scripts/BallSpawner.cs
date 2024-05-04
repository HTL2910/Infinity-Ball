using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    int maxCountBall;
    [SerializeField] private Transform ballsEnemy;
   
    private void Start()
    {
        UIManger.Instance.countBallText.text = "Count: " + ballsEnemy.transform.childCount;

        maxCountBall = PlayerPrefs.GetInt("maxCount", 0);
        UIManger.Instance.countTextDialogMax.text = "Count: " + maxCountBall;
        InvokeRepeating("Spawn", 5f, 10f);
    }
    private void Spawn()
    { 
        if(ballsEnemy.transform.childCount<50)
        {
            GameObject game=Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            game.transform.position=gameObject.transform.position;
            game.transform.parent = ballsEnemy.transform;
        }
        UIManger.Instance.countBallText.text = "Count: " + ballsEnemy.transform.childCount;
        if(maxCountBall<ballsEnemy.transform.childCount)
        {
            PlayerPrefs.SetInt("maxCount", ballsEnemy.transform.childCount);
        }
        UIManger.Instance.countTextDialogMax.text = "Count: " + PlayerPrefs.GetInt("maxCount", 0);
        PlayerPrefs.Save();
    }

}

