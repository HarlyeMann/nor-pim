﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 10/13/2020 2:23:15 PM
  From Machine: DESKTOP-742U247
  Template: sql2x.GenerateDurian.DurianController
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;

namespace SolutionNorSolutionPim.AspMvc {
    public class FinancialOrderSearchController : Controller {

        [HttpGet]
        public ActionResult FinancialOrderSearchIndex() {

            return View(
                "~/Views/Durian/FinancialOrderSearch/FinancialOrderSearch.cshtml"
                );
        }

    }
}
