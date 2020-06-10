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

    [Header("Player")]
    public Text playerHealth;
    public PlayerController player;

    void Update()
    {
        slider.value = weapon.workingTime;
        playerHealth.text = player.health.ToString();
    }
}
