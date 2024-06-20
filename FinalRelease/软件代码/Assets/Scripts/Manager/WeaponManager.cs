using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static WeaponManager Instance { get; private set; }
    public List<GameObject> weaponList;
    private void Awake()
    {
        Instance = this;
    }
    public void addWeapon(GameObject weapon)
    {
        weaponList.Add(weapon);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
