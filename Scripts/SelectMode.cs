using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalMode : MonoBehaviour
{
    public GameObject eventObj;
    public Button SrvlBtn;
    public Button LvlBtn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        SrvlBtn.onClick.AddListener(LoadSurvivalModeScene);
        LvlBtn.onClick.AddListener(LoadLevelModeScene);
    }

    private void LoadSurvivalModeScene()
    {
        StartCoroutine(LoadScene(2));
    }

    private void LoadLevelModeScene()
    {
        StartCoroutine(LoadScene(3));
    }

    IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        //async.completed += OnLoadedScene;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
