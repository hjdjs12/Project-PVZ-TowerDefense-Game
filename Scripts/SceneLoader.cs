using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventObj;
    public Button PlayBtn;
    public Button OpBtn;
    public Button QuitBtn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        PlayBtn.onClick.AddListener(LoadSelectModeScene);
        QuitBtn.onClick.AddListener(Quit);
    }

    private void LoadSelectModeScene()
    {
        StartCoroutine(LoadScene(1));
    }

    private void Quit()
    {
        Application.Quit();
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
