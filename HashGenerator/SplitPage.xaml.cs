using HashGenerator.Common;

using Windows.UI.Xaml.Controls;

namespace HashGenerator
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for the
    /// currently selected item.
    /// </summary>
    public sealed partial class SplitPage : LayoutAwarePage
    {
        public SplitPage()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            (DataContext as ViewModel).Text = ((TextBox) sender).Text;
        }
    }
}
