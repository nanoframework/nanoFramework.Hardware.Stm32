//
// Copyright (c) 2019 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Stm32
{
    public partial class Power
    {
        /// <summary>
        /// Wakeup reason enumeration.
        /// </summary>
        public enum WakeupReasonType
        {
            /// <summary>
            /// Undetermined wakeup reason.
            /// </summary>
            Undetermined = 0,

            /// <summary>
            /// Wakeup from standby mode.
            /// </summary>
            FromStandby,

            /// <summary>
            /// Wakeup from pin.
            /// </summary>
            FromPin
        }
    }
}
