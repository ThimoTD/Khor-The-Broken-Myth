using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPart
{
    public EPartState State { get; set; }

    public EPart Part { get; }

    IEnumerable<EPart> Parts { get; }

    public IList<EPart> AttachedParts();

    public Vector3 Position();

}
