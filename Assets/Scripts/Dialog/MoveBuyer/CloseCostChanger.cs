using UnityEngine;
using UnityEngine.UI;

public class CloseCostChanger : MonoBehaviour
{

    public GameObject costChanger;

    private MouseControll mc;
    

    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Task);
        mc = GameObject.Find("Player").GetComponent<MouseControll>();
    }

    public void Task()
    {
        
        costChanger.GetComponent<Animator>().SetBool("Close", true);
        costChanger.GetComponent<AudioSource>().Play();
        mc.OpenMouse();
        Invoke("SetActiveFalse", 1f);
    }

    private void SetActiveFalse()
    {
        costChanger.SetActive(false);
    }


 
}
