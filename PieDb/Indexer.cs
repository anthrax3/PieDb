using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace PieDb
{
    public class Indexer
    {
        private readonly PieDb _pieDb;
        public string Location { get; set; }

        public Indexer(PieDb pieDb)
        {
            _pieDb = pieDb;
            _pieDb.DocumentAdded += AddDocumentToIndex;
            _pieDb.DocumentRemoved += RemoveDocumentFromIndex;
            _pieDb.DocumentUpdated += UpdateDocumentInIndex;

            Location = Path.Combine(_pieDb.Location, "Indexes");
            var directoryInfo = new DirectoryInfo(Location);
            directoryInfo.Create();
        }

        private void UpdateDocumentInIndex(PieDocument document)
        {
            
        }

        private void RemoveDocumentFromIndex(PieDocument document)
        {
            
        }

        private void AddDocumentToIndex(PieDocument document)
        {
            
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> @where)
        {
            var session = null as Lucene.Net.Linq.ISession<T>;
            var indexQ = session.Query();
            if (@where != null) indexQ = indexQ.Where(where);
            return indexQ.Select(item => item /* .GetStoredPieId().Select(id => _pieDb.Get<T>(id); */);
            //actually want to get the items from the datastore, not the index
        }

        public void Dispose()
        {
            //release
        }
    }
}