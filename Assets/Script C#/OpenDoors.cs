using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class OpenDoors : MonoBehaviour
{
    public GameObject DoorOpen;
    public Animator doorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (DoorOpen != null)
        {
            doorAnimator = DoorOpen.GetComponent<Animator>();
            if (doorAnimator != null)
            {
                doorAnimator.enabled = true; // Отключаем Animator изначально
            }
            //DoorOpen.SetActive(false);
            print("trigg");
        }
    }
    private void OnTriggerExit(Collider other)
    {

        //DoorOpen.SetActive(true);
        print("exit");
    }
}
    
