using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDetailPanel : MonoBehaviour
{
    public static WeaponDetailPanel Instance;

    public Image weaponImage;
    public Text weaponNameText;
    public Text weaponDescriptionText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateWeaponDetails(Sprite sprite, string name, string description)
    {
        weaponImage.sprite = sprite;
        weaponNameText.text = name;
        weaponDescriptionText.text = description;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
