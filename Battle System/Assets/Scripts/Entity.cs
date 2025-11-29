using UnityEngine;

public class Entity : MonoBehaviour
{
    
    [SerializeField] private int HealthPoint;
    [SerializeField] private int MaxHealthPoint;
    [SerializeField] private int Amor;
    [SerializeField] private int AttackPower;
    [SerializeField] Animator animator;
    bool IsDead;
    public bool IsEnemy;
    public bool CheckDead() => IsDead;
    public int GetMaxHP() => MaxHealthPoint;
    public int GetHP() { return HealthPoint; }
    public void SetHP(int value) { HealthPoint = value; }
    public void SetMaxHP(int value) => MaxHealthPoint = value;
    public int GetAttackPower() { return AttackPower; }
    public void SetAttackPower(int value) { AttackPower = value; }
    public int GetAmor() { return Amor; }
    public void SetAmor(int value) { Amor = value; }
    protected virtual void Start()
    {
        IsDead = false;
        HealthPoint = MaxHealthPoint;
    }
    public virtual void Damage(Entity attacker)
    {
        if(IsDead) { return; }
        // 공격자의 공격력으로부터 자신의 체력 감소시킨다.
        int attackerPower = attacker.GetAttackPower();
        animator.SetTrigger("Hit");
        HealthPoint = HealthPoint - attackerPower;
        int rawDamage = attacker.GetAttackPower();
        int finalDamage = rawDamage - Amor;
        if (finalDamage < 0)
        {
            finalDamage = 0;
        }
        if (attacker.TryGetComponent<Move>(out var enemymove))
        {
            enemymove.Stop();
            enemymove.KnockBack();
            
        }
            
        if(HealthPoint <= 0 )
        {
            Dead();
           
            
        }
        
    }
    protected virtual void Dead()
    {
        animator.SetTrigger("Death");
        IsDead = true;
        //Destroy(gameObject);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Entity>( out var entity)) // 충돌한 대상이 Entity 있으면 실행하라.
        {
            if (IsEnemy&&entity.IsEnemy)

            {
                return;
            }
            //enemy일때 다른 enemy랑 충돌안하게 해주세요.
            if (entity.CheckDead()==false) 
            {
                Damage(entity);
            }   
        }
    }
}
