using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDBEvolution
{
    public class Avtor
    {
        public Avtor(int ID , string Name, string Surmame, string Patronymic)
        { 
            this.ID = ID;
            this.Name = Name;
            this.Surmame = Surmame;
            this.Patronymic = Patronymic;
        }
        public override string ToString()
        {
            return $"{Surmame}.{Name[0]}.{Patronymic[0]}";
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surmame { get; set; }
        public string Patronymic { get; set; }
    }
}
