using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Player : Entity
{
    public PlayerData playerData;
    private int Money;
    public int GetMoney() => Money;
    public int SetMoney(int value) => Money = value;
    const int HealPrice = 30;
    const int UpgradePrice = 50;
    const int UpgradeAttackPrice = 50;
    // Guard 기능에 필요한 변수
    // Guard 기능에 필요한 변수
    private bool isGuarding = false;
    private int originalAttackPower;
    private const float GuardDuration = 1.0f; // 가드 지속 시간 (1초)
    // 정수 형식으로 HP ATK
    // 접근지정자인 private, public, protected 하나 선택해서 선언 ㄱㄱ
    // private: Enemy class 개인적인 것. 다른 클래스에서 사용하는거 안됨
    // public: 다른 클래스에서 모두 사용 가능
    // protected: 자식만 사용가능하게
    protected override void Start()
    {
        base.Start();
        //저장되어있는 데이터 있?
        originalAttackPower = GetAttackPower();


    }
    public void SavePlayerData()
    {
        playerData.MONEY = GetMoney();
        playerData.HP = GetHP();
        playerData.ATK = GetAttackPower();
        SaveStstem.Save(playerData);
        //PlayerPrefs.SetInt("MONEY", Money);
     //   PlayerPrefs.SetInt("HP", GetHP());
       // PlayerPrefs.SetFloat("ATK", GetAttackPower());


    }
    public void LoadPLayerData()
    {

        if (PlayerPrefs.HasKey("PLAYER") == false) return;
        //if (PlayerPrefs.HasKey("MONEY") == false) return;
        //    if (PlayerPrefs.HasKey("HP") == false) return;
        //   if (PlayerPrefs.HasKey("ATK") == false) return;
        playerData = SaveStstem.Load();
        SetMoney(playerData.MONEY);

        SetAttackPower(playerData.ATK);

        SetHP(playerData.HP);


    }
    protected override void Dead()
    {
        

        Debug.Log("게임오버");
        base.Dead();

    }
    public override void Damage(Entity attacker)
    {
        if (isGuarding)
        {
            Debug.Log("Guard 중이라 피해를 받지 않았습니다!");
            return; // 피해 무시
        }

        // Guard 상태가 아닐 때만 기본 피해 로직 실행
        base.Damage(attacker);
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
    public void Guard()
    {
        // 이미 가드 중이라면 중복 실행 방지
        if (isGuarding) return;

        // 공격력 업그레이드가 있을 수 있으므로 Guard 실행 직전에 현재 공격력 저장
        originalAttackPower = GetAttackPower();

        // 코루틴 시작
        StartCoroutine(GuardCoroutine(GuardDuration));
    }

    /// <summary>
    /// 가드 상태를 설정하고 일정 시간 후 해제하는 코루틴
    /// </summary>
    private IEnumerator GuardCoroutine(float duration)
    {
        // ...
        SetAttackPower(0); // 0은 int
                           // ...
        yield return new WaitForSeconds(duration);

        // ...
        SetAttackPower(originalAttackPower); // originalAttackPower가 int여야 함
    }
    public void Run()
    {
        //Application.Quit();

        EditorApplication.isPlaying = false;

    }
}
