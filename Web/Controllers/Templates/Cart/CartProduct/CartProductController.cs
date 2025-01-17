﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 12/30/2020 12:15:23 PM
  From Machine: DESKTOP-LSRVP12
  Template: sql2x.TemplateWithDurianByTypescriptGenerator.ControllerBeginning
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace SolutionNorSolutionPim.AspMvc.Controllers {
    public partial class CartProductController : Controller {

        [HttpGet]
        public ActionResult CartProductIndex(System.Guid clientId,System.Guid productId,System.Guid financialCurrencyId,System.Guid userId,System.Guid cartProductId,System.String sessionIdentificator) {

            List<GetCartProductContract> cart_product = 
                new CartProductSearchService().GetCartProduct(clientId,productId,financialCurrencyId,userId,cartProductId,sessionIdentificator);

            return View(
                "~/Views/Templates/Cart/CartProduct/CartProductIndex.cshtml",
                cart_product
                );
        }

    }
}
