using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Menu/WeaponInfo", fileName = "WeaponInfo", order = 1)]

public class WeaponInfo : ScriptableObject
{
    public List<WeaponInfoItem> weaponInfoList = new List<WeaponInfoItem>(); 

}

[System.Serializable]
public class WeaponInfoItem
{
    public int weaponId;
    public string weaponName;
    public string description;
    public string damage;
    public string cost;
    public string hp;
    public Sprite weaponSprite;
    public GameObject cardPrefab;

    override
    public string ToString()
    {
        return "[id]: " + weaponId.ToString();
    }
}