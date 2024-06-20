using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstEnterSurvival : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChooseManager.Instance.setNextScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("SampleScene");

    }
}
