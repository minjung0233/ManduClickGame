using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Player : MonoBehaviour
{
    public TextMeshPro idTxt;
    public Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>(); -- 이유 모름
        if (anim == null)
        {
            Debug.LogError("Animator가 초기화되지 않았습니다!");
            return;
        }

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Click");
            anim.speed = 2.0f; // 애니메이션 재생 속도를 2배로
            anim.ResetTrigger("Basic");

        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("Basic");
            anim.speed = 2.0f; // 애니메이션 재생 속도를 2배로
            anim.ResetTrigger("Click");

        }
    }

    // 가져오기
    public void GetSaveData()
    {
        //playerID = DataManager.instance.saveData.id;
    }

}
