using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Player player; //외부에서 연결
    [SerializeField] private Enemy enemy;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  player.SetHP(30);
        //player.SetAttackPower(10);
        //enemy.SetAttackPower(10);
       // enemy.SetHP(20);
       // player.Damage(enemy.GetAttackPower());
       // enemy.Damage(player.GetAttackPower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
