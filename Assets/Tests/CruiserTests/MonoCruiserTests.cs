/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NewTestScript.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MGS.Cruiser.Tests
{
    public class MonoCruiserTests
    {
        class TestMonoCruiser : MonoCruiser
        {
            public int TickCount { private set; get; }

            protected override void CruiserTick()
            {
                TickCount++;
                Debug.Log("CruiserTick in main thread.");
            }
        }

        [UnityTest]
        public IEnumerator TestMonoCruiserTick()
        {
            var cruiser = new TestMonoCruiser();
            cruiser.Activate();

            yield return new WaitForSeconds(3.0f);
            cruiser.Deactivate();

            Assert.Greater(cruiser.TickCount, 0);
        }
    }
}