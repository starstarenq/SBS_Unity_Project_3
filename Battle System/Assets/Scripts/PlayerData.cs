using UnityEngine;
[System.Serializable]

public class PlayerData 
{
    
   public string Name;
    public int MONEY;
   public  int HP;
     public int ATK;

    public PlayerData(string name, int money, int hp, int atk)
    {
        Name = name;
        MONEY = money;
        HP = hp;
        ATK = atk;
    }
}
