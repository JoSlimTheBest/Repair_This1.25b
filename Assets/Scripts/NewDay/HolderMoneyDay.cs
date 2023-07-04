using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleLocalizator;

public class HolderMoneyDay : MonoBehaviour
{
    public AllStatsDayEnd stats;
    public GameObject prefabMedal;
    public PureMoneyEndDay pmed;


    public List<int> moneyStats = new List<int>();


    public int moneySafeAdd;
    public int partBuyAdd;
    
    public int rentAdd;
    public int bankAdd;


    public List<Sprite> statsSprite = new List<Sprite>();

    public Sprite moneySafe;
    
    public Sprite part;
    
    public Sprite rent;
    public Sprite bank;

    public List<string> engName = new List<string>();
    public string svE = "Money earned";
    public string ptE = "Purchase of spare parts";
    public string rE = "Rent";
    public string bE = "Bank";
    public List<string> rusName = new List<string>();
    public string svR = "Денег заработано";
    public string ptR = "Покупка запчастей";
    public string rR = "Аренда";
    public string bR = "Банк";

    private int currentCheckList = 0;

    private List<GameObject> medals = new List<GameObject>();

    private void Start()
    {
        moneyStats.Add(moneySafeAdd);  //0
        moneyStats.Add(partBuyAdd);  // 1
        moneyStats.Add(rentAdd);  //2
        moneyStats.Add(bankAdd); // 3

        engName.Add(svE);
        engName.Add(ptE);
        engName.Add(rE);
        engName.Add(bE);

        rusName.Add(svR);
        rusName.Add(ptR);
        rusName.Add(rR);
        rusName.Add(bR);

        statsSprite.Add(moneySafe);
        statsSprite.Add(part);
        statsSprite.Add(rent);
        statsSprite.Add(bank);

    }

    public void CheckLists()
    {
        for(int i =currentCheckList; i < moneyStats.Count; i++)
        {
            if(moneyStats[i] != 0)
            {
                InstNewMedal(i);
                currentCheckList += 1;
                return;
            }
            else
            {
                currentCheckList += 1;
            }

            
        }
        pmed.gameObject.SetActive(true);
        pmed.MoneyOnScreen();
        currentCheckList = 0;
    }


    public void ClearStats()
    {
        for(int i = 0; i < medals.Count; i++)
        {
            Destroy(medals[i]);
            
        }
        medals = new List<GameObject>();

        for(int i = 0;i< moneyStats.Count; i++)
        {
            moneyStats[i] = 0;
        }
    }

    public void StatsChange(int current, int count)
    {
        if(current <= -1) { return; }
        moneyStats[current] += count;
    }

    public void InstNewMedal(int number)
    {
        if(moneyStats[number] == 0) { return; }
        GameObject medal =  Instantiate(prefabMedal, stats.transform);
        medal.GetComponent<MedalCheck>().stats = stats;
        if(LanguageManager.currentLang == Language.English)
        {
            medal.GetComponent<MedalCheck>().naming = engName[number];
        }
        else
        {
            medal.GetComponent<MedalCheck>().naming = rusName[number];
        }
        medal.GetComponent<MedalCheck>().countMoney = moneyStats[number];
        medal.GetComponent<MedalCheck>().current = statsSprite[number];
        medal.GetComponent<MedalCheck>().hmd = gameObject.GetComponent<HolderMoneyDay>();
        
        
        if(medals.Count < 3)
        {
            medal.GetComponent<MedalCheck>().ofsetX = -800;
            medal.GetComponent<MedalCheck>().ofsetY = 450 - 350 * medals.Count;
        }
        else
        {
            medal.GetComponent<MedalCheck>().ofsetX = -450;
            medal.GetComponent<MedalCheck>().ofsetY = 450 - 350 * (medals.Count-3);
        }

        medals.Add(medal);
    }
}
