using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var Setup = colorSetups.Find(i => i.artType == artType);

        for(int i = 0; i < materials.Count; i++)
        {
            materials[1].SetColor("_Color", Setup.colors[1]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
