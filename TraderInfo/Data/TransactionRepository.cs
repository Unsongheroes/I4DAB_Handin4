using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using TraderInfo.Models;

namespace TraderInfo.Data
{
    public class TransactionRepository : Repository<Transaction>
    {
        private const string DatabaseId = "TraderInfoDb";
        private const string CollectionId = "Transactions";

        public TransactionRepository(IDocumentClient documentClient = null) : base(DatabaseId, CollectionId, documentClient)
        {

        }
    }
}
