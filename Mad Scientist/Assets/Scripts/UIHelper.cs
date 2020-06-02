using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    [Header("Slider заряда электропушки")]
    public Slider slider;

    [Header("Класс оружия")]
    public Weapon weapon;
    
    void Update()
    {
        slider.value = weapon.workingTime;
    }
}
