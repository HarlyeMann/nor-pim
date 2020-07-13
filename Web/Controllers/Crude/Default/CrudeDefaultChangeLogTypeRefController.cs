﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 7/13/2020 2:50:26 PM
  From Machine: DESKTOP-517I8BU
  Template: sql2x.TemplateFromCrudeMvcGenerator.ControllerBeginning
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;

namespace SolutionNorSolutionPim.AspMvc.Controllers {
    public class CrudeDefaultChangeLogTypeRefController : Controller {

        [HttpGet]
        public ActionResult CrudeDefaultChangeLogTypeRefIndex() {

            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefIndex.cshtml",
                new CrudeDefaultChangeLogTypeRefServiceClient().FetchAll()
                );
        }

        [HttpGet]
        public ActionResult CrudeDefaultChangeLogTypeRefDetails(System.String defaultChangeLogTypeRcd) {

            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefDetails.cshtml",
                new CrudeDefaultChangeLogTypeRefServiceClient().FetchByDefaultChangeLogTypeRcd(defaultChangeLogTypeRcd)
                );
        }

        [HttpGet]
        public ActionResult CrudeDefaultChangeLogTypeRefEdit(
            System.String defaultChangeLogTypeRcd
            ) {

            CrudeDefaultChangeLogTypeRefContract contract = new CrudeDefaultChangeLogTypeRefServiceClient().FetchByDefaultChangeLogTypeRcd(defaultChangeLogTypeRcd);

            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefEdit.cshtml",
                contract
                );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrudeDefaultChangeLogTypeRefEdit([Bind()] CrudeDefaultChangeLogTypeRefContract contract) {
            if (ModelState.IsValid) {
                contract.DefaultUserId = new System.Guid("{FFFFFFFF-5555-5555-5555-FFFFFFFFFFFF}");

                contract.DateTime = DateTime.UtcNow;

                new CrudeDefaultChangeLogTypeRefServiceClient().Update(contract);

                return RedirectToAction("CrudeDefaultChangeLogTypeRefIndex");
            }

            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefEdit.cshtml",
                contract
                );
        }

        [HttpGet]
        public ActionResult CrudeDefaultChangeLogTypeRefCreate(System.Guid? defaultUserId) {
            var contract = new CrudeDefaultChangeLogTypeRefContract();
            if (defaultUserId != null) contract.DefaultUserId = (System.Guid) defaultUserId;

            if (defaultUserId == null)
                contract.DefaultUserId = new System.Guid("{FFFFFFFF-5555-5555-5555-FFFFFFFFFFFF}");

            contract.DateTime = DateTime.UtcNow;


            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefCreate.cshtml",
                contract
                );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrudeDefaultChangeLogTypeRefCreate([Bind()] CrudeDefaultChangeLogTypeRefContract contract) {
            if (ModelState.IsValid) {

                new CrudeDefaultChangeLogTypeRefServiceClient().Insert(contract);

                return RedirectToAction("CrudeDefaultChangeLogTypeRefIndex");
            }

            return View(
                "~/Views/Crude/Default/CrudeDefaultChangeLogTypeRef/CrudeDefaultChangeLogTypeRefCreate.cshtml",
                contract
                );
        }

        [HttpGet]
        public ActionResult CrudeDefaultChangeLogTypeRefDelete(
            System.String defaultChangeLogTypeRcd
            ) {
            new CrudeDefaultChangeLogTypeRefServiceClient().Delete(defaultChangeLogTypeRcd);

            return RedirectToAction("CrudeDefaultChangeLogTypeRefIndex");
        }
    }
}
