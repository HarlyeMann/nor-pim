﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 7/13/2020 4:01:27 AM
  From Machine: DESKTOP-517I8BU
  Template: sql2x.TemplateWithDurianByTypescriptGenerator.ControllerBeginning
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace SolutionNorSolutionPim.AspMvc.Controllers {
    public partial class ProductSearchController : Controller {

        [HttpGet]
        public ActionResult ProductSearchIndex(System.Guid productCategoryId,System.Boolean onParent) {

            List<ProductSearchByCategoryContract> productSearch = 
                new ProductSearchService().ProductSearchByCategory(productCategoryId,onParent);

            return View(
                "~/Views/Templates/Product/ProductSearch/ProductSearchIndex.cshtml",
                productSearch
                );
        }

    }
}