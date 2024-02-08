using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    // Start is called before the first frame update
    public void spawnWeapon()
    {
        Instantiate(weaponPrefab);
    }
}
