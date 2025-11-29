using System.Collections;
using UnityEngine;


public class Enemy : Entity
{
    Move move;
    public int RewardMoney = 10;
   [SerializeField] Player player;
    private bool isGuarding = false;
    protected override void Start()
    {
        base.Start();
        player =Object.FindFirstObjectByType<Player>();
    }
    private void Awake()
    {
        move = GetComponent<Move>();
    }

    // 정수 형식으로 HP ATK
    // 접근지정자인 private, public, protected 하나 선택해서 선언 ㄱㄱ
    // private: Enemy class 개인적인 것. 다른 클래스에서 사용하는거 안됨
    // public: 다른 클래스에서 모두 사용 가능
    // protected: 자식만 사용가능하게
    // AttackPwer 외부에서 수정 가능하게 변경ㄱㄱ.
    // AttackPower 외부에서 사용가능하게 ㄱㄱ.
    protected override void Dead()
    {
        

        Debug.Log("적의 사망");
        base.Dead();
        player.SetMoney(player.GetMoney()+RewardMoney);

        StartCoroutine(DeathLogic());
    }

    IEnumerator DeathLogic()
    {
        move.Stop();
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
    public override void Damage(Entity attacker)
    {
        // 1. Guard 상태 체크: Guard 중이면 피해 무시
        if (isGuarding)
        {
            Debug.Log("Guard 중이라 피해를 받지 않았습니다!");
            return; // 여기서 메서드 종료 -> 피해를 받지 않음 (무적)
        }

        // 2. Guard 상태가 아닐 때만 부모 클래스의 Damage 로직 실행
        // base.Damage(attacker)는 Entity 클래스의 Damage 메서드를 호출하여
        // 방어력(Amor)을 계산하고 체력을 깎는 로직을 실행합니다.
        base.Damage(attacker);
    }
}
