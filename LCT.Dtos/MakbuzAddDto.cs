using System;
using System.Collections.Generic;
using System.Text;

namespace LCT.Dtos
{
   public class MakbuzAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? Date { get; set; }
        public int Amount { get; set; }
    }
}
