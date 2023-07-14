using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverQue : MonoBehaviour
{
    public List<GameObject> deliverBoy = new List<GameObject>();
    public GameObject prefab;
    public float xOfset;
    private List<GameObject> del = new List<GameObject>();
    public void OpenDeliverGuys()
    {
        foreach (GameObject guy in deliverBoy)
        {
            if(guy == null)
            {
                deliverBoy.Remove(guy);
            }
        }


        for(int i = 0; i < deliverBoy.Count; i++)
        {
           GameObject openGuy = Instantiate(prefab, transform.position, Quaternion.identity, transform);
            openGuy.transform.localPosition += new Vector3(0, -(i * xOfset), 0);
            openGuy.GetComponent<DeliverBoyTime>().current = deliverBoy[i].GetComponent<HumanCharacter>();
            del.Add(openGuy);
        }
        
    }

    public void CloseDeliverGuy()
    {
        foreach(GameObject delete in del)
        {
            Destroy(delete);
        }
        del = new List<GameObject>();
    }

    
}
