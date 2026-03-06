using BlaisePascal.SmartHouse.Domain.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV;
using BlaisePascal.SmartHouse.Domain.Electrodomestic.CCTV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1.ElectrodomesticTest.CCTVTests
{
    //public class CCTVTests
    //{
    //    Name name = new Name("cctv");
    //    Guid id = Guid.NewGuid();
    //    PIN securityCode = new PIN("0000");


    //    [Fact]
    //    public void SwitchDayNightMode_IfCCTVIsOff_ThrowInvalidOperationException()
    //    {
    //        // Arrange
    //        var cctv = new CCTV(name, securityCode);
    //        // Act & Assert
    //        Assert.Throws<InvalidOperationException>(() => cctv.SwitchDayNightMode());
    //    }

    //    [Fact]
    //    public void StartRecording()
    //    {
    //        CCTV newCCTV = new CCTV(name, securityCode);
    //        newCCTV.SecureSwitchOn(new PIN("0000"));
    //        newCCTV.StartRecording();
    //        Assert.Equal(RecordingStatus.Recording, newCCTV.RecordingStatus);
    //    }

    //    [Fact]
    //    public void StartRecording_IfCCTVIsOff()
    //    {
    //        CCTV newCCTV = new CCTV(name, securityCode);
    //        Assert.Throws<InvalidOperationException>(() => newCCTV.StartRecording());
    //    }

    //    [Fact]
    //    public void StopRecording()
    //    {
    //        CCTV newCCTV = new CCTV(name, securityCode);
    //        newCCTV.SecureSwitchOn(new PIN("0000"));
    //        newCCTV.StartRecording();
    //        newCCTV.StopRecording("wiwi");
    //        Assert.Equal(RecordingStatus.NotRecording, newCCTV.RecordingStatus); 
    //    }

    //    [Fact]
    //    public void Renamerecording()
    //    {
    //        CCTV newCCTV = new CCTV(name, securityCode);
    //        newCCTV.SecureSwitchOn(new PIN("0000"));
    //        newCCTV.StartRecording();
    //        newCCTV.StopRecording("Paolo e Francesca...");
    //        newCCTV.RenameRecording("Paolo e Francesca...", "Piero e Francesca");
    //        Assert.Equal("Piero e Francesca", newCCTV.Recordings[0].Name);
    //    }



    //}

    

    public class CCTVTests
    {
        private readonly Name _defaultName = new Name("CCTV");
        private readonly PIN _defaultPin = new PIN("0000");

        [Fact]
        public void StartRecording_IfCCTVIsOn_SetsStatusToRecording()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);

            cctv.StartRecording();

            Assert.Equal(RecordingStatus.Recording, cctv.RecordingStatus);
        }

        [Fact]
        public void StartRecording_IfCCTVIsOff_ThrowsInvalidOperationException()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);

            Assert.Throws<InvalidOperationException>(() => cctv.StartRecording());
        }

        [Fact]
        public void StopRecording_WhenRecording_SavesInListAndReturnsTrue()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);
            cctv.StartRecording();

            bool result = cctv.StopRecording("Video");

            Assert.True(result);
            Assert.Equal(RecordingStatus.NotRecording, cctv.RecordingStatus);
            Assert.Equal("Video", cctv.Recordings[0].Name);
        }

        [Fact]
        public void StopRecording_WhenDuplicateNameExists_ReturnsFalse()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);

            cctv.StartRecording();
            cctv.StopRecording("Duplicate");
            cctv.StartRecording();
            bool result = cctv.StopRecording("Duplicate");

            Assert.False(result);
        }

        [Fact]
        public void StopRecording_IfCCTVIsOff_ThrowsInvalidOperationException()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);

            Assert.Throws<InvalidOperationException>(() => cctv.StopRecording("Impossible"));
        }

        [Fact]
        public void RenameRecording_WhenFound_ChangesNameAndReturnsTrue()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);
            cctv.StartRecording();
            cctv.StopRecording("oldName");

            bool result = cctv.RenameRecording("oldName", "newName");

            Assert.True(result);
            Assert.Equal("newName", cctv.Recordings[0].Name);
        }

        [Fact]
        public void RenameRecording_WhenNotFound_ReturnsFalse()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);
            cctv.StartRecording();
            cctv.StopRecording("existVideo");

            bool result = cctv.RenameRecording("Video", "NewName");

            Assert.False(result);
        }

        [Fact]
        public void RenameRecording_WhenNameIsNull_ThrowsArgumentNullException()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);

            Assert.Throws<ArgumentNullException>(() => cctv.RenameRecording(null, "Nuovo"));
        }

        [Fact]
        public void DeleteRecording_WhenExists_RemovesFromList()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);
            cctv.StartRecording();
            cctv.StopRecording("Delete");

            cctv.DeleteRecording("Delete");

            Assert.Empty(cctv.Recordings);
        }

        [Fact]
        public void DeleteRecording_WhenNotFound_ThrowsInvalidOperationException()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);

            Assert.Throws<InvalidOperationException>(() => cctv.DeleteRecording("Video"));
        }

        [Fact]
        public void SearchRecordingByName_WhenExists_ReturnsTrue()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);
            cctv.SecureSwitchOn(_defaultPin);
            cctv.StartRecording();
            cctv.StopRecording("Video");

            bool exists = cctv.SearchRecordingByName("Video");

            Assert.True(exists);
        }

        [Fact]
        public void SearchRecordingByName_WhenNotExists_ReturnsFalse()
        {
            CCTV cctv = new CCTV(_defaultName, _defaultPin);

            bool exists = cctv.SearchRecordingByName("Video");

            Assert.False(exists);
        }
    }
}
