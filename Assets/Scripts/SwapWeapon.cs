using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    int selectWeapon = 1;
    public GameObject AK47;
    public GameObject Shotgun;

    // Start is called before the first frame update
    void Start()
    {
        SwitchWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerAnimation.ak47key)))
        {
            if (selectWeapon != 1)
            {
                SwitchWeapon(1);
            }
        }
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerAnimation.shotgunkey)))
        {
            if (selectWeapon != 2)
            {
                SwitchWeapon(2);
            }
        }
    }

    void SwitchWeapon(int tipeSenjata)
    {
        if (tipeSenjata == 1)
        {
            AK47.SetActive(true);
            Shotgun.SetActive(false);
            selectWeapon = 1;
        }
        if (tipeSenjata == 2)
        {
            AK47.SetActive(false);
            Shotgun.SetActive(true);
            selectWeapon = 2;
        }
    }
}
