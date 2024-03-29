﻿//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
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


        /// <summary>
        /// Add definition of an ADC channel.
        /// </summary>
        /// <param name="adc">Index of ADC block.</param>
        /// <param name="adcChannel">Channel number for the ADC block.</param>
        /// <param name="pin">The pin number to connect to ADC channel.</param>
        /// <returns>The index of the ADC channel that has been created.</returns>
        /// <exception cref="ArgumentException">
        /// <para>
        /// If the ADC block doesn't exist.
        /// </para>
        /// <para>
        /// - or -
        /// </para>
        /// <para>
        /// If the ADC channel doesn't exist.
        /// </para>
        /// </exception>
        /// <exception cref="NotSupportedException">If the target doesn't have support for ADC.</exception>
        /// <remarks>
        /// No validation is performed on the usage of the GPIO pin. This will override any other pre-existing configuration for it.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern uint AddAdcChannel(
            uint adc,
            uint adcChannel,
            uint pin);

        /// <summary>
        /// Removes an existing ADC channel definition created with <see cref="AddAdcChannel"/>.
        /// </summary>
        /// <param name="channel">Channel number for an ADC definition.</param>
        /// <exception cref="ArgumentException">If the ADC <paramref name="channel"/> doesn't exist.</exception>
        /// <exception cref="NotSupportedException">If the target doesn't have support for ADC.</exception>
        /// <remarks>Upon return the respective GPIO pin is configured to the default configuration: input, without any other activation.</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void RemoveAdcChannel(uint channel);

#pragma warning restore S4200 // Native methods should be wrapped

    }
}
