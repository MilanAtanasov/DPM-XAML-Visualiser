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
using System.Windows.Forms;


namespace DPM_XAML_Visualiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonChoseFile_Click(object sender, RoutedEventArgs e)
        {
            // Create a new File object
            FileItem file = new FileItem("File", "XAML");

            // Get the instance of the Source class
            Source source = Source.GetInstance();

            // Set the source path to the selected file
            source.SourcePath = fileSelectionDialog(sender, e);
            



        }

        private string fileSelectionDialog(object sender, RoutedEventArgs e)
        {
            string path = "Pfad"; // Default path value
                                  // Create an OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to select only XAML files
            openFileDialog.Filter = "XAML Files (*.xaml)|*.xaml";

            // Set the title of the dialog
            openFileDialog.Title = "Select a XAML file";

            // Show the OpenFileDialog
            DialogResult result = openFileDialog.ShowDialog();

            // If the result is OK then set the path
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Set the path to the selected file
                path = openFileDialog.FileName;
            }
            return path;
        }

    }
}