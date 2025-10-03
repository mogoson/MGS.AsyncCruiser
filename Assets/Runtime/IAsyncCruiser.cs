/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IAsyncCruiser.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/16/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.AsyncCruiser
{
    public interface IAsyncCruiser : IDisposable
    {
        /// <summary>
        /// Cruiser is active?
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Interval of cruiser (ms).
        /// </summary>
        int Interval { set; get; }

        /// <summary>
        /// Activate cruiser.
        /// </summary>
        void Activate();

        /// <summary>
        /// Deactivate cruiser.
        /// </summary>
        void Deactivate();
    }
}