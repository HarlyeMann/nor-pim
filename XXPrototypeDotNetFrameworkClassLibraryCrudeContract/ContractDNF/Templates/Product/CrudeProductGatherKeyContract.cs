/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 3/13/2020 10:40:29 AM
  Template: sql2x.TemplateCrudeContract.CrudeContract
*/
using System.Runtime.Serialization;

namespace SolutionNorSolutionPim.BusinessLogicLayer {
    
    
    [DataContract()]
    public partial class CrudeProductGatherKeyContract {
        
        [DataMember()]
        public System.Guid ProductGatherKeyId { get; set; } //;
        
        [DataMember()]
        public string ProductGatherKeyValue { get; set; } //;
        
        [DataMember()]
        public System.Guid ProductGatherId { get; set; } //;
        
        [DataMember()]
        public System.Guid UserId { get; set; } //;
        
        [DataMember()]
        public System.DateTime DateTime { get; set; } //;
    }
}
