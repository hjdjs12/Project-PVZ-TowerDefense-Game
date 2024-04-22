using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    private Vector3 initialScale;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransitionAndLoadScene1()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene("Level1Scene");
    }
    IEnumerator TransitionAndLoadScene2()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene("Level2Scene");
    }
    IEnumerator TransitionAndLoadScene3()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene("Level3Scene");
    }
    IEnumerator TransitionAndLoadScene4()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene("Level4Scene");
    }
    IEnumerator TransitionAndLoadScene5()
    {
        // ????????????

        // ??????????????????????????????
        yield return new WaitForSeconds(0.6f);

        // ????????
        SceneManager.LoadScene("Level5Scene");
    }

    IEnumerator ShowLevel()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("LevelScene");
    }

    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        StartCoroutine(ShowLevel());

    }

    public void ClickLevel1()
    { 
        SurvivalButton.Instance.set_screen("Level1Scene");
        StartCoroutine(TransitionAndLoadScene1());
    }

    public void ClickLevel2()
    {
        StartCoroutine(TransitionAndLoadScene2());
        SurvivalButton.Instance.set_screen("Level2Scene");
    }

    public void ClickLevel3()
    {
        StartCoroutine(TransitionAndLoadScene3());
        SurvivalButton.Instance.set_screen("Level3Scene");
    }

    public void ClickLevel4()
    {
        StartCoroutine(TransitionAndLoadScene4());
        SurvivalButton.Instance.set_screen("Level4Scene");
    }

    public void ClickLevel5()
    {
        StartCoroutine(TransitionAndLoadScene5());
        SurvivalButton.Instance.set_screen("LeveL5Scene");
    }
}
