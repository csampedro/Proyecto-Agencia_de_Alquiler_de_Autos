
using ProjectAgency;

namespace ProyectoAgencia.Interfaces
{
    public interface ICarCRUD
    {
        public Car Get(string Id);
        public Car Create(Car car);
        public void Delete(string patent);
        public void Update(string Id);
        public Car ListAll();
    }
}
