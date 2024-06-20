using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGridManager : MonoBehaviour
{
    public GameObject weaponButtonPrefab;
    public Transform gridParent;
    public Sprite[] weaponSprites;
    public string[] weaponNames;
    public string[] weaponDescriptions;
    // Start is called before the first frame update
    void Start()
    {
        PopulateGrid();
    }

    void PopulateGrid()
    {
        for(int i = 0; i < weaponSprites.Length; i++)
        {
            GameObject newButton = Instantiate(weaponButtonPrefab, gridParent);
            newButton.GetComponent<Image>().sprite = weaponSprites[i];
            int index = i;
            newButton.GetComponent<Button>().onClick.AddListener(
                () => OnWeaponButtonClicked(index)
            );
        }
    }

    void OnWeaponButtonClicked(int index)
    {
        WeaponDetailPanel.Instance.UpdateWeaponDetails(weaponSprites[index], weaponNames[index], weaponDescriptions[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
