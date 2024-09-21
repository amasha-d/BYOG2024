using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
        public string weaponName;
        public GameObject weaponPrefab; // The prefab for the weapon
        public float fireRate;
        public float damage;
        public float range;
       // public Sprite icon; // Optional: For UI icons if needed
    
}
