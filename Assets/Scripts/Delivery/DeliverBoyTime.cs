using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleLocalizator;

public class DeliverBoyTime : MonoBehaviour
{

    public HumanCharacter current;
    private TextMeshProUGUI text;
    private TransNamePartPhone namingTrans;
    private ComputerTime ct;

    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        namingTrans = GameObject.Find("Player").GetComponent<TransNamePartPhone>();
        ct = GameObject.Find("QueueControll").GetComponent<ComputerTime>();
    }

    public void FixedUpdate()
    {
        
        string ftext = " ";
        if(LanguageManager.currentLang == Language.English)
        {
            ftext = "Model " + current._brokenModelPhone + " " + namingTrans.partNameEng[current._brokenPartPhone] + " || ";

            if (ct.currentDay != current.day)
            {
                ftext += " delivery will be tomorrow";
            }
            else
            {
                if(ct.hours - current.hour != 0)
                {
                    ftext += " delivery packing";
                }
                else
                {
                    if(current.minute - ct.minute > 30)
                    {
                        ftext += " delivery packing";
                    }
                    else
                    {
                        if(current.minute - ct.minute > 10)
                        {
                            ftext += " deliveryman on the way";
                        }
                        else
                        {
                            if (current.minute - ct.minute > 5)
                            {
                                ftext += " courier parking";
                            }
                            else
                            {
                                if (current.minute - ct.minute > 1)
                                {
                                    ftext += " courier climbs the stairs";
                                }
                                else
                                {
                                    ftext += " courier standing in line";
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            ftext = "Model " + current._brokenModelPhone + " " + namingTrans.partNameRus[current._brokenPartPhone] + " || ";

            if (ct.currentDay != current.day)
            {
                ftext += " доставщик прибудет завтра";
            }
            else
            {
                if (ct.hours - current.hour != 0)
                {
                    ftext += " доставка упаковывается";
                }
                else
                {
                    if (current.minute - ct.minute > 30)
                    {
                        ftext += " доставка упаковывается";
                    }
                    else
                    {
                        if (current.minute - ct.minute > 10)
                        {
                            ftext += " курьер в пути";
                        }
                        else
                        {
                            if (current.minute - ct.minute > 5)
                            {
                                ftext += " курьер паркуется";
                            }
                            else
                            {
                                if (current.minute - ct.minute > 1)
                                {
                                    ftext += " курьер поднимается по лестнице";
                                }
                                else
                                {
                                    ftext += " курьер стоит в очереди";
                                }
                            }
                        }
                    }
                }
            }
        }

        text.text = ftext;
       
    }
}
