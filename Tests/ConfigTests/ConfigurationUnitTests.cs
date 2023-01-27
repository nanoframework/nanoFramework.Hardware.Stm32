//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace nanoFramework.Hardware.Stm32.UnitTests
{
    [TestClass]
    public class ConfigurationTests
    {
        private static bool _runningOnHardware = false;

        [Setup]
        public void CheckRunningOnRealDevice()
        {
            try
            {
                // try configuring a GPIO (will fail if not running on a real device)
                Configuration.ConfigurePin(1, new GpioConfiguration());

                _runningOnHardware = true;
            }
            catch
            {
                // nothing to do here
            }
        }

        [TestMethod]
        public void AddRevemoAdcChannels()
        {
            // skip test if not running on a real device
            if (!_runningOnHardware)
            {
                Assert.SkipTest();
            }

            // add a new channel
            var newChannel1 = Configuration.AddAdcChannel(1, 1, 1);
            // and another one
            var newChannel2 = Configuration.AddAdcChannel(3, 2, 2);
            // and another one
            var newChannel3 = Configuration.AddAdcChannel(1, 3, 5);

            // assert for different channel indexes
            Assert.AreNotEqual(newChannel1, newChannel2, "12 Two newly created channels can't have the same index.");
            Assert.AreNotEqual(newChannel3, newChannel2, "32 Two newly created channels can't have the same index.");
            Assert.AreNotEqual(newChannel3, newChannel1, "31 Two newly created channels can't have the same index.");

            // remove 2nd channel
            Configuration.RemoveAdcChannel(newChannel2);

            // add a new channel
            var newChannel4 = Configuration.AddAdcChannel(1, 5, 10);

            // assert for different channel indexes
            Assert.AreNotEqual(newChannel1, newChannel4, "14 Two newly created channels can't have the same index.");
            Assert.AreNotEqual(newChannel3, newChannel4, "34 Two newly created channels can't have the same index.");

            // assert for same indexe as the one previously removed
            Assert.AreEqual(newChannel2, newChannel4, "A new channel should go into the same index of another one that has been freed up.");
        }
    }
}
