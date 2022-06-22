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

        [Test]
        public void LengthOverMax_GivesQualityCode()
        {
            tolerances.LengthMax = 13500;
            tube.Length = 14000;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityLengthPlus));
        }

        [Test]
        public void LengthUnderMin_GivesQualityCode()
        {
            tolerances.LengthMin = 12500;
            tube.Length = 12400;

            tube.EvaluateQuality(tolerances);

            Assert.IsTrue(tube.DefectCodes.Contains(QualityCode.TubeQualityLengthMinus));
        }

        [Test]
        public void TubeWithinTolerances_GivesNoQualityCode()
        {
            tolerances = new Tolerances
            {
                LengthMin = 12500,
                LengthMax = 13250,
                OuterDiameterMax = 139.6,
                OuterDiameterMin = 136.2,
                WallThicknessMax = 10.6,
                WallThicknessMin = 9.7
            };

            tube = new Tube()
            {
                Length = 13000,
                OuterDiameter = 138,
                WallThickness = 10
            };

            tube.EvaluateQuality(tolerances);

            Assert.AreEqual(true, tube.DefectCodes.Count == 0);
        }
    }
}
