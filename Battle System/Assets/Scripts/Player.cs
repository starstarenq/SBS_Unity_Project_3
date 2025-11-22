using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : Entity
{
    private int Money;
    public int GetMoney() => Money;
    public int SetMoney(int value) => Money = value;
    const int HealPrice = 30;
    const int UpgradePrice = 50;
    const int UpgradeAttackPrice = 50;
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
    private bool CanBuy(int price)
    {
        if(Money < price)
        {
            return false;

        }
        else
        {
            return true;
        }
        
    }
    public void Skill(int amount)
    {
        if (CanBuy(UpgradeAttackPrice) == false) return;
        SetAttackPower(GetAttackPower() + amount);
        Money -= UpgradeAttackPrice;
    }
    public void HealHP(int amount)
    {
        if (CanBuy(HealPrice) == false) return;
        int healAmount = GetHP() + amount;
        
        if (healAmount >GetMaxHP())
        {
            healAmount = GetMaxHP();
        }
        SetHP(healAmount);
        Money -= HealPrice;
    }
    public void Guard(int amount)
    {
        SetAttackPower(0);

       
    }
    public void Run()
    {
        //Application.Quit();

        EditorApplication.isPlaying = false;

    }
}
