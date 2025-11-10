namespace ApiEnCouches.DataAccess.DataAccess
{
    using ApiEnCouches.DataAccess.Entity;
    using ApiEnCouches.DataAccess.IDataAccess;

    public class ArticleDataAccess : IArticleDataAccess
    {
        private readonly AppDbContext _context;

        public ArticleDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public void AddArticle(string title, string content)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
            };

            _context.Articles.Add(article);
            _context.SaveChanges();
        }
    }
}