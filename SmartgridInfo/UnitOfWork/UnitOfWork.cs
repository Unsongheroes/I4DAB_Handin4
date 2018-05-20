using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Documents.SystemFunctions;
using SmartgridInfo.Models;
using SmartgridInfo.Repository;

namespace SmartgridInfo.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly SmartGridRepository _smartGridContext;

        public UnitOfWork(SmartGridRepository context)
        {
            _smartGridContext = context;
        }

        public void AddSmartGridInfo(SmartGrid item)
        {
            _smartGridContext.CreateItemAsync(item).Wait();
        }


        //wrapper funktion
        public SmartGrid GetSmartGridInfo(string id)
        {
            return _smartGridContext.GetItemAsync(id).Result;
        }

        public string GetSmartGridGeneratedPower(string id)
        {
            return _smartGridContext.GetItemAsync(id).Result.TotalGeneratedPower.ToString();
           
        }

        public string GetSmartGridUsedPower(string id)
        {
            return _smartGridContext.GetItemAsync(id).Result.TotalUsedPower.ToString();
        }

        public void UpdatedSmartGridGeneratedPower(string id, int power)
        {
            var changed = new SmartGrid();
            var old = _smartGridContext.GetItemAsync(id).Result;

            changed.SmartGridId = id;
            changed.TotalUsedPower = old.TotalUsedPower;
            changed.TotalGeneratedPower = power;

            _smartGridContext.UpdateItemAsync(id, changed).Wait();
        }

        public void UpdatedSmartGridUsedPower(string id, int power)
        {
            var changed = new SmartGrid();
            var old = _smartGridContext.GetItemAsync(id).Result;

            changed.SmartGridId = id;
            changed.TotalGeneratedPower = old.TotalGeneratedPower;
            changed.TotalUsedPower = power;

            _smartGridContext.UpdateItemAsync(id, changed).Wait();
        }

    }
}
