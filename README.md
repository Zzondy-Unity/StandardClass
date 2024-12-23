# StandardClass

#Interaction 기능의 구조와 핵심 로직을 분석해보세요.
1. 일정시간(CheckRate)마다 화면중앙에 Ray를 쏴서 IInteractable이 있는 물체의 정보를 hit에 담는다.
2. hit에 정보가 담겼다면 promptText에 해당 아이템의 정보를 띄어준다.

#Inventory기능의 구조와 핵심 로직을 분석해보세요.
1. 각 슬롯에 Slot클래스를넣고 Inventroy클래스에 해당 Slot 클래스들의 배열을 둔다.
2. 각 Slot 클래스는 번호를 가지고있고 슬롯과 상호작용하는건 Slot 배열의 인덱스로 어떤 Slot인지를 찾는다.
3. 슬롯을 클릭시 해당 아이템을 잠시 저장해두는 변수를 선언해두어 어떤 아이템이 선택되었는지 판단한다.

# Week4
<details>
  <summary>## Q1 요구사항</summary>
    <div markdown="1">
      <ul>
<li>1. Equipment와 EquipTool의 기능의 구조와 핵심 로직을 분석해보세요.</li>
        <ul>
  <li>1. Equipment : 플레이어의 장착하는 행위를 나타냄.</li>
     <li>- ItemData를 받아와서 장착프리팹을 생성 혹은 파괴하는 장착행위</li>
  <li>2. EquipTool : Equip을 상속받아서 장착된 장비를 관리하는 클래스.</li>
     <li>- 장착도구를 하나의 클래스로 보아서 자원채취용, 전투용으로 인수를 나눈다.</li>
     <li>- 플레이어가 공격버튼을 누르면 장착된 EquipTool의 공격이 생기고 해당 클래스의 OnHit함수가 애니메이션중 이벤트로 나타난다.</li>
     <li>- 자원채취용은 해당 자원클래스를, 전투용은 IDamagable을 TryGetComponent한다.</li>
     <li>- 만약 다른 종류의 장비를 만들고자 할 시 Equip을 상속받아 다른 것들을 만들면 된다.</li>
        </ul>
<li>2. Resource 기능의 구조와 핵심 로직을 분석해보세요.</li>
        <ul>
  <li>- 자원을 관리하는 클래스.</li>
  <li>- 줘야할 아이템의 정보를 가지고있다.</li>
  <li>- Gather라는 함수를 통해 아이템을 타격위치에서 생성한다.</li>
        </ul>
        </ul>
    </div>
</details>

<details>
  <summary>## Q2 요구사항</summary>
    <div markdown="1">
      <ul>
<li>1. AI 네비게이션 시스템에서 가장 핵심이 되는 개념에 대해 복습해보세요.</li>
  <li>1. NaviMeshAgent : NaviMesh시스템을 이용해 움직이는 오브젝트.</li>
     <li>- Bake된 Area를 가중치 혹은 장애물을 계산하여 이동한다.</li>
     <li>-  agent타입을 추가하는것으로 뚱뚱한놈, 휴머노이드 등등 타입별 베이크 가능.</li>
  <li>2. Components</li>
     <li>- NavMeshSurface의 Volume에서 해당 크기만큼의 지형을 동적으로 Bake할 수 있음.</li>
     <li>- Off Mesh Link : Start, End Transform을 지정해두면 포탈처럼 빠르게 그 지점을 이동 할 수 있음.</li>
     <li>- Obstacle : 장애물 설치</li>
     <li>- NavMeshModifier : ignore = 이부분은 베이크하지 말아라 / Override Area = 이부분은 해당 Area입니다</li>
<li>2.NPC 기능의 구조와 핵심 로직을 분석해보세요.</li>
  <li>1. State패턴을 활용</li>
        <li>- SetState함수를 이용하여 상태를 변경하는것으로 행동로직을 변경</li>
       ```C#
              public void SetState(AIState state)
    {
        aiState = state;
        switch (aiState)
        {
            case AIState.Idle:
                agent.speed = walkSpeed;
                agent.isStopped = true;
                break;
            case AIState.Wandering:
                agent.speed = walkSpeed;
                agent.isStopped = false;
                break;
            case AIState.Attacking:
                agent.speed = runSpeed;
                agent.isStopped = false;
                break;
        }
        animator.speed = agent.speed / walkSpeed;
    }
    ```
  <li>- 각 상태에 따라 어떤 함수가 Update문을 돌지 결정</li>
        </ul>
    </div>
</details>
<details>
  <summary>## Q3 요구사항</summary>
    <div markdown="1">
      <ul>
<li>1. 보간에 대해 학습하고 선형보간(Lerp)과 구면선형보간(Slerp)에 대해 학습해보세요.</li>
  <li>1. Vector3 Lerp(Vector3 a, Vector3 b, float t)</li>
     <li>- a + (b - a)*t</li>
     <li>-  반환값 : a와 b를 직선으로 이었을 때 t만큼 보간된 값을 반환합니다.</li>
  <li>2. 구면선형보간(Slerp)</li>
     <li>- Vector3 Vector3.Slerp(Vector3 a, Vector3 b, float t)</li>
     <li>- 선형보간이 수 a, b사이의 보간이라면 구면선형보간은 벡터의 보간값입니다.</li>
     <li>- 벡터와 벡터를 연결하는 원이 있을 때 그 원들의 보간값(t)만큼 반환합니다.</li>
<li>2.근사값(Mathf.Approximately)을 사용하는 이유에 대해 학습해보세요.</li>
  <li>1. bool Mathf.Approximately(float a, float b)</li>
     <li>- Compares two floating point values and returns true if they are similar</li>
     <li>- 두 float값을 비교해서 비슷하면 true를 반환합니다.</li>
     <li>- float값은 정확히 동일 할 수 없습니다. 이때문에 값은 값일 때라는 조건을 이로 대체합니다.</li>
  <li>- 각 상태에 따라 어떤 함수가 Update문을 돌지 결정</li>
        </ul>
    </div>
</details>

# Week5
<details>
  <summary>## Q1 요구사항</summary>
    <div markdown="1">
      <ul>
<li>1. 전략패턴을 활용하여 다양한 원거리 무기 공격 패턴을 만들어보세요.</li>
     <li>- 마법지팡이를 들고 수박, 접시, 화살을 상호작용하면 해당 투사체가 장전됩니다.</li>
     <li>- 화살 : 바라보고있는 방향으로 직선의 화살을 발사합니다.</li>
     <li>- 접시 : 플레이어주변으로 20개의 접시를 날립니다.</li>
     <li>- 수박 : 바라보는 방향으로, ThrowPower만큼의 힘으로 포물선을 그리며 날라갑니다.</li>
        </ul>
    </div>
</details>
<details>
  <summary>## Q2 요구사항</summary>
    <div markdown="1">
      <ul>
<li>1. 플레이어가 2개 이상의 스킬을 사용할 수 있고, 해당 스킬을 퀵슬롯에 등록할 수 있다고 할 때, 어떻게 구현해야할까요?</li>
        <ul>
     <li>- QuickSlot : </li>
     <li>- 해당 스킬을 가지는 변수.</li>
     <li>- 눌렀을 때 해당 스킬의 Use 메서드 발동. </li>
     <li>- 스킬 쿨타임 인디게이터 활성화.</li>
     <li>- 스킬을 교체하는 메서드. (스킬아이콘, 변수, 쿨타임)</li>
     <li>- QuickSlotController</li>
     <li>- 큇슬롯을 변수로 가지고 스킬을 교체할 때 이 Controller에 의해 번호(index)값을 받아 해당 슬롯의 ChangeSkill메서드를 발동시킨다.</li>
        </ul>
<li>2. 이런 상황에 써야할 디자인 패턴에 대해 검색해보고, 어떻게 적용할 수 있을지 작성해봅시다.</li>
        <ul>
     <li>- 전략 패턴 : Skill 추상 클래스, 혹은 ISkill 인터페이스를 상속받는 변수를 통해 Use스킬을 발동.</li>
     <li>- 커맨드 패턴도 활용하여 다양한 명령을 캡슐화하여 발동시킬 수 있다.</li>
        </ul>
        </ul>
    </div>
</details>
