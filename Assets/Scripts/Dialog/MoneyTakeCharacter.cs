using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTakeCharacter : MonoBehaviour
{
    public int countMoney;
    public AudioClip takeMoney;

    public void TakeIt()
    {

        GameObject.Find("Player").GetComponent<PlayerCharacter>().MoneyChoiceTaker(countMoney);
        
        
        GameObject.Find("AudioEvent").GetComponent<AudioSource>().PlayOneShot(takeMoney);
        Destroy(gameObject);
    }
}
