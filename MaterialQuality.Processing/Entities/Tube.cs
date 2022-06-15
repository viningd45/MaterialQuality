using MaterialQuality.Processing.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Processing.Entities
{
    public class Tube : QualityCheckBase
    {
        public Tube() : base()
        {            
        }

        internal override void AddQualityChecks()
        {
            QualityChecks.Add(CheckOuterDiameter);
            QualityChecks.Add(CheckWallThickness);
        }

        public long Id { get; set; }
        public double OuterDiameter { get; set; }
        public double WallThickness { get; set; }
        public double Length { get; set; }    

        private void CheckOuterDiameter(Tolerances tolerances)
        {
            if (tolerances == null) return;

            if (this.OuterDiameter > tolerances.OuterDiameterMax)
                this.DefectCodes.Add(QualityCode.TubeQualityOuterDiameterPlus);
            if(this.OuterDiameter < tolerances.OuterDiameterMin)
                this.DefectCodes.Add(QualityCode.TubeQualityOuterDiameterMinus);
        }

        private void CheckWallThickness(Tolerances tolerances)
        {
            if (tolerances == null) return;

            if (this.WallThickness > tolerances.WallThicknessMax)
                this.DefectCodes.Add(QualityCode.TubeQualityWallThicknessPlus);
            if (this.WallThickness < tolerances.WallThicknessMin)
                this.DefectCodes.Add(QualityCode.TubeQualityWallThicknessMinus);
        }
    }
}
