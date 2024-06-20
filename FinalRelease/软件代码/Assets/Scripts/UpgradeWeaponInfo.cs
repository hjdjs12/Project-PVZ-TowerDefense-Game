using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Menu/UpgradeWeaponInfo", fileName = "UpgradeWeaponInfo", order = 2)]

public class UpgradeWeaponInfo : ScriptableObject
{
    public List<UpgradeWeaponInfoItem> upgradeWeaponInfoList = new List<UpgradeWeaponInfoItem>(); 

}

[System.Serializable]
public class UpgradeWeaponInfoItem
{
    public int upgradeWeaponId;
    public string upgradeWeaponName;
    public string description2;
    public GameObject cardPrefab2;

    override
    public string ToString()
    {
        return "[id]: " + upgradeWeaponId.ToString();
    }
}