
using UnityEngine;
using UnityEngine.UI;

public class ApprovePhone : MonoBehaviour
{

    private GameObject costChanger;
    public HumanQueue controllerHuman;

    private int questCost;
    private int questTime;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        costChanger = GameObject.Find("CostChanger");
    }

    public void Task()
    {
        controllerHuman.HumanQuest(questCost, questTime);
        costChanger.GetComponent<Animator>().SetBool("Close", true);
        costChanger.GetComponent<AudioSource>().Play();
        Invoke("SetActiveFalse", 1f);
    }

    private void SetActiveFalse()
    {
        costChanger.SetActive(false);
    }


    public void AgreePhone(int cost, int time)
    {
        questCost = cost;
        questTime = time;
    }
}
