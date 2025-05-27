using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMandu", menuName = "Mandu Data")]
public class Mandu : ScriptableObject
{
    public string manduName;   // 만두 이름
    public int holdCount;      // 보유 개수
    public int level;          // 만두 레벨
}
