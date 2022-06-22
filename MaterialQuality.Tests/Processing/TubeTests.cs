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

        [Test]
        public void DiameterUnderMin_GivesQualityCode()
        {
            tolerances.OuterDiameterMin = 139.1;
            tube.OuterDiameter = 139;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityOuterDiameterMinus));
        }

        [Test]
        public void WallThicknessOverMax_GivesQualityCode()
        {
            tolerances.WallThicknessMax = 9.8;
            tube.WallThickness = 10;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityWallThicknessPlus));
        }

        [Test]
        public void WallThicknessUnderMin_GivesQualityCode()
        {
            tolerances.WallThicknessMin = 8.7;
            tube.WallThickness = 8;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityWallThicknessMinus));
        }
    }
}
