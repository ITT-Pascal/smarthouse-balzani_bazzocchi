using BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV;
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
            var cctv = new CCTV("cctv", Guid.NewGuid());
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cctv.SwitchDayNightMode());
        }
        

    }
}
