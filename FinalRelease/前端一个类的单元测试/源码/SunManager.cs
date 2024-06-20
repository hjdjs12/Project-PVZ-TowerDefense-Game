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
    private Vector3 sunPointTextPosition;
    public float produceTime;
    public float produceTimer;
    public GameObject sunPreFab;
    private bool isStartProduce = false;
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
        CalcSunPointTextPosition();
        StartProduce();
    }
    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }
    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }
    private void CalcSunPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        position.z = 0;
        sunPointTextPosition = position;
    }
    private void Update()
    {
        if (isStartProduce)
        {
            ProduceSun();
        }
    }
    public void StartProduce()
    {
        isStartProduce = false;
    }
    void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if(produceTimer  > produceTime)
        {
            produceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-4, 6.5f), 6.2f, -1);
            GameObject go = GameObject.Instantiate(sunPreFab,position,Quaternion.identity);

            position.y = Random.Range(-3.8f, 2.85f);
            go.GetComponent<Sun>().LinearTo(position);
        }
    }
}