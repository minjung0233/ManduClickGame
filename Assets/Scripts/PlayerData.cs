using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    public int Money { get; set; }

    public Mandu[] manduList; // ScriptableObject 배열로

    public int ManduClickLevel;

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
        randNum = Random.Range(min, max);
        manduList[0].holdCount += randNum;

        return randNum;

    }
}
