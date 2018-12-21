//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Provides methods to control power mode of the target CPU.
    /// </summary>
    /// <remarks>
    /// This API is available only for SMT32 targets.
    /// </remarks>
    public static class Power
    {
        #region native methods calls

        /// <summary>
        /// Sets the target device to enter SMT32 "standby" mode.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnterStandbyMode();

        #endregion

    }
}
