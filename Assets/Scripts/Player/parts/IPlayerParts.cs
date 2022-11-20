using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerParts
{
    public IEnumerable<IPart> parts { get; set; }
}
