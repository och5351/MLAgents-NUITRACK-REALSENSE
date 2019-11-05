using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class ExpressAcademy : Academy
{
    public override void AcademyReset()
    {
        Monitor.SetActive(true);
    }
}
