using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }
    Vector2 cardStartPoint = new Vector2(-157, 1.2f);
    public List<Plant> plantPrefabList;//存储prefab某个组件的集合，可以根据组件实例化对应prefab
    public List<GameObject> allCards;
    private Plant currentPlant;
    private int currentPlantPoint = 0;
    private Card currentPlantCard;
    public GameObject normalBoard;
    public GameObject Updateboard;
    public AudioSource[] audioSources;
    private void Start()
    {
        Instance = this;

  
    }
    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
        if (audioSources[1] != null)
        {
            audioSources[1].Stop();
        }
        if (audioSources[2] != null)
        {
            audioSources[2].Stop();
        }
        //Debug.Log(ChooseManager.Instance.getNextScene());
        for (int i = 0; i < ChooseManager.Instance.ChooseCard.Count;i++)
        {
            GameObject tmp = FindFitCard(ChooseManager.Instance.ChooseCard[i]);
            if (tmp  != null)
            {
                GameObject instance = Instantiate(tmp);
                instance.transform.SetParent(normalBoard.transform);

                // 设置实例的RectTransform属性
                RectTransform rectTransform = instance.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(cardStartPoint.x + 55*i, cardStartPoint.y, 0); // 设置相对位置
            }
            
        }

        for (int i = 0; i < ChooseManager.Instance.ChooseCard1.Count; i++)
        {
            GameObject tmp = FindFitCard(ChooseManager.Instance.ChooseCard1[i]);
            if (tmp != null)
            {
                GameObject instance = Instantiate(tmp);
                instance.transform.SetParent(Updateboard.transform);

                // 设置实例的RectTransform属性
                RectTransform rectTransform = instance.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(cardStartPoint.x + 55* i, cardStartPoint.y, 0); // 设置相对位置
            }

        }
        Debug.Log(ChooseManager.Instance.ChooseCard.Count);
        Instance = this;        
    }

    GameObject FindFitCard(PlantType p)
    {
        for(int i = 0;i < allCards.Count;i++)
        {
            if (allCards[i].GetComponent<Card>().plantType == p)
            {
                return allCards[i];
            }
        }
        return null;
    }

    public bool AddPlant(PlantType plantType,int needSunPoint,Card needCard)
    {
        if(currentPlant != null && currentPlant.plantType == plantType)
        {
            Destroy(currentPlant.gameObject);
            currentPlantPoint = 0;
            return false;
        }
        if (currentPlant != null) { return false; }
        Plant plantPrefab = GetPlantPrefabm(plantType);
        if (plantPrefab == null) {
            print("要种植的植物不存在");return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        currentPlantPoint = needSunPoint;
        currentPlantCard = needCard;
        return true;
    }
    private void Update()
    {
        FollowCursors();
    }

    void FollowCursors()
    {
        if (currentPlant == null) return;
        /*先得到鼠标的世界坐标
        ScreenToViewportPoint：屏幕坐标转世界坐标
        Input.mousePosition:鼠标的屏幕坐标*/
        Vector3 mouthWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mouthWorldPosition);
        mouthWorldPosition.z = (float)-0.01;
        currentPlant.transform.position = mouthWorldPosition;
    }

    private Plant GetPlantPrefabm(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if (plant.plantType == plantType) { return plant; }
        }
        return null;
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSuccess = cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            HandManager.Instance.audioSources[1].time = 0.4f;
            HandManager.Instance.audioSources[1].Play();
            if (currentPlant.plantType == PlantType.Tower || currentPlant.plantType == PlantType.Tower2) {
                currentPlant.addCell(cell);
            }
            if (currentPlant.plantType == PlantType.FireShooter) { currentPlant.GetComponent<Cannon1>().Shoot(); }
            WeaponManager.Instance.addWeapon(currentPlant.gameObject);
            currentPlantCard.TransitionToCooling();
            if (currentPlant.plantType == PlantType.Missle2 || currentPlant.plantType == PlantType.Missle3 || currentPlant.plantType == PlantType.MG2 || currentPlant.plantType == PlantType.MG3 || currentPlant.plantType == PlantType.Cannon2 || currentPlant.plantType == PlantType.Cannon3 || currentPlant.plantType == PlantType.CannonLinear2 || currentPlant.plantType == PlantType.CannonLinear3 || currentPlant.plantType == PlantType.CardFreeze2 || currentPlant.plantType == PlantType.CardFreeze3 || currentPlant.plantType == PlantType.CircleCannon2 || currentPlant.plantType == PlantType.CircleCannon3) {
                SerumManager.Instance.SubSerum(currentPlantPoint);
            }
            else {
                SunManager.Instance.SubSun(currentPlantPoint);
            }
            currentPlant = null;
            currentPlantPoint = 0;
        }

    }
}
