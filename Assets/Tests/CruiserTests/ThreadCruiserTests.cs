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
    public class ThreadCruiserTests
    {
        class TestThreadCruiser : ThreadCruiser
        {
            public int TickCount { private set; get; }

            protected override void CruiserTick()
            {
                TickCount++;
                Debug.Log("CruiserTick in background thread.");
            }
        }

        [UnityTest]
        public IEnumerator TestMonoCruiserTick()
        {
            var cruiser = new TestThreadCruiser();
            cruiser.Activate();

            yield return new WaitForSeconds(3.0f);
            cruiser.Deactivate();

            Assert.Greater(cruiser.TickCount, 0);
        }
    }
}