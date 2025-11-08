using UnityEngine;

public class Player : Entity
{
    // 정수 형식으로 HP ATK
    // 접근지정자인 private, public, protected 하나 선택해서 선언 ㄱㄱ
    // private: Enemy class 개인적인 것. 다른 클래스에서 사용하는거 안됨
    // public: 다른 클래스에서 모두 사용 가능
    // protected: 자식만 사용가능하게
    protected override void Dead()
    {
        

        Debug.Log("게임오버");
        base.Dead();
    }
}
