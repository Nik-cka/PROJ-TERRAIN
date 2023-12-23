using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    //Данные метод работает при нахождении на батуте
    private void OnTriggerEnter(Collider other)
    {
        // Увеличиваем св-во прыжка игрока до 10 пунктов
        other.GetComponent<Jump>().jumpStrength = 10;

    }
    //Срабатывает, когда уходим с батута
    private void OnTriggerExit(Collider other)
    {
        //Возвращает прежнее св-во прыжка игрока (2)
        other.GetComponent<Jump>().jumpStrength = 2;
       
    }
}
