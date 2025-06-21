using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public int Money;               //보유 돈
    public int ManduClickLevel;     // 만두 클릭 레벨
    public List<ManduSaveData> manduList;       // 보유 만두 (ScriptableObject 배열로)
    public static PlayerData instance;

    void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
        ManduClickLevel = 0;
    }

    // 만두 레벨이 높을수로 클릭 시 추가되는 만두 개수 증가
    public int ManduAdd(int level = 0)
    {
        int min = 0;
        int max = 0;
        int randNum = 0;

        switch (level)
        {
            // +1 ~ +3
            case 1:
                min = 1;
                max = 4;
                break;
            // +3 ~ +5
            case 2:
                min = 3;
                max = 6;
                break;
            // +5 ~ +7
            case 3:
                min = 5;
                max = 8;
                break;
            default:
                manduList[0].holdCount += 1;
                return 1;
        }
        randNum = UnityEngine.Random.Range(min, max);
        manduList[0].holdCount += randNum;

        return randNum;

    }
    
    // 가져온 데이터 저장
    public void SetterSaveData(SaveData saveData)
    {
        Money = saveData.Money;
        manduList = saveData.manduList;
        ManduClickLevel = saveData.ManduClickLevel;
    }
    
    // 현재 데이터 저장
    public SaveData GetSaveData()
    {
        return new SaveData
        {
            Money = Money,
            manduList = manduList,
            ManduClickLevel = ManduClickLevel,
        };
        
    }
}
