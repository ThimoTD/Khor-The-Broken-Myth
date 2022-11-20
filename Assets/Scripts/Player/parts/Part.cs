using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : IPart
{
    public EPartState state { get; set; }
    public Vector3 position { get; set; }
    public EPart bodyPart { get; set; }

    public IEnumerable<EPart> parts => Parts;
    private readonly List<EPart> Parts;

    public Part()
    {
    }
}
