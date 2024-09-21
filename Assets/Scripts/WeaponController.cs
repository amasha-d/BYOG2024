using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData startingWeapon; // Drag the ScriptableObject for the default weapon
    public Transform weaponSlot;      // The empty object where the weapon will be attached
    private GameObject currentWeapon;

    void Start()
    {
        EquipWeapon(startingWeapon);
    }

    public void EquipWeapon(WeaponData weaponData)
    {
        // Destroy the old weapon if any
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Instantiate the new weapon prefab at the weapon slot
        currentWeapon = Instantiate(weaponData.weaponPrefab, weaponSlot.position, weaponSlot.rotation, weaponSlot);
        currentWeapon.transform.localPosition = Vector3.zero;  // Reset position
        currentWeapon.transform.localRotation = Quaternion.identity;  // Reset rotation

        
        WeaponShoot weaponShoot = currentWeapon.GetComponent<WeaponShoot>();
        if (weaponShoot != null)
        {
            weaponShoot.SetWeaponStats(weaponData.fireRate, weaponData.damage, weaponData.range);
        }
    }
}
