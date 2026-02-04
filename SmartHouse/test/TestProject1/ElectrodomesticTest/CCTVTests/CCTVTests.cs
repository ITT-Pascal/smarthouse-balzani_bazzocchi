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
        string name = "cctv";
        Guid id = Guid.NewGuid();
        int securityCode = 0000;


        [Fact]
        public void SwitchDayNightMode_IfCCTVIsOff_ThrowInvalidOperationException()
        {
            // Arrange
            var cctv = new CCTV(name, id, securityCode);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cctv.SwitchDayNightMode());
        }

        [Fact]
        public void StartRecording()
        {
            CCTV newCCTV = new CCTV(name, id, securityCode);
            newCCTV.SecureSwitchOn(0000);
            newCCTV.StartRecording();
            Assert.Equal(RecordingStatus.Recording, newCCTV.RecordingStatus);
        }

        [Fact]
        public void StartRecording_IfCCTVIsOff()
        {
            CCTV newCCTV = new CCTV(name, id, securityCode);
            Assert.Throws<InvalidOperationException>(() => newCCTV.StartRecording());
        }

        [Fact]
        public void StopRecording()
        {
            CCTV newCCTV = new CCTV(name, id, securityCode);
            newCCTV.SecureSwitchOn(0000);
            newCCTV.StartRecording();
            newCCTV.StopRecording("wiwi");
            Assert.Equal(RecordingStatus.NotRecording, newCCTV.RecordingStatus); 
        }

        [Fact]
        public void Renamerecording()
        {
            CCTV newCCTV = new CCTV(name, id, securityCode);
            newCCTV.SecureSwitchOn(0000);
            newCCTV.StartRecording();
            newCCTV.StopRecording("Paolo e Francesca...");
            newCCTV.RenameRecording("Paolo e Francesca...", "Piero e Francesca");
            Assert.Equal("Piero e Francesca", newCCTV.Recordings[0].Name);
        }



    }
}
