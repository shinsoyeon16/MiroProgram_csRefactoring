using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMiroProgram.ViewModel;
using WPFMiroProgram.Maze;

namespace WPFMiroProgram
{
    /// <summary>
    /// EscapeMiro.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class EscapeMiroView : UserControl
    {
        EscapeMiroViewModel vmd;
        MiroList ml;
        public EscapeMiroView()
        {
            vmd = new EscapeMiroViewModel();
            ml = new MiroList();
            InitializeComponent();
            this.DataContext = vmd;
            lbx.DataContext = ml;
        }


        private void lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vmd.SelectedChange(lbx.SelectedIndex);
        }
    }
}
