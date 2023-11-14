namespace Halevi.Core.Domain.Utils
{
    public class Pagination
    {
        public Pagination(int actualPage = 1, int pageOffset = 20)
        {
            ActualPage = actualPage;
            PageOffset = pageOffset;
        }

        public int ActualPage { get; }

        public int PageOffset { get; }

        public int Total { get; set; }
    }
}
