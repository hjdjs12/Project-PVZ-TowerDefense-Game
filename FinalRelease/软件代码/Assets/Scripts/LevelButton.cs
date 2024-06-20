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

    //IEnumerator ShowLevel()
    //{
    //    //yield return new WaitForSeconds(0);
    //    //SceneManager.LoadScene("LevelScene");
    //}

    public void OnClick()
    {
        //Invoke("FunctionToInvoke", 3f);
        //StartCoroutine(ShowLevel());
        SceneManager.LoadScene("LevelScene");

    }
    public void showRank()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }
    public void ClickLevel1()
    {
        Time.timeScale = 1;
        ChooseManager.Instance.setNextScene("LevelScene1");
        SceneManager.LoadScene("SampleScene");
        //LoadGameScene("SampleScene");

    }

    public void ClickLevel2()
    {
        Time.timeScale = 1;
        Debug.Log("aaaa");
        ChooseManager.Instance.setNextScene("LevelScene2");
        SceneManager.LoadScene("SampleScene");

    }

    public void ClickLevel3()
    {
        Time.timeScale = 1;
        ChooseManager.Instance.setNextScene("LevelScene3");
        SceneManager.LoadScene("SampleScene");

    }

    public void ClickLevel4()
    {
        ChooseManager.Instance.setNextScene("LevelScene4");
        SceneManager.LoadScene("SampleScene");

    }

    public void ClickLevel5()
    {
        Time.timeScale = 1;
        ChooseManager.Instance.setNextScene("LevelScene5");
        SceneManager.LoadScene("SampleScene");

    }

    private void LoadGameScene(string sceneName)
    {
        //Time.timeScale = 1f;
        
    }
}
