using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using TraderInfo.Interfaces;

namespace TraderInfo.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string NewDatabaseId;
        protected string NewCollectionId;

        protected static IDocumentClient Client;

        protected static string PrimaryAuthenticationKey = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";
        protected static string SecondaryAuthenticationKey = "diJbYp8LfHiSYnivAxe5ev6yIvP87iIEsH42XRkRjmX4GdxBJS73Xl3O7qx1gC33R32LBkxFhQfKkppw2uy1mQ==";
        protected static string ServiceEndPoint = "https://f18i4dab.documents.azure.com:443/";

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
