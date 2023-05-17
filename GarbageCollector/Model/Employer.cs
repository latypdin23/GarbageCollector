using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector.Model
{
    internal class Employer
    {
        private String name;
        private byte age;
        /// <summary>
        /// Инициализирует объект типа Employer
        /// </summary>
        public Employer()
        {

        }
        /// <summary>
        /// Инициализирует объект типа Employer с заданным именем и возрастом
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        public Employer(string name, byte age)
        {
            this.name = name;
            this.age = age;
        }
        /// <summary>
        /// Возвращает имя человека и его возвраст
        /// </summary>
        /// <returns>Строку</returns>
        public override string ToString()
        {
            return $" {name} в возрасте {age} лет";
        }
    }
}
