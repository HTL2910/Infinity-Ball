using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").transform;
    }
    private void Start()
    {
        InvokeRepeating("Spawn", 5f, 10f);
    }
    private void Spawn()
    { 
        if(gameManager.transform.childCount<15)
        {
            GameObject game=Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            game.transform.parent = gameManager.transform;
        }    
        
    }

}

