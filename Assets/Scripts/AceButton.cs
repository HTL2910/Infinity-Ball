using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonDown = false;
    private float normalSpeed = 5f;
    private float aceSpeed = 10f;

    private void Update()
    {
        if (isButtonDown)
        {
            // Nếu button đang được giữ, thì gọi hàm xử lý damage với giá trị pressedDamage
            HandleDamage(aceSpeed);
        }
        else
        {
            // Nếu button không được giữ, thì gọi hàm xử lý damage với giá trị defaultDamage
            HandleDamage(normalSpeed);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Khi button được nhấn
        isButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Khi button được nhả ra
        isButtonDown = false;
    }

    private void HandleDamage(float speed)
    {
        if (GameObject.Find("Player") != null)
        {
            GameObject.Find("Player").GetComponent<JoyStickMove>().playerSpeed = speed;
        }
        else { }
        
    }

}
