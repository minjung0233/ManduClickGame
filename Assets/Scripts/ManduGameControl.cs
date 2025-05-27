using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 만두 확률
/// 
/// 1 : 50%
/// 2 : 30%
/// 3 : 20%
/// 
/// </summary>

public class ManduGameControl : MonoBehaviour
{
    private bool isPaused = false;
    public float speed = 10.0f;
    private float generationTime;
    Camera camera;
    [SerializeField] private Canvas canvas;
    public ClickManduTxt click_tmp;
    public Vector2 spawnValues;

    void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // 일정 시간마다 주기적으로 얻는 만두
        generationTime += Time.deltaTime * speed;
        if(generationTime >= 1)
        {
            PlayerData.instance.ManduAdd(PlayerData.instance.ManduClickLevel);
            
            generationTime = 0;
        }

        /*
        // 튀어오르는 이펙트(만두)
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition += new Vector2(0, 0.02F);
            GameObject manduInstance = Instantiate(now_level_mandu, mousePosition, Quaternion.identity);

            Destroy(manduInstance, 2.0f);  // 2초 후 삭제
        }
        */

        // 클릭 시 - 만두 추가 + text 랜덤 위치 생성
        if (Input.GetMouseButtonDown(0))
        {
            int randomAdd = PlayerData.instance.ManduAdd(PlayerData.instance.ManduClickLevel);
            
            GameObject newTextObject = Instantiate(click_tmp.gameObject, canvas.transform);      // 캔버스 내에서 생성
            ClickManduTxt newTextComponent = newTextObject.GetComponent<ClickManduTxt>();        // 생성된 오브젝트를 제어하기 위한 변수

            newTextComponent.SetText("+" + randomAdd.ToString());

            // 랜덤한 위치를 설정
            RectTransform rectTransform = newTextObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(
                Random.Range(-spawnValues.x, spawnValues.x),
                Random.Range(-spawnValues.y, spawnValues.y)
                );
            //Quaternion rotation = Quaternion.identity;
            //Instantiate(click_tmp, spawnPosition, rotation);
        }

    }

    // 일시정지
    void OnClickPauseBtn()
    {
        isPaused = true;
    }
}
