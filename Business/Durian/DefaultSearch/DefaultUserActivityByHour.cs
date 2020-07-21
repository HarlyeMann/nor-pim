﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 7/21/2020 9:25:02 AM
  From Machine: DESKTOP-517I8BU
  Template: sql2x.GenerateBusinessLogicLayer.DefaultUsing
*/
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;
using SolutionNorSolutionPim.DataAccessLayer;

namespace SolutionNorSolutionPim.BusinessLogicLayer {

    public class DefaultUserActivityByHour {
        
        public List<DefaultUserActivityByHourContract> DefaultUserActivityByHourFromDal(List<DefaultUserActivityByHourData> dataList) {
           var list = new List<DefaultUserActivityByHourContract>();

           foreach (DefaultUserActivityByHourData data in dataList) {
               var contract = new DefaultUserActivityByHourContract();
               DataToContract(data, contract);
               list.Add(contract);
           }

           return list;
        }
        
        public void DataToContract(DefaultUserActivityByHourData dalDefaultUserActivityByHour, DefaultUserActivityByHourContract dataContract) {
            dataContract.HourNumber = dalDefaultUserActivityByHour.HourNumber;
            dataContract.HourCount = dalDefaultUserActivityByHour.HourCount;
        }
    }
}
