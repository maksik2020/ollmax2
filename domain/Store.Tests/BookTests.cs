using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("    ");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 12345-15-44 0");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 12345-15-44 0123");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("fsfs IsBn 12345-15-44 0 werwe");
            Assert.False(actual);
        }
    }
}
