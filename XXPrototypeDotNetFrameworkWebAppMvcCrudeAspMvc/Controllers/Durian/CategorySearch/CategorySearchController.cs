﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 4/27/2020 3:55:27 PM
  Template: sql2x.GenerateDurian.DurianController
*/
using SolutionNorSolutionPim.BusinessLogicLayer;
using System;
using System.Web.Mvc;

namespace SolutionNorSolutionPim.AspMvc {
    public class CategorySearchController : Controller {

        [HttpGet]
        public ActionResult CategorySearchIndex() {

            return View(
                "~/Views/Durian/CategorySearch/CategorySearch.cshtml"
                );
        }

    }
}
