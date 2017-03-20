using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MeteoroloskiPromatrac
{
    public partial class OAplikaciji : ContentPage
    {
        public OAplikaciji()
        {
            InitializeComponent();
        }
        public void Povratak(object sender, EventArgs args) {
            Navigation.PopAsync();
        }
    }
}
