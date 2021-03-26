using System;

namespace AuthorProblem
{
    [Author("Viktor")]
    class TestClass
    {
        [Author("Victor2")]
        [Obsolete]
        public void GogiMethod()
        {
        }

        [Author("Victor3")]
        public void ALotOfWork()
        {
        }
    }
}
