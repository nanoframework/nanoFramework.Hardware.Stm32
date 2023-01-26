//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Class with configuration for a GPIO pin.
    /// </summary>
    public class GpioConfiguration
    {
        private IOMode _mode;
        private PullUpDownActivation _pullUpDown;
        private Speed _speed;
        private byte _alternateFunction;

#pragma warning disable S2292 // need to access backing fields in native

        /// <summary>
        /// Mode for GPIO pin.
        /// </summary>
        public IOMode Mode { get => _mode; set => _mode = value; }

        /// <summary>
        /// State of GPIO pull-up or down.
        /// </summary>
        public PullUpDownActivation PinState { get => _pullUpDown; set => _pullUpDown = value; }
        
        /// <summary>
        /// GPIO speed selection.
        /// </summary>
        public Speed SpeedSelection { get => _speed; set => _speed = value; }

        /// <summary>
        /// Alternate function selection.
        /// </summary>
        /// <remarks>
        /// The code for the alternate function is listed on the corresponding table in the device data sheet.
        /// </remarks>
        public byte AlternateFunction { get => _alternateFunction; set => _alternateFunction = value; }

#pragma warning restore S2292 // Trivial properties should be auto-implemented

        /// <summary>
        /// GPIO Configuration Mode.
        /// </summary>
        public enum IOMode
        {
            /// <summary>
            /// GPIO configured as input.
            /// </summary>
            Input = 0b_0000_0000,

            /// <summary>
            /// GPIO configured as output.
            /// </summary>
            Output = 0b_0000_0001,

            /// <summary>
            /// GPIO configured for Alternate function.
            /// </summary>
            AlternateFunction = 0b_0000_0010,

            /// <summary>
            /// GPIO configured in Analog mode.
            /// </summary>
            Analog = 0b_0000_0011,

            /// <summary>
            /// GPIO configured as output in Push Pull mode.
            /// </summary>
            OutputPushPull = Output,

            /// <summary>
            /// GPIO configured as output in Open Drain mode.
            /// </summary>
            OutputOpenDrain = Output | 0b_0001_0000,
        }

        /// <summary>
        /// Pull-Up or Pull-Down Activation for GPIO.
        /// </summary>
        public enum PullUpDownActivation
        {
            /// <summary>
            /// Floating: no Pull-up or Pull-down activated.
            /// </summary>
            Floating,

            /// <summary>
            /// Pull-up activation.
            /// </summary>
            PullUp = 1,

            /// <summary>
            /// Pull-down activation.
            /// </summary>
            PullDown = 2,
        }

        /// <summary>
        /// GPIO Output Maximum frequency.
        /// </summary>
        public enum Speed
        {
            /// <summary>
            /// Low speed.
            /// </summary>
            Low = 0,

            /// <summary>
            /// Medium speed.
            /// </summary>
            Medium = 1,

            /// <summary>
            /// High speed.
            /// </summary>
            High = 2,

            /// <summary>
            /// Very high speed.
            /// </summary>
            VeryHigh = 3,
        }
    }
}
