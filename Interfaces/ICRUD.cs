using System.Collections.Generic;

namespace ProyectoAgencia.Interfaces
{
    public interface ICRUD<T>
    {
        public T Get(int Id);
        public T Create(T t);
        public void Delete(string Id);
        public void Update(T t);
        public List<T> ListAll();
    }
}
