using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        Destroy(ChooseManager.Instance.gameObject);
        //ChooseManager.Instance.NextScene = "";
        //ChooseManager.Instance.ChooseCard.Clear();
        //ChooseManager.Instance.ChooseCard1.Clear();
        Destroy(HandManager.Instance.gameObject);
        SceneManager.LoadSceneAsync("SelectScene", LoadSceneMode.Single);
        
        //SceneManager.UnloadSceneAsync("PauseScene");

    }
}
