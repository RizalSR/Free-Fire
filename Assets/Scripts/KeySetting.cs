using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{

    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text up, down, left, right, ak47, shotgun, reload, cam, shoot,run,jump;
    private GameObject currentKey;

    GameObject Panelku;

    //public static string upkey, downkey, rightkey, leftkey, 
    //    shootkey, ak47key, shotgunkey, camerakey, reloadkey;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(236, 116, 36, 255);
    // Start is called before the first frame update
    void Start()
    {
        Panelku = GameObject.Find("SettingPanel");

        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "UpArrow")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "DownArrow")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow")));
        keys.Add("AK47", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("AK47", "Alpha1")));
        keys.Add("ShotGun", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ShotGun", "Alpha2")));
        keys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reload", "R")));
        keys.Add("Camera", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Camera", "C")));
        keys.Add("Shoot", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "LeftControl")));
        keys.Add("Run", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Run", "LeftShift")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        ak47.text = keys["AK47"].ToString();
        shotgun.text = keys["ShotGun"].ToString();
        reload.text = keys["Reload"].ToString();
        cam.text = keys["Camera"].ToString();
        shoot.text = keys["Shoot"].ToString();
        run.text = keys["Run"].ToString();
        jump.text = keys["Jump"].ToString();

        PlayerAnimation.upkey = keys["Up"].ToString();
        PlayerAnimation.downkey = keys["Down"].ToString();
        PlayerAnimation.leftkey = keys["Left"].ToString();
        PlayerAnimation.rightkey = keys["Right"].ToString();
        PlayerAnimation.ak47key = keys["AK47"].ToString();
        PlayerAnimation.shotgunkey = keys["ShotGun"].ToString();
        PlayerAnimation.reloadkey = keys["Reload"].ToString();
        ChangeCamera.camerakey = keys["Camera"].ToString();
        PlayerAnimation.shootkey = keys["Shoot"].ToString();
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
        PlayerAnimation.upkey = keys["Up"].ToString();
        PlayerAnimation.downkey = keys["Down"].ToString();
        PlayerAnimation.leftkey = keys["Left"].ToString();
        PlayerAnimation.rightkey = keys["Right"].ToString();
        PlayerAnimation.ak47key = keys["AK47"].ToString();
        PlayerAnimation.shotgunkey = keys["ShotGun"].ToString();
        PlayerAnimation.reloadkey = keys["Reload"].ToString();
        ChangeCamera.camerakey = keys["Camera"].ToString();
        PlayerAnimation.shootkey = keys["Shoot"].ToString();
        FirstPersonController.runkey = keys["Run"].ToString();
        FirstPersonController.jumpkey = keys["Jump"].ToString();

        Panelku.SetActive(false);
    }
}

