using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using SmartgridInfo.Repository.Interfaces;

namespace SmartgridInfo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string NewDatabaseId;
        protected string NewCollectionId;

        protected static IDocumentClient Client;


        //Online: vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==
        //local: C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==
        protected static string PrimaryAuthenticationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        //Online: https://f18i4dab.documents.azure.com:443/
        //Local: https://localhost:8081/
        protected static string ServiceEndPoint = "https://localhost:8081/";

        public Repository( string databaseId, string collectionId, IDocumentClient documentClient)
        {
            Client = documentClient;

            NewDatabaseId = databaseId ?? throw new ArgumentException(nameof(databaseId));
            NewCollectionId = collectionId ?? throw new ArgumentException(nameof(collectionId));

            Client = documentClient ?? new DocumentClient(new Uri(ServiceEndPoint), PrimaryAuthenticationKey);

            CreateDatabaseIfNotExist();
            CreateCollectionIfNotExist();
        }


        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document =
                    await Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id));
                return (T)(dynamic) document;
            }
            catch (DocumentClientException e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = Client.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(NewDatabaseId,NewCollectionId), new FeedOptions
            {
                MaxItemCount = -1
            }).Where(predicate).AsDocumentQuery();

            List<T> result = new List<T>();
            while (query.HasMoreResults)
            {
                result.AddRange(await query.ExecuteNextAsync<T>());
            }

            return result;

        }

        public async Task<T> UpdateItemAsync(string id, T item)
        {
            try
            {
                Document document =
                    await Client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id),
                        item);
                return (T)(dynamic)document;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<T> CreateItemAsync(T item)
        {
            Document document =
                await Client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(NewDatabaseId, NewCollectionId),
                    item);
            return (T) (dynamic) document;
        }

        public async Task DeleteItemAsync(string id)
        {
            await Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(NewDatabaseId, NewCollectionId, id));
        }

        #region Creation

        private void CreateDatabaseIfNotExist()
        {
            try
            {
                Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(NewDatabaseId)).Wait();
            }
            catch (AggregateException e)
            {
                Client.CreateDatabaseAsync(new Database() { Id = NewDatabaseId }).Wait();
            }
        }

        private void CreateCollectionIfNotExist()
        {
            try
            {
                Client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(NewDatabaseId, NewCollectionId)).Wait();
            }
            catch (AggregateException e)
            {
               Client.CreateDocumentCollectionAsync(UriFactory.CreateDatabaseUri(NewDatabaseId), new DocumentCollection() {Id = NewCollectionId});
            }
        }
        
        #endregion
    }
}
