﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 4/16/2020 8:44:32 PM
  Template: sql2x.ContractsGenerator.MethodNewStyle
*/
using System.Runtime.Serialization;
namespace SolutionNorSolutionPim.BusinessLogicLayer {
    
    
    [DataContract()]
    public class DefaultPerformanceTimeCommandsContract {
        
        [DataMember()]
        public string CommandName { get; set; } //;
        
        [DataMember()]
        public string CommandDisplayName { get; set; } //;
    }
}
