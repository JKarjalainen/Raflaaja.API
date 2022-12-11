using NUnit.Framework;

using Raflaaja.DAL;
using System.Linq;

namespace Raflaaja.Tests
{
    public class DatabaseTests
    {
        private DatabaseContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new DatabaseContext();
        }

        [Test]
        public void TestProducts()
        {
            var products = _dbContext.Products.ToList();
            Assert.That(products.Count, Is.AtLeast(1));
        }


        [Test]
        public void TestUsers()
        {
            var users = _dbContext.Users.ToList();
            Assert.That(users.Count, Is.AtLeast(1));
        }
    }
}
