namespace unit_tests_web_api.BookReview;

public interface IReviewRepository
{
    public IQueryable<BookReview> AllReviews { get; }

    void Create(BookReview review);
    void Remove(BookReview result);
    void SaveChanges();
}