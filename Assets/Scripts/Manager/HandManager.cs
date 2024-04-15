using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }

    public List<Plant> plantPrefabList;//存储prefab某个组件的集合，可以根据组件实例化对应prefab

    private Plant currentPlant;
    private int currentPlantPoint = 0;
    private Card currentPlantCard;

    private void Awake()
    {
        Instance = this;        
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
            if (currentPlant.plantType == PlantType.Tower) {
                currentPlant.addCell(cell);
            }
            WeaponManager.Instance.addWeapon(currentPlant.gameObject);
            currentPlantCard.TransitionToCooling();
            if (currentPlant.plantType == PlantType.MG2 || currentPlant.plantType == PlantType.MG3 || currentPlant.plantType == PlantType.Cannon2 || currentPlant.plantType == PlantType.Cannon3) {
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
