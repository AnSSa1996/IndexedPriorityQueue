# IndexedPriorityQueue
이진 힙 구조를 활용해 IComparer&lt;T>로 정의된 우선순위에 따라 데이터를 정렬, 관리 및 검색하는 우선순위 큐입니다.

우선순위 결정
- IComparer<T> 인터페이스를 통해 각 요소의 우선순위를 정의하며, 기본적으로 Comparer<T>.Default를 사용합니다.

핵심 메서드
- Enqueue: 새로운 요소를 추가하고, 힙 속성을 유지하기 위해 HeapifyUp 메서드를 호출합니다.
- Dequeue: 우선순위가 가장 높은(또는 값이 가장 낮은) 루트 요소를 제거한 후 반환하며, 힙 정렬을 위해 HeapifyDown 메서드를 호출합니다.
- Peek: 큐의 루트 요소를 확인만 할 수 있습니다.

검색 기능
- Find: 주어진 조건에 맞는 첫 번째 요소를 검색합니다.
- FindAll: 주어진 조건에 맞는 모든 요소를 리스트 형태로 반환합니다.

추가 기능
- 인덱서를 통해 내부 요소에 직접 접근할 수 있으며, IEnumerable<T>와 비제네릭 IEnumerable를 구현하여 foreach 문 등에서 순회할 수 있도록 지원합니다.
