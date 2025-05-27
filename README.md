# ManduClickGame

나중에 전체 구조도 작성 필요

<h3>프로젝트 개요</h3>
이 프로젝트는 Unity로 작성된 모바일 안드로이드 게임이며 2025.04.23을 기점으로 진행하였다.
ManduClickGame은 이름 그대로 만두를 클릭하면 추가되는 만두 레벨(ManduClickLevel)에 따라 추가되는 수가 다르다.
또한, 클릭을 하지않아도 자동으로 추가되는 만두가 있다.자동 추가 만두 레벨(ManduAutomaticLevel)

----
<h3>현재 지정된 ManduClickLevel 레벨별 추가되는 만두 수</h3>

* (기본)1렙 -> +1 ~ +3

* 2렙 -> +3 ~ +5

* 3렙 -> +5 ~ +7
----
<h1> 진행된 구현 기능</h1>

<h5>1. 추가한 만두 수를 보기 위해 텍스트 추가</h5>

> <h6>스케일업 + Fade out 사용</h6>

>> * 스케일업 : 오브젝트를 점차 위로 올리기
>> * Fade out : 오브젝트의 Alpha 값을 1에서 0으로 바꾸기 즉, 시간이 지남에 따라 오브젝트가 없어져보임(Animantion Curve 사용하여 디테일하게)
>> * (추가적으로) 플레이어 기준 랜덤한 위치에 생성됨

----
<h1>구현해야할 기능</h1>

<h5>1. 게임 시작 씬 추가</h5>
<h5>2. 플레이어의 데이터를 Json 형태로 저장(2025.05.28[완])</h5>
<h5>3. 사운드 추가</h5>

> * 클릭 사운드
> * 배경 사운드

<h5>4. 상점 기능</h5>

> * ManduClickLevel 레벨업
> * (하고싶긴한데..) ManduAutomaticLevel 레벨업

----

<h1>Debug List and solution</h1>

<h5>1. 정렬화, 역정렬화 문제(2025.05.28)</h5>

> * log
>> * ArgumentException: Cannot deserialize JSON to new instances of type 'PlayerData.'

> * 상황 설명
>> * PlayerData를 Json파일로 변화하여 저장하는 것까진 잘 실행되었으나 다시 PlayerData에 넣으려 하면 오류가 발생
>> * Unity JSON Utilty는 이중배열 변환을 지원 X, Newtonsoft.Jsonxs은 지원
solution : <https://ojui.tistory.com/90>

<h1>Debug List and solution</h1>

<h5>디버그X 걍 문제점 만두 스크립트오브젝트 인스턴스화 필요(2025.05.28)</h5>

> * log
>> * Mandu must be instantiated using the ScriptableObject.CreateInstance method instead of new Mandu.

> * 상황 설명
>> * manduList 부분의 키와 값이 이상함
>> * {"Money":0,"manduList":[{"instanceID":24922},{"instanceID":24958},{"instanceID":24946}],"ManduClickLevel":0}
