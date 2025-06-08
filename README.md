주술대전 모작입니다.

## 🎮 게임 개요

- 플레이어는 **제자리에서 몬스터에게 맞는 역할**만 수행.
- 플레이어의 역할은 최소화되어 있으며, **자동으로 동작하는 스킬**들을 조합하고 강화해 **웨이브를 방어**하는 구조.

---

## ⚙️ 핵심 시스템

### 1. 스킬 시스템
- 총 **18개 스킬** (`3 속성 x 6 등급`)
- 스킬은 개별 프리팹으로 관리하지 않고 **공통 스킬 프리팹 + 동작 분기 처리** 방식.
- 스킬은 `SkillBase`를 통해 스택/쿨타임 관리.
- `ISkillBehaviour` 인터페이스와 동적 바인딩(`Activator.CreateInstance`)을 이용해 **스킬 로직 개별 실행**.

```
public class EarthCommon : ISkillBehaviour
{
    public void Execute(SkillBase skill)
    {
        PoolManager.Instance.Spawn<ProjectileBase>("ProjectileBase");
    }
}
```

### 2. 스킬 생성
버튼 클릭 → 뽑기 확률 계산 → 속성/등급 결정 → 해당 스킬 스택 +1

뽑기 확률은 소환 레벨(1~5)에 따라 결정됨

소환 레벨	Common	Rare	Hero	Legend	Ancient	Mythic<br>
Lv1	74.5%	20%	5%	0.5%	0%	0%<br>
Lv5	35.2%	45%	15%	4%	0.5%	0.3%<br>

### 3. 스킬 쿨타임 시스템
스택이 증가할수록 쿨타임 감소 (최대 3스택, 이후는 고정)

스택이 0이면 스킬 비활성화됨.

### 4. 풀 매니저
PoolManager에서 프리팹을 키 기반으로 호출하여 오브젝트 재사용 최적화

"ProjectileBase" 등 주요 오브젝트는 사전에 등록 필요

### 개선사항

현재 모든 스킬은 개별적으로 작동되나,
발사체 하나만 가지고 발사하는 형식임,
각각의 스킬별 효과를 부여하면 개별적용 가능
