using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string NextScene;
    public List<PlantType> ChooseCard;
    public List<PlantType> ChooseCard1;
    public static ChooseManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            //Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addChooseCard(PlantType tmp){
        this.ChooseCard.Add(tmp);
    
    }
    public void addChooseCard1(PlantType tmp)
    {
        this.ChooseCard1.Add(tmp);

    }
    public void removeChooseCard(PlantType tmp)
    {
        this.ChooseCard.Remove(tmp);
    }
    public void removeChooseCard1(PlantType tmp)
    {
        this.ChooseCard1.Remove(tmp);
    }
    public void setNextScene(string tmp)
    {
        this.NextScene = tmp;
    }

    public string getNextScene()
    {
        return NextScene;
    }

}
