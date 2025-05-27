using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData nowPlayerData; // 현재 데이터


    void Awake()
    {
        //if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        //else { Destroy(gameObject); }
    }

    // 저장하기
    public void SaveData()
    {
        // JsonUtility.ToJson(nowPlayerData); -- 차이를 모르겠음
        string jsonData = JsonConvert.SerializeObject(nowPlayerData); // PlayerData - > Json
        Debug.Log(jsonData);
        
        string path = Application.persistentDataPath + "/SavePlayerData.json"; // 경로 지정
        File.WriteAllText(path, jsonData); // json 파일 저장
        Debug.Log(path);
    }

    // 불러오기
    public void LoadData()
    {
        //nowPlayerData = new PlayerData();

        string path = Application.persistentDataPath + "/SavePlayerData.json"; // json 파일 찾기

        // 파일을 무사히 찾았다면 True
        if (File.Exists(path) == true)
        {
            string jsonData = File.ReadAllText(path); // 데이터 읽기
            nowPlayerData = JsonConvert.DeserializeObject<PlayerData>(jsonData); // 해당 스크립트에 데이터 덮어 쓰기
            
            Debug.Log(jsonData);

            PlayerData.instance.GetSaveData(); // PlayerData에 반영
        }
        else
        {
            Debug.Log("Json 데이터를 찾을수 없습니다.");
        }
    }
}
