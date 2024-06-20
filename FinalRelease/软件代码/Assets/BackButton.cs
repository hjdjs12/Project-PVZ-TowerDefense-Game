using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

    public Scene currentScene;
    private EventSystem[] eventSystems;
    // Start is called before the first frame update
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
        yield return new WaitForSeconds(0f);

        // ????????
        SceneController.Instance.isPause = false;
        SceneController.Instance.ResumeGame();
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
}
