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
        Debug.Log("aaaa");
        screen = newScreen;
        Debug.Log(screen);
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
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene(screen);
    }
    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        Debug.Log(screen);
        StartCoroutine(TransitionAndLoadScene());

    }
}
