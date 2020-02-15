/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 2/15/2020 3:38:16 AM
  Template: sql2x.TemplateCrudeContract.CrudeContract
*/
using System.Runtime.Serialization;

namespace SolutionNorSolutionPim.BusinessLogicLayer {
    
    
    [DataContract()]
    public partial class CrudeProductFieldSetMappingContract {
        
        [DataMember()]
        public System.Guid ProductFieldSetMappingId { get; set; } //;
        
        [DataMember()]
        public System.Guid ProductFieldSetId { get; set; } //;
        
        [DataMember()]
        public string ProductIdentifierRcd { get; set; } //;
        
        [DataMember()]
        public string ProductAttributeRcd { get; set; } //;
        
        [DataMember()]
        public string ProductInfoRcd { get; set; } //;
        
        [DataMember()]
        public string ProductImageTypeRcd { get; set; } //;
        
        [DataMember()]
        public string ProductDocumentationTypeRcd { get; set; } //;
        
        [DataMember()]
        public System.Guid UserId { get; set; } //;
        
        [DataMember()]
        public System.DateTime DateTime { get; set; } //;
    }
}
