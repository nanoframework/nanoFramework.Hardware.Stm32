//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Class with methods to perform configuration changes in STM32.
    /// </summary>
    public static class Configuration
    {
#pragma warning disable S4200 // Intended usage in .NET nanoFramework

        /// <summary>
        /// Set the configuration for a GPIO pin.
        /// </summary>
        /// <param name="pin">The pin number to configure.</param>
        /// <param name="configuration">The configuration to apply to the GPIO pin.</param>
        /// <remarks>
        /// There is no validation or check performed on the configuration applied to a GPIO pin. This will override the default configuration for a pin, even if it is already use for other function, for example as a GpioPin output.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ConfigurePin(
            int pin,
            GpioConfiguration configuration);

#pragma warning restore S4200 // Native methods should be wrapped

    }
}
