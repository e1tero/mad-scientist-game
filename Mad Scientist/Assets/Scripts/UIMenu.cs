using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject lockContent;
    public GameObject buttons;

    public void LockContent()
    {
        lockContent.SetActive(true);
        buttons.SetActive(false);
    }

    public void WeaponButton()
    {
        lockContent.SetActive(false);
        buttons.SetActive(true);
    }
}
