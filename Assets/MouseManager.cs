using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    List<Transform> mouses;
    public int Points { get; private set; } = 0;

    public event EventHandler<int> onHit;

    void Start()
    {
        mouses = transform.Cast<Transform>().ToList();
    }

    public void Hit(int childNum)
    {
        var validMouse = mouses.Where(m => m.name == childNum.ToString());

        if(validMouse.Count() != 0)
        {
            var mouse = validMouse.First();
            var mouseCon = mouse.GetComponent<MouseController>();

            Points += mouseCon.Point;
            onHit.Invoke(this, Points);
            mouseCon.Stop();
        }
    }
}
