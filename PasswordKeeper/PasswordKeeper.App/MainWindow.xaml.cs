using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordKeeper.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NoteViewModel noteViewModel = new NoteViewModel(new NoteService(new DataNote()));
        private PasswordViewModel passwordViewModel = new PasswordViewModel(new PasswordService(new DataPassword()));
        private LinkViewModel linkViewModel = new LinkViewModel(new LinkService(new DataLink()));
        public MainWindow()
        {
            InitializeComponent();
        }


        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PasswordPage(passwordViewModel);
        }

        private void LinksButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LinkPage(linkViewModel);
        }

        private void NoteButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotePage(noteViewModel);

        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void PasswordButton_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}