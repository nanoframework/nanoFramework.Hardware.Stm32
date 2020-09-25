//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Utilities for managing and handling STM32 target devices.
    /// </summary>
    public static class Utilities
    {
        private static byte[] _deviceUniqueId;
        private static uint _deviceId;
        private static uint _deviceRevisionId;

        /// <summary>
        /// Gets the 96 bits unique device ID.
        /// </summary>
        public static byte[] UniqueDeviceId
        {
            get
            {
                if (_deviceUniqueId == null)
                {
                    _deviceUniqueId = new byte[12];
                    NativeGetDeviceUniqueId(_deviceUniqueId);
                }

                return _deviceUniqueId;
            }
        }

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        public static uint DeviceId
        {
            get
            {
                if (_deviceId == 0)
                {
                    _deviceId = NativeGetDeviceId();
                }

                return _deviceId;
            }
        }

        /// <summary>
        /// Gets the device revision identifier.
        /// </summary>
        public static uint DeviceRevisionId
        {
            get
            {
                if (_deviceRevisionId == 0)
                {
                    _deviceRevisionId = NativeGetDeviceRevisionId();
                }

                return _deviceRevisionId;
            }
        }

        #region native methods calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeGetDeviceUniqueId(byte[] data);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern uint NativeGetDeviceId();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern uint NativeGetDeviceRevisionId();

        #endregion
    }
}
