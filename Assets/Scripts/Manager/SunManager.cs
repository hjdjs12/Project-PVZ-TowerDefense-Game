using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance
    { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField]
    private int sunPoint;
    public TextMeshProUGUI sunPointText;
    public int SunPoint
    {
        get { return sunPoint; }
    }
    public void UpdateSunPointText()
    {
        sunPointText.text=  SunPoint.ToString();
    }
    private void Start()
    {
        UpdateSunPointText();
    }
    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
}