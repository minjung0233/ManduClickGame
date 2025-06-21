using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

[Serializable]
public class SaveData
{
    [JsonProperty(Order = 1)] public int Money;               //보유 돈
    [JsonProperty(Order = 2)] public int ManduClickLevel;     // 만두 클릭 레벨
    [JsonProperty(Order = 3)] public List<ManduSaveData> manduList;       // 보유 만두 (ScriptableObject 배열로)
    
}
