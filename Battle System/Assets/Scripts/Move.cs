using System.Collections;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 방향
    // 속도
    // Vector2 dir = new Vector2 ( 0.1f, 0.1f );
    // Vector3 dir3 = new Vector3(0.1f, 0.1f);  
    [SerializeField] int direction = -1;
    [SerializeField] float speed = 10f;
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // rigid는 Move클래스가 부착되어있는 오브젝트에서 가져와
    }
    private void Start()
    {
        rigid.linearVelocityX = direction * speed;
    }
    public void Stop()
    {
       
        rigid.linearVelocity = Vector3.zero;

    }
    public void KnockBack()
    {
        int knockDirection = direction * (-1);
        float knockbackPower = 2f;
        float knockbackPowerY = 2f;
        rigid.AddForceX(knockbackPower , ForceMode2D.Impulse);
        rigid.AddForceY(knockbackPowerY * knockDirection, ForceMode2D.Impulse);
        
        StartCoroutine(KnockBackLogic());
    }

    IEnumerator KnockBackLogic()
    {
        yield return new WaitForSeconds(0.5f);
        Stop();
        yield return new WaitForSeconds(0.5f);
        rigid.linearVelocityX = direction * speed;
        rigid.linearVelocityY = direction * speed;
    }
}
        


