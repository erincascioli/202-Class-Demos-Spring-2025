using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAgent : Agent
{
    public GameObject target;

    public override Vector3 CalcSteeringForce()
    {
        return Seek(target);
    }
}
