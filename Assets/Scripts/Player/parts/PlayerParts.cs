using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[System.Serializable]
public class PlayerParts
{
    public bool active;
    public List<IPart> parts = new List<IPart>();

    public bool HasHead()
    {
        foreach(IPart part in parts)
            if(part.bodyPart == EPart.Head) return true;
        
        return false;
    }

    
}

/*
 -full body
  - Shead cords = (-1.585 , 3, 0)
  - Sjaw cords = (-2.72, -0.18, 0)
  - Sbody cords = (0.08, -1.78, 0)
  - Slegs cords = (1.47, -8.39, 0)
  - Ssappling cords = (2.35, 6.68, 0)
  - SLefr_Arm cords = (-6.02, -4.94, 0)
  - Sright_arm cords = (4.64, -4.33, 0)

  
rules every part combination must have a head
if it does not contain a head moving/ looking at it is not possible
remote controlling a part is possble if in range of head


*/