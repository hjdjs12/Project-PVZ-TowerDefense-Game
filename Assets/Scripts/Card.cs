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
    PeaShooter,
    Tower,
    Cannon1,
    Cannon2,
    Cannon3,
    MG1,
    MG2,
    MG3
}
public class Card : MonoBehaviour
{

    //��ȴ�����Ա����  ������
    private CardState cardState = CardState.Cooling;
    public PlantType plantType = PlantType.Sunflower;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    //��ȴʱ��
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

        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }
    }
    void ReadyUpdate()
    {
        if (plantType == PlantType.MG2 || plantType == PlantType.MG3 || plantType == PlantType.Cannon2 || plantType == PlantType.Cannon3)
        {
            if (needSunPoint > SerumManager.Instance.SerumPoint)
            {
                TransitionToWaitingSun();
            }
        }
        else
        {
            if (needSunPoint > SunManager.Instance.SunPoint)
            {
                TransitionToWaitingSun();
            }
        }

    }
    void WaitingSunUpdate()
    {
        if (plantType == PlantType.MG2 || plantType == PlantType.MG3 || plantType == PlantType.Cannon2 || plantType == PlantType.Cannon3)
        {
            if (needSunPoint <= SerumManager.Instance.SerumPoint)
            {
                TransitionToReady();
            }
        }
        else
        {
            if (needSunPoint <= SunManager.Instance.SunPoint)
            {
                TransitionToReady();
            }
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
    public void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }
    public void OnClick()
    {
        if(plantType == PlantType.MG2 || plantType == PlantType.MG3 || plantType == PlantType.Cannon2 ||plantType == PlantType.Cannon3)
        {
            if (needSunPoint > SerumManager.Instance.SerumPoint) return;
        }
        else if ( needSunPoint > SunManager.Instance.SunPoint) return;


        //TODO:��������ֵ����������ֲ
        bool isSuccess = HandManager.Instance.AddPlant(plantType,needSunPoint,this);

    }
}
