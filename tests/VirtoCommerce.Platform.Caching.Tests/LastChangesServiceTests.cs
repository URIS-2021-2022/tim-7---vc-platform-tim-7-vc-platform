using System;
using System.Threading;
using VirtoCommerce.Platform.Core.ChangeLog;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.ChangeLog;
using Xunit;

namespace VirtoCommerce.Platform.Caching.Tests
{
    [Trait("Category", "Unit")]
    public class LastChangesServiceTests : MemoryCacheTestsBase
    {
        private const string _firstEntity = "FirstEntity";
        private const string _secondEntity = "SecondEntity";

        private class BaseEntity : Entity
        {
        }

        private class DerivedEntity : BaseEntity
        {
        }

        [Fact(Skip = "broken test")] // Need to rewrite all this class and move it to another project
        public void RepeatableRead()
        {
            ILastChangesService lastChangesService = new LastChangesService(GetPlatformMemoryCache());
            var firstEntityFirstAttempt = lastChangesService.GetLastModifiedDate(_firstEntity);
            var secondEntityFirstAttempt = lastChangesService.GetLastModifiedDate(_secondEntity);

            TrueSmallestDelay();

            // Next reads should return the same value

            var firstEntitySecondAttempt = lastChangesService.GetLastModifiedDate(_firstEntity);
            var secondEntitySecondAttempt = lastChangesService.GetLastModifiedDate(_secondEntity);

            Assert.Equal(firstEntityFirstAttempt, firstEntitySecondAttempt);
            Assert.Equal(secondEntityFirstAttempt, secondEntitySecondAttempt);
        }

        [Fact(Skip = "broken test")]
        public void Reset()
        {
            ILastChangesService lastChangesService = new LastChangesService(GetPlatformMemoryCache());
            var firstEntityFirstAttempt = lastChangesService.GetLastModifiedDate(_firstEntity);
            var secondEntityFirstAttempt = lastChangesService.GetLastModifiedDate(_secondEntity);

            TrueSmallestDelay();
            lastChangesService.Reset(_secondEntity);

            // Next read _firstEntity should have the same value.
            // _secondEntity -- different, because it was reset.

            var firstEntitySecondAttempt = lastChangesService.GetLastModifiedDate(_firstEntity);
            var secondEntitySecondAttempt = lastChangesService.GetLastModifiedDate(_secondEntity);

            Assert.Equal(firstEntityFirstAttempt, firstEntitySecondAttempt);
            Assert.NotEqual(secondEntityFirstAttempt, secondEntitySecondAttempt);
        }

        [Fact]
        public void ResetDatesForBaseEntityTypes()
        {
            // Arrange
            ILastChangesService lastChangesService = new LastChangesService(GetPlatformMemoryCache());
            var initialDateForBaseEntity = lastChangesService.GetLastModifiedDate(typeof(BaseEntity).FullName);
            var initialDateForDerivedEntity = lastChangesService.GetLastModifiedDate(typeof(DerivedEntity).FullName);

            // Act
            TrueSmallestDelay();
            lastChangesService.Reset(new DerivedEntity());

            var dateForBaseEntity = lastChangesService.GetLastModifiedDate(typeof(BaseEntity).FullName);
            var dateForDerivedEntity = lastChangesService.GetLastModifiedDate(typeof(DerivedEntity).FullName);

            // Assert
            Assert.NotEqual(dateForBaseEntity, initialDateForBaseEntity);
            Assert.NotEqual(dateForDerivedEntity, initialDateForDerivedEntity);
        }

        private void TrueSmallestDelay()
        {
            var startTime = DateTime.Now;
            while (startTime.Equals(DateTime.Now))
            {
                Thread.Sleep(10);
            }
        }
    }
}
