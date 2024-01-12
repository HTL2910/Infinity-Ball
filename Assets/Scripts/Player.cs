using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int countHealth = 3;
    private void Start()
    {
        UIHeart();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            countHealth--;

            UIHeart();
            if (countHealth<=0)
            {
                UIManger.Instance.audioSourceGame.PlayOneShot(UIManger.Instance.clipGameOver);
                Destroy(gameObject);
                UIManger.Instance.Dialog.SetActive(true);
                UIManger.Instance.timeTextDialog.text = UIManger.Instance.timeText.text;
                UIManger.Instance.countTextDialog.text = UIManger.Instance.countBallText.text;
                Time.timeScale = 0;
                
            }
            else
            {
                UIManger.Instance.audioSourceGame.PlayOneShot(UIManger.Instance.clipCollider);
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Invoke("ChangedColorRed", 0.5f);
                
            }
            
        }
    }
    private void ChangedColorRed()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void UIHeart()
    {
        for(int i=0;i<UIManger.Instance.hearts.childCount;i++)
        {
            UIManger.Instance.hearts.GetChild(i).GetComponent<Image>().sprite = UIManger.Instance.normalHeart;
        }
        for (int i = 0; i < countHealth; i++)
        {
            UIManger.Instance.hearts.GetChild(i).GetComponent<Image>().sprite=UIManger.Instance.heart;
        }
    }
}
