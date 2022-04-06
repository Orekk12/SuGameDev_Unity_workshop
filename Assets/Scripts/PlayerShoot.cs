using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public float fireRateCd = 0.5f;

    private float lastShootTime = -999f;
    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = -999f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CheckCooldown())//1.Adým
        {
            Shoot();
        }
    }

    void Shoot()//2.Adým
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);

        Destroy(bullet, 10f);
    }

    bool CheckCooldown()
    {
        if (lastShootTime + fireRateCd <= Time.time)
        {
            lastShootTime = Time.time;
            return true;
        }
        return false;
    }
}
