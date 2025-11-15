using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 몬스터 소환을 위한 제품이 필요 -> 어떤 오브젝트를 생성할 것인가?
    // 몇 마리 생성할 것인가? -> int
    // 몇 초 간격으로 소환? -> float
    // 어디에서 생성할거?
    // 랜덤.
    // 몬스터 마리 랜덤
    // 소환 위치 랜덤
    // 소환 간격 랜덤
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] int count = 7;
    [SerializeField] float interval = 1f;
    private void Start()
    {
        StartCoroutine(SpawnInterval());
    }
    private void Spawn()
    {
        int index = UnityEngine.Random.Range(0, prefabs.Length);
           
        Instantiate(prefabs[index], spawnPosition.position, Quaternion.identity);
    }
    IEnumerator SpawnInterval()
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }
       
    }
}
