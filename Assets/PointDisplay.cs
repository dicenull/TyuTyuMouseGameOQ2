using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    [SerializeField] MouseManager manager;

    void Start()
    {
        manager.onHit += Manager_onHit;
    }

    private void Manager_onHit(object sender, int e)
    {
        GetComponent<Text>().text = $"{e}点";
    }
}
