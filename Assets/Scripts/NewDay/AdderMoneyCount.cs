using System.Collections;

using UnityEngine;
using TMPro;

public class AdderMoneyCount : MonoBehaviour
{
    public int currentMoney;
    private int onScreenNumber;


    public TextMeshProUGUI discription;
    private TextMeshProUGUI countCurrentMoney;
    public AudioClip CoinCall;
    private AudioSource call;

    private void Awake()
    {
        countCurrentMoney = GetComponent<TextMeshProUGUI>();
        call = GetComponent<AudioSource>();
    }
    IEnumerator ChangeFloat(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        
        while (elapsed < duration)
        {
            onScreenNumber = (int)Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            countCurrentMoney.text = onScreenNumber.ToString();
           
            yield return null;
        }
        call.PlayOneShot(CoinCall);
        onScreenNumber = currentMoney;
        countCurrentMoney.text = onScreenNumber.ToString();
    }
    public void ChangeMoney(int countM)
    {
        onScreenNumber = currentMoney;
        currentMoney += countM;
        if(onScreenNumber != currentMoney)
        {
            StartCoroutine(ChangeFloat(onScreenNumber, currentMoney, 1));
        }
    }


    /* Money earned
Taxes
Purchase of spare parts
Delivery
Rent
    Денег заработано
Налоги
Покупка запчастей
Доставка
Аренда*/

   
}
