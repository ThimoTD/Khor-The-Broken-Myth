using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : IPart
{
    public EPartState state { get; set; }
    public Vector2 localPosition { get; set; }
    public EPart bodyPart { get;}

    public IPartMovement partMovement { get; }

    private GameObject part;

    public Part()
    {
    }
}
