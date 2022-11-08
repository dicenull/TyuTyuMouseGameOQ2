using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCollisitionDisp : MonoBehaviour
{
    [SerializeField] OVRInput.Controller controller;

    [SerializeField] MouseManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "OVRPlayerController")
        {
            return;
        }

        int parsed;
        bool valid = int.TryParse(other.transform.parent.name, out parsed);
        if (valid)
        {
            OVRInput.SetControllerVibration(0, 1, controller);

            manager.Hit(parsed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
