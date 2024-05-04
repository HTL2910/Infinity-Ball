using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int countHealth = 3;
    [SerializeField] GameObject boomVfx;
    public bool isImmortal=false;
    private void Start()
    {
        UIHeart();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            if (isImmortal == false)
            {
                countHealth--;

                UIHeart();
            

                if (countHealth <= 0)
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
                    Invoke("ChangedColorRed", 2f);
                    isImmortal = true;

                }
                Invoke("isNotImmotal", 2f);
            }
            GameObject boomVfxTmp = Instantiate(boomVfx);

            boomVfxTmp.transform.position = collision.transform.position;
            StartCoroutine(DestroyVfx(boomVfxTmp));
            Destroy(collision.gameObject);
        }
    }
    IEnumerator DestroyVfx(GameObject Obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(Obj);
    }    
    public void isNotImmotal()
    {
        isImmortal = false;
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
