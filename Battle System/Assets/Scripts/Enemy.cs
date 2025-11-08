using UnityEngine;

public class Enemy : Entity
{
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
    }
}
