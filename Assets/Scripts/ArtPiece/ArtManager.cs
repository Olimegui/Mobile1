using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : MonoBehaviour
{
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
    }
    public List<ArtSetup> artetups;
}

public class ArtSetup
{
    public ArtManager .ArtType artType;
    public GameObject gameObject;
}
