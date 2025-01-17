﻿using UnityEngine;

public enum Angle
{
    Up,
    Forward
}

public class MouseClickCut : MonoBehaviour
{
    public Angle angle;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {

                GameObject victim = hit.collider.gameObject;
                if (victim.tag != "Safe")
                {

                    if (angle == Angle.Up)
                    {
                        Cutter.Cut(victim, hit.point, Vector3.up);

                    }
                    else if (angle == Angle.Forward)
                    {
                        Cutter.Cut(victim, hit.point, Vector3.forward);

                    }
                }
            }

        }
    }
}
