using FindComic.DataAccess;

namespace FindComic.Test.DataAccessTest
{
    public class CollectionsDataAccessTest
    {
        [Fact]
        public void ConnectionTest()
        {
            var da = new CollectionsDataAccess();
            da.GetScheme();
        }
    }
}
