using MaterialQuality.Processing.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Processing.Entities
{
    public class Tube : MaterialBase
    {
        public Tube() : base()
        {            
        }

        internal override void AddQualityCheckers()
        {
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityOuterDiameterPlus, CheckOuterDiameterPlus));
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityOuterDiameterMinus, CheckOuterDiameterMinus));
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityWallThicknessPlus, CheckWallThicknessPlus));
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityWallThicknessMinus, CheckWallThicknessMinus));
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityLengthPlus, CheckLengthPlus));
            QualityChecks.Add(new QualityChecker(QualityCode.TubeQualityLengthMinus, CheckLengthMinus));
        }

        public long Id { get; set; }
        public double OuterDiameter { get; set; }
        public double WallThickness { get; set; }
        public double Length { get; set; }    

        private bool CheckOuterDiameterPlus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.OuterDiameter > tolerances.OuterDiameterMax) return true;
            return false;
        }

        private bool CheckOuterDiameterMinus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.OuterDiameter < tolerances.OuterDiameterMin) return true;
            return false;            
        }

        private bool CheckWallThicknessPlus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.WallThickness > tolerances.WallThicknessMax) return true;
            return false;
        }

        private bool CheckWallThicknessMinus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.WallThickness < tolerances.WallThicknessMin) return true;
            return false;
        }

        private bool CheckLengthPlus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.Length > tolerances.LengthMax) return true;
            return false;
        }

        private bool CheckLengthMinus(Tolerances tolerances)
        {
            if (tolerances == null) return false;
            if (this.Length < tolerances.LengthMin) return true;
            return false;
        }
    }
}
