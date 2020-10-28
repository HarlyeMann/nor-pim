﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 10/28/2020 9:22:38 PM
  From Machine: DESKTOP-9A2DH39
  Template: sql2x.TemplateCrudeContract.CrudeContract
*/
using System.Runtime.Serialization;

namespace SolutionNorSolutionPim.BusinessLogicLayer {

    [DataContract()]
    public partial class CrudeDefaultResourceMeasurementContract {
        
        [DataMember()]
        public System.Guid DefaultResourceMeasurementId { get; set; }
        
        [DataMember()]
        public int ClientWorkingsetBytes { get; set; }
        
        [DataMember()]
        public int BusinessWorkingsetBytes { get; set; }
        
        [DataMember()]
        public int DatabaseSizeBytes { get; set; }
        
        [DataMember()]
        public System.Guid DefaultUserId { get; set; }
        
        [DataMember()]
        public System.DateTime DateTime { get; set; }
    }
}
