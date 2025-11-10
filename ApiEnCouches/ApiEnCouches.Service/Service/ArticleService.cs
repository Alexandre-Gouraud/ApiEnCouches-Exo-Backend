namespace ApiEnCouches.Service.Service
{
    using System.Threading.Tasks;
    using ApiEnCouches.DataAccess.IDataAccess;

    public class ArticleService
    {
        private readonly IArticleDataAccess _dataAccess;

        public ArticleService(IArticleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task AddArticleAsync(string title, string content)
        {
            // Basic validation could go here (e.g., check null/empty)
            return _dataAccess.AddArticleAsyn(new DataAccess.Entity.Article
            {
                Title = title,
                Content = content
            });
        }
    }
}