using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectWeapons;
    public GameObject AK47;
    public GameObject Shotgun;
    
    void Start()
    {
        SwithWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (selectWeapons!=1)
            {
                SwithWeapon(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (selectWeapons!=2)
            {
                SwithWeapon(2);
            }
        }
    }

    void SwithWeapon(int tipeSenjata)
    {
        if (tipeSenjata == 1)
        {
            AK47.SetActive(true);
            Shotgun.SetActive(false);
            selectWeapons = 1;
        }
        if (tipeSenjata == 2)
        {
            AK47.SetActive(false);
            Shotgun.SetActive(true);
            selectWeapons = 2;
        }
    }
}
