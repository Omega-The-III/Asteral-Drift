using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
//This script allows the user to create an asset that saves multiple Terrain values necessary for creating the background
//<Summary>

[CreateAssetMenu]
public class TerrainData : UpdatableData
{
    public float uniformScale = 2.5f;
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public float minHeight
    {
        get
        {
            return uniformScale * meshHeightMultiplier * meshHeightCurve.Evaluate(0);
        }
    }
    public float maxHeight
    {
        get
        {
            return uniformScale * meshHeightMultiplier * meshHeightCurve.Evaluate(1);
        }
    }
}
