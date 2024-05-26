using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    #region Public fields

    public WaterVolumeHelper WaterVolumeHelper = null;
    public float verOffset;

    public bool floating;

    #endregion

    #region MonoBehaviour events

    void Update()
    {
        floating = false;
        var instance = WaterVolumeHelper ? WaterVolumeHelper : WaterVolumeHelper.Instance;
        if (!instance)
        {
            return;
        }

        var height = instance.GetHeight(transform.position);
        if (height.HasValue && height.Value + verOffset > transform.position.y - 0.1f)
            floating = true;

        if (height.HasValue && height.Value + verOffset > transform.position.y)
            transform.position = new Vector3(transform.position.x, height.Value + verOffset, transform.position.z);
    }

    #endregion
}
