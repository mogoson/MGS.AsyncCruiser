/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ThreadCruiser.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Threading;

namespace MGS.AsyncCruiser
{
    public abstract class ThreadCruiser : IAsyncCruiser
    {
        /// <summary>
        /// Cruiser is active?
        /// </summary>
        public bool IsActive { get { return cruiser != null && cruiser.IsAlive; } }

        /// <summary>
        /// Interval of cruiser (ms).
        /// </summary>
        public int Interval { set; get; }

        /// <summary>
        /// Cruiser thread
        /// </summary>
        protected Thread cruiser;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="interval">Interval of cruiser (ms).</param>
        public ThreadCruiser(int interval = 250)
        {
            Interval = interval;
        }

        /// <summary>
        /// Activate cruiser.
        /// </summary>
        public virtual void Activate()
        {
            if (cruiser == null)
            {
                cruiser = new Thread(StartCruiser) { IsBackground = true };
                cruiser.Start();
            }
        }

        /// <summary>
        /// Deactivate cruiser.
        /// </summary>
        public virtual void Deactivate()
        {
            if (cruiser == null)
            {
                return;
            }

            if (cruiser.IsAlive)
            {
                cruiser.Abort();
            }
            cruiser = null;
        }

        /// <summary>
        /// Dispose cruiser.
        /// </summary>
        public virtual void Dispose()
        {
            Deactivate();
        }

        /// <summary>
        /// Start cruiser to tick loop.
        /// </summary>
        protected void StartCruiser()
        {
            while (true)
            {
                CruiserTick();
                Thread.Sleep(Interval);
            }
        }

        /// <summary>
        /// Cruiser tick every cycle in background thread.
        /// </summary>
        protected abstract void CruiserTick();
    }
}