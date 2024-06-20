using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllCardPanel1 : MonoBehaviour
{
    public GameObject Bg;
    public GameObject beforeCardPrefab;

    private void Awake()
    {
        //生成选卡栏的格子
        for (int i = 0; i < 12; i++)
        {
            GameObject beforeCard = Instantiate(beforeCardPrefab);
            beforeCard.transform.SetParent(Bg.transform, false);
            beforeCard.name = "Card" + i.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void InitCards()
    { 
        foreach (UpgradeWeaponInfoItem upgradeWeaponInfo in GameManager.Instance.upgradeWeaponInfo.upgradeWeaponInfoList)
        {
            Transform cardParent = Bg.transform.Find("Card" + upgradeWeaponInfo.upgradeWeaponId);
            GameObject reallyCard = Instantiate(upgradeWeaponInfo.cardPrefab2) as GameObject;
            reallyCard.GetComponent<Card2>().upgradeWeaponInfo = upgradeWeaponInfo;
            reallyCard.transform.SetParent(cardParent, false);
            reallyCard.transform.localPosition = Vector2.zero ;
            reallyCard.name = "BeforeCard";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBtnStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
