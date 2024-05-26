using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    #region Public fields

    public WaterVolumeHelper WaterVolumeHelper = null;
    #endregion

    private Rigidbody rb;

    #region MonoBehaviour events

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var instance = WaterVolumeHelper ? WaterVolumeHelper : WaterVolumeHelper.Instance;
        if (!instance)
        {
            return;
        }

        var height = instance.GetHeight(transform.position);
        if (height.HasValue && height.Value > transform.position.y + 0.3f)
        {
            rb.AddForce(Physics.gravity, ForceMode.Acceleration);
        }
    }

    #endregion
}
