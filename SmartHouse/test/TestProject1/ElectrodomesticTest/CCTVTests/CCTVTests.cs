using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.ElectrodomesticTest.CCTVTests
{
    public class CCTVTests
    {
        [Fact]
        public void SwitchDayNightMode_IfCCTVIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            var cctv = new BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV.CCTV("Test CCTV");
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cctv.SwitchDayNightMode());
        }
        

    }
}
