using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebAPI01.Domain;

namespace TestProject1
{
    public class TestPersonRepository
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var personRepository = testHelper.PersonRepository;

            Person person = new Person { Id = 1, Name = "Nic" };
            personRepository.AddAsync(person).Wait();

            Assert.Equal(1, personRepository.GetByIdAsync(1).Result.Id);
            Assert.True(personRepository.GetAllAsync().Result.Count == 1);
            Assert.Equal("Nic", personRepository.GetByIdAsync(1).Result.Name);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void TestMultipleAdd(int id, int expected)
        {
            var testHelper = new TestHelper();
            var personRepository = testHelper.PersonRepository;

            Person person = new Person { Id = id, Name = "Nic" };
            personRepository.AddAsync(person).Wait();

            Assert.Equal(expected, personRepository.GetByIdAsync(id).Result.Id);
        }
    }
}
