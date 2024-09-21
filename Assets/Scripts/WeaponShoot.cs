using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float fireRate;
    private float damage;
    private float range;
    private float nextTimeToFire = 0f;

    public void SetWeaponStats(float fireRate, float damage, float range)
    {
        this.fireRate = fireRate;
        this.damage = damage;
        this.range = range;
    }

    void Update()
    {
        HandleShooting();
       
    }
    //Input.GetButton("Fire1") && 
    private void HandleShooting()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Add bullet behavior like damage, range, etc.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * range; // Example: shoot in the direction firePoint is facing
       
    }
}
