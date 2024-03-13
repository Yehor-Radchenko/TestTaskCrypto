using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestTaskCrypto.Common
{
    public class NavigationButton : RadioButton
    {
        static NavigationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
        }
    }
}
