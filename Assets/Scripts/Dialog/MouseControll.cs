using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControll : MonoBehaviour
{
    private Camera cameraM;
    private bool activaisonMouse = true;
    
   

    public void Start()
    {
        cameraM = Camera.main;
    }

    public void OpenMouse()
    {
        activaisonMouse = true;
    }
    public void CloseMouse()
    {
        activaisonMouse = false;
    }
    private void MouseUse()
    {
        
        if (activaisonMouse == false)
        {
            return;
        }
        RaycastHit hit;
        Ray ray = cameraM.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Physics.Raycast(ray))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
            }

            if (hit.collider.GetComponent<FirstDialog>() != null)
            {
                if(hit.collider.GetComponent<FirstDialog>().enabled == true)
                {
                    hit.collider.GetComponent<FirstDialog>().DialogStart();

                    return;
                }
               
            }

          

            if (hit.collider.GetComponent<BrokenPhone>() != null)
            {
                hit.collider.GetComponent<BrokenPhone>().ReplacePhone();
                return;
            }

            if (hit.collider.GetComponent<DismantlePhone>() != null)
            {
                hit.collider.GetComponent<DismantlePhone>().UsePhone();
            }


            if (hit.collider.GetComponent<BoxDelivery>() != null)
            {
                hit.collider.GetComponent<BoxDelivery>().GivePart();
                return;
            }

            if (hit.collider.GetComponent<MoneyTakeCharacter>() != null)
            {
                hit.collider.GetComponent<MoneyTakeCharacter>().TakeIt();
                return;
            }

            if (hit.collider.GetComponent<EnvelopLandLord>() != null)
            {
                hit.collider.GetComponent<EnvelopLandLord>().OpenEnvelope();
                return;
            }

            if(hit.collider.GetComponent<Switcher>() != null)
            {
                hit.collider.GetComponent<Switcher>().ChangerA();
                return;
            }

           
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MouseUse();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = cameraM.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.GetComponent<OutlineShaderTake>() != null )
            {
               
                hit.collider.GetComponent<OutlineShaderTake>().OutlineActive();

            }
            // Do something with the object that was hit by the raycast.
        }
    }
}
