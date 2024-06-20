using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllCardPanel : MonoBehaviour
{
    public GameObject Bg;
    public GameObject beforeCardPrefab;

    private void Awake()
    {
        Debug.Log(ChooseManager.Instance.getNextScene());
        //生成选卡栏的格子
        for (int i = 0; i < 10; i++)
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
        foreach (WeaponInfoItem weaponInfo in GameManager.Instance.weaponInfo.weaponInfoList)
        {
            Transform cardParent = Bg.transform.Find("Card" + weaponInfo.weaponId);
            GameObject reallyCard = Instantiate(weaponInfo.cardPrefab) as GameObject;
            reallyCard.GetComponent<Card1>().weaponInfo = weaponInfo;
            reallyCard.transform.SetParent(cardParent, false);
            reallyCard.transform.localPosition = Vector2.zero;
            reallyCard.name = "BeforeCard";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBtnStart()
    {
        //GameManager.Instance.gameStart = true;
        Debug.Log(ChooseManager.Instance.getNextScene());
        //ChooseManager.Instance.setNextScene("Scene");
        SceneManager.LoadScene("LoadingScene");
    }
}
