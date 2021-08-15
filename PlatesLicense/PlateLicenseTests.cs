using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlateLicense.TextImage;

namespace PlateLicense
{
    [TestClass]
    public class PlateLicenseTests
    {
        [TestMethod]
        public void TestPublicPlate1()
        {
            string filepath = @"..\..\Test Images\Public\public1.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            Assert.IsTrue(GateService.reason.Contains("Public transportation vehicles cannot enter the parking lot"));

        }
        [TestMethod]
        public void TestPublicPlate2()
        {
            string filepath = @"..\..\Test Images\Public\public2.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            Assert.IsTrue(GateService.reason.Contains("Public transportation vehicles cannot enter the parking lot"));
        }
        [TestMethod]

        public void testAPIError()
        {
            try
            {
                string filepath = @"..\..\Test Images\GoodPlates\good1.png";
                string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath, apiKey: "error");
                Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            }
            catch(Exception e)
            {
                Assert.IsTrue(e.Message.Contains("API ERROR"));
                Assert.IsTrue(GateService.reason.Contains("There was some problem to recognize your plate, please take a ticket to enter"));

            }

        }
        [TestMethod]

        public void testMilitaryPlate1()
        {
            string filepath = @"..\..\Test Images\Military\Mili1.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            Assert.IsTrue(GateService.reason.Contains("Military and law enforcement vehicles are prohibited"));

        }
        [TestMethod]

        public void testMilitaryPlate2()
        {
            string filepath = @"..\..\Test Images\Military\Mili2.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            Assert.IsTrue(GateService.reason.Contains("Military and law enforcement vehicles are prohibited"));
        }
        [TestMethod]

        public void testEmptyPlate()
        {
            string filepath = @"..\..\Test Images\GoodPlates\EmptyPlate.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsFalse(GateService.GetInstance().isVenichleAllowed(platenum));
            Assert.AreEqual(platenum, "");
            Assert.IsTrue(GateService.reason.Contains("Plate numbers which have no letters at all, cannot enter"));
        }
        [TestMethod]

        public void testGoodPlate()
        {
            string filepath = @"..\..\Test Images\GoodPlates\good3.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsTrue(GateService.GetInstance().isVenichleAllowed(platenum));
        }
        [TestMethod]

        public void testGoodPlateWithOtherText()
        {
            string filepath = @"..\..\Test Images\GoodPlates\goodWithOthertext.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.AreEqual(platenum, "GYJ-FG4");
            Assert.IsTrue(GateService.GetInstance().isVenichleAllowed(platenum));
        }
        [TestMethod]

        public void testInsertToDB()
        {
            string filepath = @"..\..\Test Images\GoodPlates\good1.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.IsTrue(GateService.GetInstance().isVenichleAllowed(platenum));
            ParkingData parkData =  DBService.GetInstance("Plates","AllowedList").FindDataByPlateNumber(platenum);
            Assert.IsTrue(parkData.Allowed);
        }
        [TestMethod]

        public void testGetTextFromImage()
        {
            string filepath = @"..\..\Test Images\GoodPlates\good2.png";
            string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(filepath);
            Assert.AreEqual(platenum, "GHYKNY");
        }       
    }
    
    }

