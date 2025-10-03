/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCruiser.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using MGS.Agent;
using UnityEngine;

namespace MGS.AsyncCruiser
{
    public abstract class MonoCruiser : MonoAgent, IAsyncCruiser
    {
        /// <summary>
        /// Cruiser is active?
        /// </summary>
        public bool IsActive { get { return cruiser != null; } }

        /// <summary>
        /// Interval of cruiser (ms).
        /// </summary>
        public int Interval
        {
            set
            {
                if (interval != value)
                {
                    interval = value;
                    instruction = new WaitForSeconds(interval / 1000f);
                }
            }
            get { return interval; }
        }
        protected int interval;
        protected Coroutine cruiser;
        protected YieldInstruction instruction;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="interval">Interval of cruiser (ms).</param>
        public MonoCruiser(int interval = 250)
        {
            this.interval = interval;
            instruction = new WaitForSeconds(interval / 1000f);
        }

        /// <summary>
        /// Activate cruiser.
        /// </summary>
        public void Activate()
        {
            if (cruiser == null)
            {
                cruiser = Mono.StartCoroutine(StartCruiser());
            }
        }

        /// <summary>
        /// Deactivate cruiser.
        /// </summary>
        public void Deactivate()
        {
            if (cruiser != null)
            {
                Mono.StopCoroutine(cruiser);
                cruiser = null;
            }
        }

        /// <summary>
        /// Start cruiser to tick loop.
        /// </summary>
        protected IEnumerator StartCruiser()
        {
            while (true)
            {
                CruiserTick();
                yield return instruction;
            }
        }

        /// <summary>
        /// Cruiser tick every cycle in main thread.
        /// </summary>
        protected abstract void CruiserTick();
    }
}