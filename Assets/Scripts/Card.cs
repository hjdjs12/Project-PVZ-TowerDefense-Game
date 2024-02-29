using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum CardState
{
    Cooling,
    Ready,
    WaitingSun
}

public enum PlantType
{
    Sunflower,
    PeaShooter
}
public class Card : MonoBehaviour
{
    
    //冷却，可以被点击  不可用
    private CardState cardState = CardState.Cooling;
    public PlantType plantType = PlantType.Sunflower;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    //冷却时间
    [SerializeField]
    private float cdTime = 2;
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint = 50;



    // Update is called once per frame
    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }
    void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;
        
        if(cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }
    }
    void ReadyUpdate()
    {
        if(needSunPoint > SunManager.Instance.SunPoint)
        {
            TransitionToWaitingSun() ;
        }

    }
    void WaitingSunUpdate()
    {
        if(needSunPoint <= SunManager.Instance.SunPoint)
        {
            TransitionToReady();
        }
    }
    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToReady()
    {
        cardState = CardState.Ready;
        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }
    public void OnClick()
    {
        if (needSunPoint > SunManager.Instance.SunPoint) return;


        //TODO:消耗阳光值，并进行种植
        bool isSuccess = HandManager.Instance.AddPlant(plantType);
        if (isSuccess) {
            SunManager.Instance.SubSun(needSunPoint);

            TransitionToCooling();
        }
    }
}
