using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEditor;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    PlayerData saveData;

    //public Mandu newMandu;
    //List<Mandu> newMandu = new List<Mandu>();


    void Start()
    {
        saveData = PlayerData.instance;
        //if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        //else { Destroy(gameObject); }
    }

    // 저장하기
    public void SaveData()
    {
        Debug.Log(PlayerData.instance.Money);
        // 만두 리스트
        /*
        for (int i = 0; i<= saveData.manduList.Count-1; i++)
        {
            ManduSaveData data = new ManduSaveData
            {
                manduName = saveData.manduList[i].manduName,
                holdCount = saveData.manduList[i].holdCount,
                level = saveData.manduList[i].level
            };

            saveData.manduList.Add(data);
            Debug.Log(data);
        }
        */

        // JsonUtility.ToJson(nowPlayerData); -- 차이를 모르겠음
        string jsonData = JsonConvert.SerializeObject(PlayerData.instance.GetSaveData());

        //string jsonData = JsonConvert.SerializeObject(newPlayerData); // PlayerData - > Json
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
            SaveData loadedData = JsonConvert.DeserializeObject<SaveData>(jsonData); // 해당 스크립트에 데이터 덮어 쓰기
            
            Debug.Log(jsonData);

            PlayerData.instance.SetterSaveData(loadedData); // PlayerData에 반영

            // ManduData 반영
            for(int i = 0; i < PlayerData.instance.manduList.Count; i++)
            {
                PlayerData.instance.manduList[i].manduName = loadedData.manduList[i].manduName;
                PlayerData.instance.manduList[i].holdCount = loadedData.manduList[i].holdCount;
                PlayerData.instance.manduList[i].level = loadedData.manduList[i].level;
            }
            
        }
        else
        {
            Debug.Log("Json 데이터를 찾을수 없습니다.");
        }
    }
}
