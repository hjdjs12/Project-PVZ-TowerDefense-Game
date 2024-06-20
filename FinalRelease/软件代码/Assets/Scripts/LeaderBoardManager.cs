using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Networking;
using System.Net.Cache;
using System;


public class LeaderBoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public class GameData
    {
        public string username;
        public int record;
        public string dateString;

        public GameData(string username1, int record1, string dateString1)
        {
            this.username = username1;
            this.record = record1;
            this.dateString = dateString1;
        }
    }

    public class Response<T>
    {
        public List<T> list;
    }

    public Text leaderboardText;

    public void Start1()
    {
        leaderboardText.text = "";
        StartCoroutine(GetSurvivalLeaderboardData());
    }

    public void Start2()
    {
        leaderboardText.text = "";
        StartCoroutine(GetLevelLeaderboardData());
    }

    IEnumerator GetSurvivalLeaderboardData()
    {
        string uri = "http://localhost:8080/gamedata/getRankingS";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                leaderboardText.text = "Failed to load leaderboard.";
            }
            else
            {
                string json1 = "{ \"list\": " + request.downloadHandler.text + "}";
                Response<GameData> dataList = JsonUtility.FromJson<Response<GameData>>(json1);
                int rank = 1;
                foreach (GameData data in dataList.list)
                {
                    leaderboardText.text += $" {rank.ToString().PadLeft(2)}. {data.username}: {data.record}\n";
                    rank++;
                }
            }
        }
    }

    IEnumerator GetLevelLeaderboardData()
    {
        string uri = "http://localhost:8080/gamedata/getRankingL";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                leaderboardText.text = "Failed to load leaderboard.";
            }
            else
            {
                string json1 = "{ \"list\": " + request.downloadHandler.text + "}";
                Response<GameData> dataList = JsonUtility.FromJson<Response<GameData>>(json1);
                int rank = 1;
                foreach (GameData data in dataList.list)
                {
                    leaderboardText.text += $"{rank.ToString().PadLeft(2)}. {data.username}: {data.record}\n";
                    rank++;
                }
            }
        }
    }

    [System.Serializable]
    public class Wrapper
    {
        public GameData[] items;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
