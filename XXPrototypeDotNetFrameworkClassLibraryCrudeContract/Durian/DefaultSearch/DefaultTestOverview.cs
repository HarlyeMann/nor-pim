﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 4/16/2020 8:43:52 PM
  Template: sql2x.ContractsGenerator.MethodNewStyle
*/
using System.Runtime.Serialization;
namespace SolutionNorSolutionPim.BusinessLogicLayer {
    
    
    [DataContract()]
    public class DefaultTestOverviewContract {
        
        [DataMember()]
        public string TestArea { get; set; } //;
        
        [DataMember()]
        public System.DateTime StartDateTime { get; set; } //;
        
        [DataMember()]
        public string DefaultTestRunResultRcd { get; set; } //;
    }
}
