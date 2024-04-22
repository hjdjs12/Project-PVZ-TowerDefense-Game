using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SerumManager : MonoBehaviour
{
    public static SerumManager Instance
    { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField]
    private int serumPoint;
    public TextMeshProUGUI serumPointText;
    private Vector3 serumPointTextPosition;
    public float produceTime;
    public float produceTimer;
    public GameObject serumPrefab;
    private bool isStartProduce = false;
    public int SerumPoint
    {
        get { return serumPoint; }
    }
    public void UpdateserumPointText()
    {
        serumPointText.text = serumPoint.ToString();
    }
    private void Start()
    {
        UpdateserumPointText();
        CalcSerumPointTextPosition();
        StartProduce();
    }
    public void SubSerum(int point)
    {
        serumPoint -= point;
        UpdateserumPointText();
    }
    public void AddSerum(int point)
    {
        serumPoint += point;
        UpdateserumPointText();
    }
    public Vector3 GetSerumPointTextPosition()
    {
        return serumPointTextPosition;
    }
    private void CalcSerumPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(serumPointText.transform.position);
        position.z = 0;
        serumPointTextPosition = position;
    }
    private void Update()
    {
        if (isStartProduce)
        {
            Produceserum();
        }
    }
    public void StartProduce()
    {
        isStartProduce = false;
    }
    void Produceserum()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceTime)
        {
            produceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-4, 6.5f), 6.2f, -1);
            GameObject go = GameObject.Instantiate(serumPrefab, position, Quaternion.identity);

            position.y = Random.Range(-3.8f, 2.85f);
            go.GetComponent<Serum>().JumpTo(position);
        }
    }
}
