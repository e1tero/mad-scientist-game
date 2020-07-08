using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    public static int _static;
    public GameObject firstScientist;
    public GameObject secondScientist;

    public Text Speed;
    public Text Health;
    public Text Damage;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (_static == 1)
            {
                secondScientist.SetActive(false);
                firstScientist.SetActive(true);
                //Instantiate(firstScientist, new Vector3(12, 2, 0), firstScientist.transform.rotation);
            }
            else if (_static == 2)
            {
                firstScientist.SetActive(false);
                secondScientist.SetActive(true);
                //Instantiate(secondScientist, new Vector3(12, 2, 0), firstScientist.transform.rotation);
            }
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (_static == 1)
            {
                secondScientist.SetActive(false);
                firstScientist.SetActive(true);
            }

            else if (_static == 2)
            {
                secondScientist.SetActive(true);
                firstScientist.SetActive(false);
            }
        }
    }

    public void SelectFirst()
    {
        _static = 1;
        Speed.text = 5.ToString();
        Health.text = 70.ToString();
        Damage.text = 10.ToString();
    }

    public void SelectSecond()
    {
        _static = 2;
        Speed.text = 7.ToString();
        Health.text = 100.ToString();
        Damage.text = 6.ToString();
    }

    public void SelectThird()
    {
        _static = 3;
        Speed.text = 4.ToString();
        Health.text = 120.ToString();
        Damage.text = 10.ToString();
    }

}
