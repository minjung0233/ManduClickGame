using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// 스케일업 + 페이드 아웃
// 랜덤한 위치에서 생성되는 것은 따로 Control을 만들던 해야할듯
public class ClickManduTxt : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    [SerializeField]
    [Range(0.0f,10.0f)]
    private float fadeTime;     // 클수록 변화 속도 빠름
    [SerializeField]
    private AnimationCurve fadeCurve;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        
        // fade out - 점차 없어짐(알파값 0으로)
        StartCoroutine(Fade(1, 0));

        Invoke("TMP_Dst", fadeTime);
    }
    void TMP_Dst()
    {
        Destroy(tmp);
    }

    // start ~ end 까지 fadeTime 동안
    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = tmp.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            tmp.color = color;
            tmp.transform.Translate(0, fadeTime, 0);

            yield return null;
        }
    }

    public void SetText(string text)
    {
        if(tmp != null)
        {
            tmp.text = text;
        }
    }
}
