using JetBrains.Annotations;
using UnityEngine;

public class SaveStstem : MonoBehaviour
{
    public PlayerData data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Debug.Log("저장 시스템 예제 구현!");
   
        

        Debug.Log("HP : " + PlayerPrefs.GetInt("HP"));
        Debug.Log("ATK : " + PlayerPrefs.GetFloat("ATK"));
        Debug.Log("NAME : " + PlayerPrefs.GetString("NAME"));
        Debug.Log("MONEY : " + PlayerPrefs.GetInt("MONEY"));

        Debug.Log(Application.persistentDataPath);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
    }
    public static void Save(PlayerData data)
    { 
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PLAYER", json);
    }
    // Update is called once per fram
    public static PlayerData Load()
    {
        string json = PlayerPrefs.GetString("PLAYER");
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
