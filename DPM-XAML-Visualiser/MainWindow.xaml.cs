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
            source.updateDirectoryStructure();

            source.debug();


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

        private void LoadDirectoryStructure()
        {
            // Assuming you have a method to load or parse your directory structure
            var rootDirectory = new Directory("Root Directory Name");
            // Populate the rootDirectory with its files and subdirectories here...

            // Bind the rootDirectory to the TreeView
            DirectoryTreeView.Items.Add(CreateTreeViewItem(rootDirectory));
        }

        private TreeViewItem CreateTreeViewItem(object item)
        {
            var treeViewItem = new TreeViewItem { Header = item.ToString() };

            if (item is Directory dir)
            {
                foreach (var child in dir.Children)
                {
                    treeViewItem.Items.Add(CreateTreeViewItem(child));
                }
            }

            // Optionally, handle selection changed or other events here

            return treeViewItem;
        }

        private void DirectoryTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = e.NewValue as TreeViewItem;
            // Implement your interaction logic here, e.g., update a details view or open a file
        }


    }
}