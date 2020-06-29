using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    [Header("Slider заряда электропушки")]
    public Slider slider;
    public GameObject sliderObject;

    [Header("Класс оружия")]
    Weapon weapon;

    [Header("Player")]
    public Text playerHealth;
    PlayerController player;

    private GameObject scientist;

    private void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (player.name != "Scientist with Gun1")
        {
            sliderObject.SetActive(false);
        }
    }
    void Update()
    {
        slider.value = weapon.workingTime;
    }
}
