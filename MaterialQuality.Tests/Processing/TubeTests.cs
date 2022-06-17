using MaterialQuality.Processing.Entities;
using MaterialQuality.Processing.Constants;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Tests.Processing
{
    [TestFixture]
    public class TubeTests
    {
        Tolerances tolerances;
        Tube tube;

        [SetUp]
        public void SetUp()
        {
            tolerances = new Tolerances();
            tube = new Tube();
        }

        [Test]
        public void DiameterOverMax_GivesQualityCode()
        {
            tolerances.OuterDiameterMax = 139.1;
            tube.OuterDiameter = 140;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityOuterDiameterPlus));
        }
    }
}
