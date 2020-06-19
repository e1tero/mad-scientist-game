using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    [Header("Slider заряда электропушки")]
    public Slider slider;

    [Header("Класс оружия")]
    Weapon weapon;

    [Header("Player")]
    public Text playerHealth;
    PlayerController player;

    private void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        slider.value = weapon.workingTime;
        playerHealth.text = player.health.ToString();
    }
}
