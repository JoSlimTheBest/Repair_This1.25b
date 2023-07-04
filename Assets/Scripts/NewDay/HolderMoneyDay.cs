using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderMoneyDay : MonoBehaviour
{
    public List<int> moneyStats = new List<int>();


    public int moneyAdd;
    public int taxAdd;
    public int partBuyAdd;
    public int deliveryAdd;
    public int rentAdd;


    public List<Sprite> statsSprite = new List<Sprite>();

    public Sprite money;
    public Sprite tax;
    public Sprite part;
    public Sprite deliver;
    public Sprite rent;
        

    private void Start()
    {
        moneyStats.Add(moneyAdd);
        moneyStats.Add(taxAdd);
        moneyStats.Add(partBuyAdd);
        moneyStats.Add(deliveryAdd);
        moneyStats.Add(rentAdd);
        
    }


    public void StatsChange(int current, int count)
    {
        moneyStats[current] += count;
    }
}
