//
// Copyright (c) .NET Foundation and Contributors
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
        /// <summary>
        /// Sets the target device to enter STM32 "standby" mode.
        /// </summary>
        /// <remarks>
        /// If no wakeup sources configured then it will be a indefinite sleep.
        /// This call never returns.
        /// After the device enters standby a wakeup source will wake the device and the execution will start as if it was a reset.
        /// Keep in mind that the execution WILL NOT continue after the call to this method.
        /// </remarks>
        public static void EnterStandbyMode()
        {
            NativeEnterStandbyMode();

            // force an infinite sleep to allow execution engine to exit this thread and pick the reboot flags set on the call above
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        #region native methods calls

        /// <summary>
        /// Gets the reason for device wakeup.
        /// </summary>
        public static extern WakeupReasonType WakeupReason
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

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
        /// Sets the target device to enter STM32 "standby" mode.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeEnterStandbyMode();

        #endregion

    }
}
