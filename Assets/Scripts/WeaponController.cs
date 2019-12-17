using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class WeaponController : MonoBehaviour
{
    public static int ammo;
    int add;
    bool trigger = true;
    public float damage = 3f;
    public float range = 100f;
    public float force = 30f;
    public float fireRate = 10f;
    private float timeFire = 0f;
    public int health = 100;
    public int ammoStock = 30;
    public static int ammoMag = 90;
    public Slider healthBar;
    [SerializeField]
    Camera FPSCamera, TPSCamera;
    public AudioSource AK47Shot;
    public AudioSource ShotgunShot;
    public AudioSource WeaponReload;

    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoStock;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), Data.shootkey)) && Time.time >= timeFire && trigger == true)
        {
            timeFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), Data.reloadkey)) && ammo < ammoStock)
        {
            if (ammoMag != 0)
            {
                trigger = false;
                WeaponReload.Play();
                StartCoroutine(waitReload());
            }
            else
            {
                Debug.Log("Peluru Habis");
            }
        }
        if (AIEnemyController.GiveDamage == true)
        {
            health -= AIEnemyController.EnemyDamage;
            healthBar.value = health;
            if (health <= 0)
            {
                Debug.Log("Player Mati");
                SceneManager.LoadScene("Game Over");
                AIEnemyController.GiveDamage = false;
                Restart();
            }
        }
    }

    IEnumerator waitReload()
    {
        yield return new WaitForSeconds(2.5f);
        if (ammoMag <= ammoStock)
        {
            ammo = (ammo + ammoMag);
            add = ammo - ammoStock;
            if (add < 0)
            {
                ammoMag = 0;
            }
            else
            {
                ammoMag = add;
                ammo = ammoStock;
                Debug.Log("Isi Peluru");
            }
        }
        else
        {
            add = (ammo - ammoStock) * -1;
            ammo = ammo + add;
            ammoMag = ammoMag - add;
        }
        trigger = true;
    }

    public void Shoot()
    {
        if (ammo != 0)
        {
            AK47Shot.Play();
            ShotgunShot.Play();
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.gameObject.SendMessage("TakeDamage", damage);
                }
                if (hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * force);
            }
            ammo -= 1;
        }
    }

    public void Restart()
    {
        health = 100;
        healthBar.value = health;
        ammoMag = 90;
        ammo = ammoStock;
    }
}
