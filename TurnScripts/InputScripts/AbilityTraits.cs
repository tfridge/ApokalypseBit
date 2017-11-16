using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTraits : ScriptableObject {

	public enum LoSType { None, FirstBody, CoverPierce, FullPierce }
    public enum AreaOfEffect { None, Spot, Line, Cone, Circle, CircleSpot }
}
