//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Provides methods to control power mode of the target CPU.
    /// </summary>
    /// <remarks>
    /// This API is available only for SMT32 targets.
    /// </remarks>
    public static partial class Power
    {

        #region native methods calls

        /// <summary>
        /// Disables the specified <paramref name="pin"/> as wake-up source.
        /// </summary>
        /// <remarks>
        /// The wake-up pin availability is target dependent. Check the target device data-sheet for details.
        /// If the specified pin is not available an <see cref="ArgumentException"/> is  thrown.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void DisableWakeupPin(WakeupPin pin = WakeupPin.Pin1);

        /// <summary>
        /// Enables the specified <paramref name="pin"/> as wake-up source.
        /// </summary>
        /// <remarks>
        /// The wake-up pin availability is target dependent. Check the target device data-sheet for details.
        /// If the specified pin is not available an <see cref="ArgumentException"/> is  thrown.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnableWakeupPin(WakeupPin pin = WakeupPin.Pin1);

        /// <summary>
        /// Sets the target device to enter SMT32 "standby" mode.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnterStandbyMode();

        #endregion

    }
}
