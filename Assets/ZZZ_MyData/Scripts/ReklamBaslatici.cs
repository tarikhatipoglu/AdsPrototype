using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections.Generic;


public class ReklamBaslatici : MonoBehaviour
{
    public void Start()
    {
        // Initialize the Mobile Ads SDK.

        MobileAds.Initialize((initStatus) =>
        {
            // SDK initialization is complete
        }
        );
    }
}
