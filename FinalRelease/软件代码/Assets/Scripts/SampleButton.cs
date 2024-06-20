using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SampleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Scene currentScene;
    private EventSystem[] eventSystems;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TransitionAndLoadScene()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0);

        // ????????
        Debug.Log(SceneController.Instance.isPause);
        SceneController.Instance.PauseGame();
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        SceneController.Instance.isPause = false;
        StartCoroutine(TransitionAndLoadScene());

    }

}
