﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 12/30/2020 12:16:39 PM
  From Machine: DESKTOP-LSRVP12
  Template: sql2x.TemplateByServiceTableCrudGenerator.ControllerBeginning
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;

namespace SolutionNorSolutionPim.AspMvc.Controllers {
    public partial class ProductReferenceImageTypeController : Controller {

        [HttpGet]
        public ActionResult ProductReferenceImageTypeIndex() {

            return RedirectToAction(
                    "ProductReferenceImageTypeEdit",
                    new {    productInfoRcd = String.Empty    }
                    );
        }

        [HttpGet]
        public ActionResult ProductReferenceImageTypeCreate(System.Guid? userId) {
            var productContract = new ProductReferenceImageTypeContract();
            productContract.ProductInfoRefNew = new CrudeProductInfoRefContract();
            if (userId != null) productContract.ProductInfoRefNew.UserId = (System.Guid) userId;

            if (userId == null)
                productContract.ProductInfoRefNew.UserId = new System.Guid("{FFFFFFFF-5555-5555-5555-FFFFFFFFFFFF}");

            productContract.ProductInfoRefNew.DateTime = DateTime.UtcNow;

            return View(
                "~/Views/Templates/ProductReference/ProductReferenceImageType/ProductReferenceImageTypeCreate.cshtml",
                productContract
                );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductReferenceImageTypeCreate([Bind()] ProductReferenceImageTypeContract productContract) {
            if (ModelState.IsValid) {

                new CrudeProductInfoRefServiceClient().Insert(productContract.ProductInfoRefNew);

                return RedirectToAction(
                        "ProductReferenceImageTypeEdit",
                        new {    productInfoRcd = String.Empty}
                        );
            }

            return View(
                "~/Views/Templates/ProductReference/ProductReferenceImageType/ProductReferenceImageTypeCreate.cshtml",
                productContract
                );
        }

    }
}
