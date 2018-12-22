using System;
using System.Linq;

namespace Test.Infrastructure
{

    public abstract class TestBase
    {
        #region Properties

        protected Random Random { get; }

        #endregion

        #region Constructors

        protected TestBase()
        {
            Random = new Random();
        }

        #endregion

        #region Methods - Protected

        protected T GetRandomEnum<T>(params T[] excludes)
        {
            var items = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(c => !excludes.Any() || excludes.Any(p => p.ToString() == c.ToString()))
                .ToList();
            return items[Random.Next(items.Count)];
        }

        #endregion
    }
}