﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 4/22/2020 5:37:58 AM
  Template: sql2x.CrudeDotNetCoreGenerator.CrudeRESTDotNetCoreModel
*/
using System.ComponentModel.DataAnnotations;
namespace SolutionNorSolutionPim.BusinessLogicLayer.Models {
    
    
    public partial class CrudeFinancialVoucherModel {
        
        [Display(Name="Financial Voucher Id")]
        [Required()]
        public System.Guid FinancialVoucherId { get; set; } //;
        
        [Display(Name="User Id")]
        [Required()]
        public System.Guid UserId { get; set; } //;
        
        [Display(Name="Date Time")]
        [Required()]
        public System.DateTime DateTime { get; set; } //;
        
        [Display(Name="Value Amount")]
        [Required()]
        public decimal ValueAmount { get; set; } //;
        
        [Display(Name="Valid From Date Time")]
        [Required()]
        public System.DateTime ValidFromDateTime { get; set; } //;
        
        [Display(Name="Valid Until Date Time")]
        [Required()]
        public System.DateTime ValidUntilDateTime { get; set; } //;
        
        [Display(Name="Financial Currency Id")]
        [Required()]
        public System.Guid FinancialCurrencyId { get; set; } //;
        
        [Display(Name="Voucher Number")]
        [Required()]
        public int VoucherNumber { get; set; } //;
        
        [Display(Name="Voucher Description")]
        [Required()]
        public string VoucherDescription { get; set; } //;
        
        [Display(Name="Financial Voucher Type")]
        [Required()]
        public string FinancialVoucherTypeRcd { get; set; } //;
    }
}
