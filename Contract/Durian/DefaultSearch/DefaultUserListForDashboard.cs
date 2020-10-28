﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 10/28/2020 9:30:24 PM
  From Machine: DESKTOP-9A2DH39
  Template: sql2x.ContractsGenerator.MethodNewStyle
*/
using System.Runtime.Serialization;
namespace SolutionNorSolutionPim.BusinessLogicLayer {

    [DataContract()]
    public class DefaultUserListForDashboardContract {
        
        [DataMember()]
        public string DefaultUserCode { get; set; }
        
        [DataMember()]
        public string DefaultUserName { get; set; }
        
        [DataMember()]
        public string Email { get; set; }
        
        [DataMember()]
        public string DefaultStateName { get; set; }
        
        [DataMember()]
        public int ActivityCount { get; set; }
        
        [DataMember()]
        public string LastActivityDateTime { get; set; }
        
        [DataMember()]
        public string CreatedDateTime { get; set; }
        
        [DataMember()]
        public string CreatedByDefaultUserCode { get; set; }
        
        [DataMember()]
        public string CreatedByDefaultUserName { get; set; }
        
        [DataMember()]
        public System.Guid DefaultUserId { get; set; }
    }
}
