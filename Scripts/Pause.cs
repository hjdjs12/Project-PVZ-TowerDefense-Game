using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject eventObj;
    public Button PauseBtn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        PauseBtn.onClick.AddListener(LoadPauseScene);
    }

    private void LoadPauseScene()
    {
        StartCoroutine(LoadScene(4));
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
