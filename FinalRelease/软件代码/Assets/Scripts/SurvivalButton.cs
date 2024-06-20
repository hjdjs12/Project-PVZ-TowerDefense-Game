using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalButton : MonoBehaviour
{
    private Vector3 initialScale;
    private Animator anim;

    public string screen;

    public static SurvivalButton Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void set_screen(string newScreen)
    {
    }

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
        SceneController.Instance.isPause = true;
        SceneController.Instance.ResumeGame();
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(TransitionAndLoadScene());

    }
}
