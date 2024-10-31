# StandardClass

#Interaction 기능의 구조와 핵심 로직을 분석해보세요.
1. 일정시간(CheckRate)마다 화면중앙에 Ray를 쏴서 IInteractable이 있는 물체의 정보를 hit에 담는다.
2. hit에 정보가 담겼다면 promptText에 해당 아이템의 정보를 띄어준다.

#Inventory기능의 구조와 핵심 로직을 분석해보세요.
1. 각 슬롯에 Slot클래스를넣고 Inventroy클래스에 해당 Slot 클래스들의 배열을 둔다.
2. 각 Slot 클래스는 번호를 가지고있고 슬롯과 상호작용하는건 Slot 배열의 인덱스로 어떤 Slot인지를 찾는다.
3. 슬롯을 클릭시 해당 아이템을 잠시 저장해두는 변수를 선언해두어 어떤 아이템이 선택되었는지 판단한다.

