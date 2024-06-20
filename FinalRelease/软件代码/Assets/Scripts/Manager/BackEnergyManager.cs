using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


enum BackState
{
    OFF,
    ON
}
public class BackEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    public float backtotalEnergy;
    BackState bs;
    public static BackEnergy Instance { get; private set; }
    public float duration = 1;
    public float totaltime = 0;
    public TextMeshProUGUI text;
    private void Awake()
    {
        Instance = this;
        bs = BackState.OFF;
    }
    void Start()
    {
        backtotalEnergy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            text.text = backtotalEnergy.ToString();
        }
        switch (bs) { 
           case BackState.OFF:
                break;
           case BackState.ON:
           {
                totaltime += Time.deltaTime;
                    Debug.Log(duration);
                if (totaltime > duration)
                {
                        Debug.Log("ABC");
                    decreaseBackTotalEnergy();
                    totaltime -= duration;
                }
                break;
           }
        }

    }
    public void TransitionToOn()
    {
        bs = BackState.ON;
    }
    public void TransitionToOFF()
    {
        bs = BackState.OFF;
    }
    public void decreaseBackTotalEnergy()
    {
        backtotalEnergy--;
        updateText();
    }
    public void increaseBackTotalEnergy(float Hp)
    {
        backtotalEnergy+=Hp/50;
        updateText();
    }
    public void decreaseOfUtimate()
    {
        backtotalEnergy -= 100;
        updateText();
    }
    public void updateText()
    {
        text.text = backtotalEnergy.ToString();
        if (backtotalEnergy <= 0)
        {
            PropertiesManager.Instance.allRecover();
            TransitionToOFF();  
        }
    }
}
