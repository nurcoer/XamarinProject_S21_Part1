using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCT.Mobile.Views
{
    public class OpenFlyoutMenuItem
    {
        public OpenFlyoutMenuItem()
        {
            TargetType = typeof(OpenFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }

        
    }
}