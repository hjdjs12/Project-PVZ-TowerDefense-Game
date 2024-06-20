using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameStart;
    public static GameManager Instance;
    public WeaponInfo weaponInfo;
    public UpgradeWeaponInfo upgradeWeaponInfo;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ReadData();
    }

    private void GameStart()
    {
        UIManager.Instance.InitUI();
    }

    void ReadData()
    {
        LoadTableNew();
    }

    public void LoadTableNew()
    {
        weaponInfo = Resources.Load("WeaponInfo") as WeaponInfo;
        upgradeWeaponInfo = Resources.Load("UpgradeWeaponInfo") as UpgradeWeaponInfo;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
 