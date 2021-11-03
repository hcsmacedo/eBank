using eBank.Business.DTO.DTO;
using eBank.Business.Interfaces;
using eBank.Business.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace eBank.Business.UnitTest
{
    [TestFixture]
    public class UnitTestOwner
    {

        #region Validations

        [Test]
        public void TestBusinessServiceManagementOwner_InvalidOwnerDocument_ResultException()
        {
            CheckPropertyValidation cpv =new CheckPropertyValidation();
            var obj = new OwnerDTO { OwnerName = "Heitor M.",OwnerDocument = "345.238.475-20", Active = true };
            var errocount = cpv.myValidation(obj).Count;
            Assert.AreNotEqual(0, errocount);            
        }

        [Test]
        public void TestBusinessServiceManagementOwner_ValidOwnerDocument_ResultTrue()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var obj = new OwnerDTO { OwnerName = "Heitor M.", OwnerDocument = "102.030.405-70", Active = true };
            var errocount = cpv.myValidation(obj).Count;
            Assert.AreEqual(0, errocount);
        }
        #endregion

    }
}
