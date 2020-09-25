//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Provides access to RTC (real time clock) features.
    /// </summary>
    public static class RTC
    {
        /// <summary>
        /// Sets the <see cref="DateTime"/> for the alarm.
        /// This will wake-up the target device if it's in sleep or power down mode.
        /// </summary>
        /// <param name="time">Time to set.</param>
        /// <remarks>
        /// If target device has more than one alarm. This will set Alarm A.
        /// </remarks>
        public static void SetAlarm(DateTime time)
        {
            Native_RTC_SetAlarm((byte)time.Day, (byte)time.Hour, (byte)time.Minute, (byte)time.Second);
        }

        #region native methods calls

        /// <summary>
        /// Gets the <see cref="DateTime"/> set for the alarm.
        /// </summary>
        /// <returns>
        /// Return the current <see cref="DateTime"/> set for the alarm.
        /// </returns>
        /// <remarks>
        /// If target device has more than one alarm. This is the value of Alarm A.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern DateTime GetAlarm();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Native_RTC_SetAlarm(byte day, byte hours, byte minutes, byte seconds);

        #endregion

    }
}
