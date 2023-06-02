
using UnityEngine;

public class BoxDelivery : MonoBehaviour
{
    public int namePartDelivery;
    public string modelDelivery;
    public GameObject deliverMan;
    public float placeforgiftX =5;
    

    private void Start()
    {
        transform.position += new Vector3(placeforgiftX, 0, 0);
    }
    public void GivePart()
    {

        GameObject.Find("ManagerStock").GetComponent<ManagerStock>().AddPart(modelDelivery, namePartDelivery,1);
        GameObject.Find("QueueControll").GetComponent<HumanQueue>().HumanExit(deliverMan);
        GameObject.Find("BasketBrokenPhone").GetComponent<BasketPhones>().CheckRepair(modelDelivery, namePartDelivery);
        Destroy(gameObject, 0f);
    }
}
