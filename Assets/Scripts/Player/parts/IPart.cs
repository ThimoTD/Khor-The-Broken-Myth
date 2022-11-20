using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPart
{
    public EPartState state { get; set; }

    public EPart bodyPart { get;}

    public IEnumerable<EPart> parts { get; set; }

    public Vector3 position { get; set; }


}
