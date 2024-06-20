using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponListManager : MonoBehaviour
{
    public GameObject weaponIconPrefab; // 预制体，用于生成植物图标
    public GameObject cardBgPrefab; //预制体，用于生成卡片背景
    public Transform weaponGridParent; // Grid Layout Group所在的父对象
    public Image weaponImage;
    public Text weaponNameText;
    public Text weaponDescriptionText;
    public Text weaponDamageText;
    public Text weaponCostText;
    public Text weaponHPText;

    public List<WeaponInfoItem> weaponInfos = new List<WeaponInfoItem>();

    // Start is called before the first frame update
    void Start()
    {
        weaponImage.color = new Color(weaponImage.color.r, weaponImage.color.g, weaponImage.color.b, 0); // 隐藏图像
        PopulateAlmanac();
    }

    private void PopulateAlmanac()
    {
        foreach (WeaponInfoItem weapon in weaponInfos)
        {
            // 创建卡片背景
            GameObject cardBg = Instantiate(cardBgPrefab, weaponGridParent);
            GameObject icon = Instantiate(weaponIconPrefab, cardBg.transform);
            Image iconImage = icon.GetComponent<Image>();

            iconImage.sprite = weapon.weaponSprite;
            // 确保图像不变形
            //AspectRatioFitter aspectFitter = icon.AddComponent<AspectRatioFitter>();
            //aspectFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;
            RectTransform iconRectTransform = icon.GetComponent<RectTransform>();
            iconRectTransform.SetParent(cardBg.transform, false); // 确保是卡片背景的子对象
            iconRectTransform.anchoredPosition = Vector2.zero; // 确保图标居中
            iconRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            iconRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            iconRectTransform.pivot = new Vector2(0.5f, 0.5f);
            iconRectTransform.sizeDelta = new Vector2(55, 70);
            icon.GetComponent<Button>().onClick.AddListener(() => ShowWeaponDetails(weapon));

            // 添加EventTrigger组件以处理鼠标悬停事件
            EventTrigger trigger = icon.AddComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((eventData) => { ShowWeaponDetails(weapon); });
            trigger.triggers.Add(entryEnter);

            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((eventData) => { ClearWeaponDetails(); });
            trigger.triggers.Add(entryExit);
        }
    }

    private void ShowWeaponDetails(WeaponInfoItem weapon)
    {
        weaponImage.sprite = weapon.weaponSprite;
        weaponImage.color = new Color(weaponImage.color.r, weaponImage.color.g, weaponImage.color.b, 1); // 显示图像
        weaponNameText.text = weapon.weaponName;
        weaponDescriptionText.text = weapon.description;
        weaponDamageText.text = "Damage: " + weapon.damage;
        weaponCostText.text = "Cost: " + weapon.cost;
        weaponHPText.text = "HP: " + weapon.hp;
    }

    private void ClearWeaponDetails()
    {
        weaponImage.sprite = null;
        weaponImage.color = new Color(weaponImage.color.r, weaponImage.color.g, weaponImage.color.b, 0); // 隐藏图像
        weaponNameText.text = "";
        weaponDescriptionText.text = "";
        weaponDamageText.text = "";
        weaponCostText.text = "";
        weaponHPText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
