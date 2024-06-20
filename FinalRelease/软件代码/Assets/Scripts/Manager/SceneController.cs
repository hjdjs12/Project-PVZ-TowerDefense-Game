//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

//public class SceneController : MonoBehaviour
//{
//    private int gameSceneIndex;
//    public static SceneController Instance { get; private set; }
//    // 获取当前活动的场景
//    public Scene currentScene;
//    private EventSystem[] eventSystems;
//    public  float totalTime = 0;
//    public TextMeshProUGUI timeText;
//    public bool isPause = false;
//    AudioListener audioListener;
//    private void Awake()
//    {
//        Instance = this;
//    }
//    void Start()
//    {
//    }
//    private void Update()
//    {
//        if (timeText != null)
//        {
//            totalTime += Time.deltaTime;
//            int hour = (int)(totalTime / 3600);
//            int min = (int)(totalTime % 3600 / 60);
//            int sec = (int)(totalTime - hour * 3600 - min * 60);
//            timeText.SetText(hour.ToString() + ":" + min.ToString() + ":" + sec.ToString());
//        }
//    }

//    public void PauseGame()
//    {
//        if (isPause)
//        {
//            currentScene = SceneManager.GetActiveScene();

//            // 获取当前场景中的所有事件系统
//            eventSystems = FindObjectsOfType<EventSystem>();

//            // 禁用每个事件系统
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = false;
//            }
//            // 获取当前场景中的AudioListener组件
//            audioListener = FindObjectOfType<AudioListener>();

//            // 检查是否找到AudioListener
//            if (audioListener != null)
//            {
//                // 禁用AudioListener组件
//                audioListener.enabled = false;
//            }
//            // 设置场景的时间尺度
//            Time.timeScale = 0;
//            // 加载暂停场景
//            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
//        }
//        else
//        {
//            currentScene = SceneManager.GetActiveScene();

//            // 获取当前场景中的所有事件系统
//            eventSystems = FindObjectsOfType<EventSystem>();

//            // 禁用每个事件系统
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = false;
//            }
//            audioListener = FindObjectOfType<AudioListener>();

//            // 检查是否找到AudioListener
//            if (audioListener != null)
//            {
//                // 禁用AudioListener组件
//                audioListener.enabled = false;
//            }
//            // 设置场景的时间尺度
//            Time.timeScale = 0;
//            // 加载暂停场景
//            SceneManager.LoadScene("WeaponInfoScene", LoadSceneMode.Additive);
//        }

//    }

//    public void ResumeGame()
//    {
//        if (isPause)
//        {
//            Time.timeScale = 1;
//            // 卸载暂停场景
//            SceneManager.UnloadSceneAsync("PauseScene");
//            // 重新启用之前禁用的事件系统
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = true;
//            }
//            if (audioListener != null)
//            {
//                // 禁用AudioListener组件
//                audioListener.enabled = true;
//            }
//        }
//        else
//        {
//            Time.timeScale = 1;
//            // 卸载暂停场景
//            SceneManager.UnloadSceneAsync("WeaponInfoScene");
//            // 重新启用之前禁用的事件系统
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = true;
//            }
//            if (audioListener != null)
//            {
//                // 禁用AudioListener组件
//                audioListener.enabled = true;
//            }
//        }
//    }
//}
























//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;
//using TMPro;
//using System.Collections;

//public class SceneController : MonoBehaviour
//{
//    private int gameSceneIndex;
//    public static SceneController Instance { get; private set; }
//    public Scene currentScene;
//    public EventSystem[] eventSystems;
//    public float totalTime = 0;
//    public TextMeshProUGUI timeText;
//    public bool isPause = false;
//    private AudioListener audioListener;

//    private void Awake()
//    {
//        Instance = this;
//    }

//    void Start()
//    {
//        currentScene = SceneManager.GetActiveScene();
//        audioListener = FindObjectOfType<AudioListener>();
//    }

//    private void Update()
//    {
//        if (timeText != null)
//        {
//            totalTime += Time.deltaTime;
//            int hour = (int)(totalTime / 3600);
//            int min = (int)(totalTime % 3600 / 60);
//            int sec = (int)(totalTime - hour * 3600 - min * 60);
//            timeText.SetText($"{hour:D2}:{min:D2}:{sec:D2}");
//        }
//    }

//    public void PauseGame()
//    {
//        currentScene = SceneManager.GetActiveScene();

//        // 获取当前场景中的所有事件系统
//        eventSystems = FindObjectsOfType<EventSystem>();

//        // 禁用每个事件系统
//        foreach (EventSystem es in eventSystems)
//        {
//            es.enabled = false;
//        }

//        // 禁用当前场景中的AudioListener组件
//        if (audioListener != null)
//        {
//            audioListener.enabled = false;
//        }

//        // 设置场景的时间尺度
//        Time.timeScale = 0;

//        // 加载暂停场景
//        if (isPause)
//        {
//            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
//        }
//        else
//        {
//            SceneManager.LoadScene("WeaponInfoScene", LoadSceneMode.Additive);
//        }

//        // 检查和禁用多余的 AudioListener
//        StartCoroutine(CheckAndDisableAudioListeners());
//    }

//    public void ResumeGame()
//    {
//        // 设置场景的时间尺度
//        Time.timeScale = 1;

//        // 卸载暂停场景
//        if (isPause)
//        {
//            SceneManager.UnloadSceneAsync("PauseScene");
//        }
//        else
//        {
//            SceneManager.UnloadSceneAsync("WeaponInfoScene");
//        }

//        // 重新启用之前禁用的事件系统
//        foreach (EventSystem es in eventSystems)
//        {
//            es.enabled = true;
//        }

//        // 重新启用AudioListener组件
//        if (audioListener != null)
//        {
//            audioListener.enabled = true;
//        }

//        // 检查和禁用多余的 AudioListener
//        StartCoroutine(CheckAndDisableAudioListeners());
//    }

//    private IEnumerator CheckAndDisableAudioListeners()
//    {
//        // 等待一帧以确保新场景已经加载完毕
//        yield return null;

//        // 获取所有的 AudioListener
//        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

//        // 如果有多个 AudioListener，禁用多余的一个
//        if (audioListeners.Length > 1)
//        {
//            for (int i = 1; i < audioListeners.Length; i++)
//            {
//                audioListeners[i].enabled = false;
//            }
//        }
//    }
//}























using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    public Scene currentScene;
    public float totalTime = 0;
    public TextMeshProUGUI timeText;
    public bool isPause = false;
    private EventSystem[] eventSystems;
    private AudioListener audioListener;

    private void Awake()
    {
        // 确保单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        audioListener = FindObjectOfType<AudioListener>();
    }

    private void Update()
    {
        if (timeText != null)
        {
            totalTime += Time.deltaTime;
            int hour = (int)(totalTime / 3600);
            int min = (int)(totalTime % 3600 / 60);
            int sec = (int)(totalTime - hour * 3600 - min * 60);
            timeText.SetText($"{hour:D2}:{min:D2}:{sec:D2}");
        }
    }

    public void PauseGame()
    {
        currentScene = SceneManager.GetActiveScene();
        eventSystems = FindObjectsOfType<EventSystem>();

        foreach (EventSystem es in eventSystems)
        {
            es.enabled = false;
        }

        audioListener = FindObjectOfType<AudioListener>();

        if (audioListener != null)
        {
            audioListener.enabled = false;
        }

        Time.timeScale = 0;

        if (isPause)
        {
            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("WeaponInfoScene", LoadSceneMode.Additive);
        }

        StartCoroutine(CheckAndDisableAudioListeners());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        if (isPause)
        {
            SceneManager.UnloadSceneAsync("PauseScene");
        }
        else
        {
            SceneManager.UnloadSceneAsync("WeaponInfoScene");
        }

        // 重新获取当前场景中的事件系统并启用
        eventSystems = FindObjectsOfType<EventSystem>();
        foreach (EventSystem es in eventSystems)
        {
            es.enabled = true;
        }

        audioListener = FindObjectOfType<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = true;
        }

        StartCoroutine(CheckAndDisableAudioListeners());
    }

    private IEnumerator CheckAndDisableAudioListeners()
    {
        yield return null;

        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        if (audioListeners.Length > 1)
        {
            for (int i = 1; i < audioListeners.Length; i++)
            {
                audioListeners[i].enabled = false;
            }
        }
    }
}
