using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointsFloater : MonoBehaviour
{
    #region Public fields

    public WaterVolumeHelper WaterVolumeHelper = null;

    public float horPointOffset = 1;

    #endregion

    #region MonoBehaviour events

    void Update()
    {
        var instance = WaterVolumeHelper ? WaterVolumeHelper : WaterVolumeHelper.Instance;
        if (!instance)
        {
            return;
        }

        var height1 = instance.GetHeight(transform.position + Vector3.left * horPointOffset);
        var height2 = instance.GetHeight(transform.position + Vector3.right * horPointOffset);

        if (height1.HasValue && height2.HasValue)
        {
            transform.position = new Vector3(transform.position.x, (height1.Value + height2.Value) / 2f, transform.position.z);
            transform.rotation = Quaternion.LookRotation(new Vector3(horPointOffset * 2, height2.Value - height1.Value, 0), Vector3.up);
        }
    }

    #endregion
}
