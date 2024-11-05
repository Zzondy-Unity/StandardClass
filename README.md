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
  <li>1. Equipment : 플레이어의 장착하는 행위를 나타냄.</li>
     <li>- ItemData를 받아와서 장착프리팹을 생성 혹은 파괴하는 장착행위</li>
  <li>2. EquipTool : Equip을 상속받아서 장착된 장비를 관리하는 클래스.</li>
     <li>- 장착도구를 하나의 클래스로 보아서 자원채취용, 전투용으로 인수를 나눈다.</li>
     <li>- 플레이어가 공격버튼을 누르면 장착된 EquipTool의 공격이 생기고 해당 클래스의 OnHit함수가 애니메이션중 이벤트로 나타난다.</li>
     <li>- 자원채취용은 해당 자원클래스를, 전투용은 IDamagable을 TryGetComponent한다.</li>
     <li>- 만약 다른 종류의 장비를 만들고자 할 시 Equip을 상속받아 다른 것들을 만들면 된다.</li>
<li>2. Resource 기능의 구조와 핵심 로직을 분석해보세요.</li>
  <li>- 자원을 관리하는 클래스.</li>
  <li>- 줘야할 아이템의 정보를 가지고있다.</li>
  <li>- Gather라는 함수를 통해 아이템을 타격위치에서 생성한다.</li>
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
