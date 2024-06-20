using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager1 : MonoBehaviour
{
    AsyncOperation async;
    public Slider progressSlider;
    public string Scene;
    // Start is called before the first frame update
    void Start()
    {
        LoadNewScene1();
    }

    // Update is called once per frame
    void Update()
    {
        if (async == null)
        {
            return;
        }
        else
        {
            progressSlider.value += 0.002f;
            if (progressSlider.value >= 1 && async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            //progressSlider.value = async.progress;
        }
    }

    //跳转场景
    private void LoadNewScene1()
    {
        //开始跳转
        async = SceneManager.LoadSceneAsync(ChooseManager.Instance.getNextScene());
        async.allowSceneActivation = false;
    }
}
