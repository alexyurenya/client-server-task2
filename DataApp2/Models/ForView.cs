using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp2.Models
{
    public class ForView
    {
        public IEnumerable<Phone> Phones { get; set; } //для списка пользователей       
        public string Name { get; set; } //для введенного имени
    }


}
