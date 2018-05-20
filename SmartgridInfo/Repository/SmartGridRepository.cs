using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Documents;
using SmartgridInfo.Models;

namespace SmartgridInfo.Repository
{
    public class SmartGridRepository : Repository<SmartGrid>
    {
        private const string DatabaseId = "SmartGridInfoDb";
        private const string CollectionId = "SmartGrids";

        public SmartGridRepository(IDocumentClient documentClient = null) : base(DatabaseId, CollectionId, documentClient)
        {

        }
    }
}
