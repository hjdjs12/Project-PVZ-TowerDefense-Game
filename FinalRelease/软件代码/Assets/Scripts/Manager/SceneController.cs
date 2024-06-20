//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

//public class SceneController : MonoBehaviour
//{
//    private int gameSceneIndex;
//    public static SceneController Instance { get; private set; }
//    // ��ȡ��ǰ��ĳ���
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

//            // ��ȡ��ǰ�����е������¼�ϵͳ
//            eventSystems = FindObjectsOfType<EventSystem>();

//            // ����ÿ���¼�ϵͳ
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = false;
//            }
//            // ��ȡ��ǰ�����е�AudioListener���
//            audioListener = FindObjectOfType<AudioListener>();

//            // ����Ƿ��ҵ�AudioListener
//            if (audioListener != null)
//            {
//                // ����AudioListener���
//                audioListener.enabled = false;
//            }
//            // ���ó�����ʱ��߶�
//            Time.timeScale = 0;
//            // ������ͣ����
//            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
//        }
//        else
//        {
//            currentScene = SceneManager.GetActiveScene();

//            // ��ȡ��ǰ�����е������¼�ϵͳ
//            eventSystems = FindObjectsOfType<EventSystem>();

//            // ����ÿ���¼�ϵͳ
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = false;
//            }
//            audioListener = FindObjectOfType<AudioListener>();

//            // ����Ƿ��ҵ�AudioListener
//            if (audioListener != null)
//            {
//                // ����AudioListener���
//                audioListener.enabled = false;
//            }
//            // ���ó�����ʱ��߶�
//            Time.timeScale = 0;
//            // ������ͣ����
//            SceneManager.LoadScene("WeaponInfoScene", LoadSceneMode.Additive);
//        }

//    }

//    public void ResumeGame()
//    {
//        if (isPause)
//        {
//            Time.timeScale = 1;
//            // ж����ͣ����
//            SceneManager.UnloadSceneAsync("PauseScene");
//            // ��������֮ǰ���õ��¼�ϵͳ
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = true;
//            }
//            if (audioListener != null)
//            {
//                // ����AudioListener���
//                audioListener.enabled = true;
//            }
//        }
//        else
//        {
//            Time.timeScale = 1;
//            // ж����ͣ����
//            SceneManager.UnloadSceneAsync("WeaponInfoScene");
//            // ��������֮ǰ���õ��¼�ϵͳ
//            foreach (EventSystem es in eventSystems)
//            {
//                es.enabled = true;
//            }
//            if (audioListener != null)
//            {
//                // ����AudioListener���
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

//        // ��ȡ��ǰ�����е������¼�ϵͳ
//        eventSystems = FindObjectsOfType<EventSystem>();

//        // ����ÿ���¼�ϵͳ
//        foreach (EventSystem es in eventSystems)
//        {
//            es.enabled = false;
//        }

//        // ���õ�ǰ�����е�AudioListener���
//        if (audioListener != null)
//        {
//            audioListener.enabled = false;
//        }

//        // ���ó�����ʱ��߶�
//        Time.timeScale = 0;

//        // ������ͣ����
//        if (isPause)
//        {
//            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
//        }
//        else
//        {
//            SceneManager.LoadScene("WeaponInfoScene", LoadSceneMode.Additive);
//        }

//        // ���ͽ��ö���� AudioListener
//        StartCoroutine(CheckAndDisableAudioListeners());
//    }

//    public void ResumeGame()
//    {
//        // ���ó�����ʱ��߶�
//        Time.timeScale = 1;

//        // ж����ͣ����
//        if (isPause)
//        {
//            SceneManager.UnloadSceneAsync("PauseScene");
//        }
//        else
//        {
//            SceneManager.UnloadSceneAsync("WeaponInfoScene");
//        }

//        // ��������֮ǰ���õ��¼�ϵͳ
//        foreach (EventSystem es in eventSystems)
//        {
//            es.enabled = true;
//        }

//        // ��������AudioListener���
//        if (audioListener != null)
//        {
//            audioListener.enabled = true;
//        }

//        // ���ͽ��ö���� AudioListener
//        StartCoroutine(CheckAndDisableAudioListeners());
//    }

//    private IEnumerator CheckAndDisableAudioListeners()
//    {
//        // �ȴ�һ֡��ȷ���³����Ѿ��������
//        yield return null;

//        // ��ȡ���е� AudioListener
//        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

//        // ����ж�� AudioListener�����ö����һ��
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
        // ȷ������ģʽ
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

        // ���»�ȡ��ǰ�����е��¼�ϵͳ������
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
