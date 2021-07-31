using FindComic.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
