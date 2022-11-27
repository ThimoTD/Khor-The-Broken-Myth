using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPart
{
    public EPartState state { get; set; }

    public EPart bodyPart { get; }

    public Vector2 localPosition { get; set; }

    public IPartMovement partMovement { get; }


}
