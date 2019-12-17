using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{

    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text  ak47, shotgun, reload, cam, shoot,run,jump;
    private GameObject currentKey;

    public GameObject Panelku;

    //public static string upkey, downkey, rightkey, leftkey, 
    //    shootkey, ak47key, shotgunkey, camerakey, reloadkey;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(236, 116, 36, 255);
    // Start is called before the first frame update
    void Start()
    {
        keys.Add("AK47", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AK47", "")));
        keys.Add("ShotGun", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ShotGun", "")));
        keys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reload", "")));
        keys.Add("Camera", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Camera", "")));
        keys.Add("Shoot", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "")));
        keys.Add("Run", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Run", "")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "")));

        ak47.text = keys["AK47"].ToString();
        shotgun.text = keys["ShotGun"].ToString();
        reload.text = keys["Reload"].ToString();
        cam.text = keys["Camera"].ToString();
        shoot.text = keys["Shoot"].ToString();
        run.text = keys["Run"].ToString();
        jump.text = keys["Jump"].ToString();


        Data.ak47key = keys["AK47"].ToString();
        Data.shotgunkey = keys["ShotGun"].ToString();
        Data.reloadkey = keys["Reload"].ToString();
        Data.camerakey = keys["Camera"].ToString();
        Data.shootkey = keys["Shoot"].ToString();
        FirstPersonController.runkey = keys["Run"].ToString();
        FirstPersonController.jumpkey = keys["Jump"].ToString();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {

                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
        Data.ak47key = keys["AK47"].ToString();
        Data.shotgunkey = keys["ShotGun"].ToString();
        Data.reloadkey = keys["Reload"].ToString();
        Data.camerakey = keys["Camera"].ToString();
        Data.shootkey = keys["Shoot"].ToString();
        FirstPersonController.runkey = keys["Run"].ToString();
        FirstPersonController.jumpkey = keys["Jump"].ToString();

        Panelku.SetActive(false);
    }
}

