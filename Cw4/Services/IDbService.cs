using Cw4.Models;
using System.Collections.Generic;

namespace Cw4.Services
{
    public interface IDbService
    {
        // IEnumerable<Animal> GetAnimals();
        IEnumerable<Animal> GetAnimals(string orderBy);
        void AddAnimal(Animal animal);
        void PutAnimal(Animal animal);
        void RemoveAnimal(string idAnimal);

    }
}
