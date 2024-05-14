using Grpc.Core;
using ShoppingSystem.gRPCServer.Models;

namespace ShoppingSystem.gRPCServer.Services
{
    public class GrpcPersonService : PersonRepository.PersonRepositoryBase
    {
        public GrpcPersonService() { }

        public override Task<PersonResponseDto> GetPerson(GetPersonRequestDto request, ServerCallContext context)
        {
            List<Person> people = new List<Person>()
            {
                new Person() {Id = 1, FirstName="Parham",LastName ="Darvishi"},
                new Person() {Id = 2, FirstName="Parham2",LastName ="Darvishi2"},
                new Person() {Id = 3, FirstName="Parham3",LastName ="Darvishi3"},
            };
            var person = people.Where(x => x.Id == request.Id).FirstOrDefault();
            return Task.FromResult(new PersonResponseDto()
            {
                Age = 20,
                FirstName = person.FirstName,
                LastName = person.LastName
            });
        }
    }
}
