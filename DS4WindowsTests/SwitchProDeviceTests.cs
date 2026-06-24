using DS4Windows.InputDevices;

namespace DS4WindowsTests
{
    [TestClass]
    public class SwitchProDeviceTests
    {
        [TestMethod]
        public void RejectsEmptyStickAxisRange()
        {
            var axis = new SwitchProDevice.StickAxisData();

            Assert.IsFalse(SwitchProDevice.HasValidStickAxisRange(axis));
        }

        [TestMethod]
        public void AcceptsOrderedStickAxisRange()
        {
            var axis = new SwitchProDevice.StickAxisData()
            {
                min = 500,
                mid = 1900,
                max = 3300,
            };

            Assert.IsTrue(SwitchProDevice.HasValidStickAxisRange(axis));
        }
    }
}
