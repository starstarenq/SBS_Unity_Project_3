using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int HealthPoint;
    [SerializeField] private int AttackPower;
    [SerializeField] Animator animator;
    bool IsDead;
    public bool CheckDead() => IsDead;
    public int GetHP() { return HealthPoint; }
    public void SetHP(int value) { HealthPoint = value; }
    public int GetAttackPower() { return AttackPower; }
    public void SetAttackPower(int value) { AttackPower = value; }
    private void Start()
    {
        IsDead = false;
    }
    public void Damage(int amount)
    {
        if(IsDead) { return; }
        // 공격자의 공격력으로부터 자신의 체력 감소시킨다.
        int attackerPower = amount;
        animator.SetTrigger("Hit");
        HealthPoint = HealthPoint - attackerPower;
        if(HealthPoint <= 0 )
        {
            Dead();
            Debug.Log("게임오버");
            
        }
    }
    protected virtual void Dead()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Entity>( out var entity)) // 충돌한 대상이 Entity 있으면 실행하라.
        {
            if (!entity.CheckDead()) 
            {
                Damage(entity.GetAttackPower());
            }   
        }
    }
}
