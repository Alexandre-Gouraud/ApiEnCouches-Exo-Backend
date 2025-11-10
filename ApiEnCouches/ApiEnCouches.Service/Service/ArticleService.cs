namespace ApiEnCouches.Service.Service
{
    using ApiEnCouches.Service.IService;
    using ApiEnCouches.DataAccess.IDataAccess;

    public class ArticleService : IArticleService
    {
        private readonly IArticleDataAccess _dataAccess;

        public ArticleService(IArticleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void AddArticle(string title, string content)
        {
            // Basic validation could go here (e.g., check null/empty)
            _dataAccess.AddArticle(title, content);
        }
    }
}