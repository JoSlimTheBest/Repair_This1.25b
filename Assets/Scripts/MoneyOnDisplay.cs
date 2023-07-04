using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyOnDisplay : MonoBehaviour
{
    public PlayerCharacter player;
    public bool textUI = true;
    public int currentMoney;
    private int onScreenNumber;

    public bool corStart = false;

    private void Start()
    {

        if(textUI == true)
        {
            GetComponent<TextMeshProUGUI>().text = player.money.ToString();

        }
        else
        {

            GetComponent<TextMeshPro>().text = player.money.ToString();
        }
    }


    IEnumerator ChangeFloat(int v_start, int v_end, float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            onScreenNumber = (int)Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            if (textUI == true)
            {
                GetComponent<TextMeshProUGUI>().text = onScreenNumber.ToString();

            }
            else
            {

                GetComponent<TextMeshPro>().text = onScreenNumber.ToString();
            }
            

            yield return null;
        }
        
        onScreenNumber = currentMoney;
        if (textUI == true)
        {
            GetComponent<TextMeshProUGUI>().text = onScreenNumber.ToString();

        }
        else
        {

            GetComponent<TextMeshPro>().text = onScreenNumber.ToString();
        }
        corStart = false;
    }
    public void FixedUpdate()
    {
        currentMoney = player.money;


        if (onScreenNumber != currentMoney && corStart ==false)
        {
            corStart = true;
            StartCoroutine(ChangeFloat(onScreenNumber, currentMoney, 0.4f));
        }
    }
}
