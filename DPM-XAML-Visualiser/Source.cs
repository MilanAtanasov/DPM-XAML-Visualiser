using System.Diagnostics;
using System.Xml.Linq;

namespace DPM_XAML_Visualiser
{
    internal class Source
    {
        // Static variable that holds the single instance
        private static Source instance;

        // Object for locking to ensure thread safety
        private static readonly object lockObject = new object();

        // Property to get or set the source path
        public string SourcePath { get; set; }
        public Directory Root { get; set; }

        // Private constructor to prevent instantiation from outside
        private Source() { }

        // Public static method to access the singleton instance
        public static Source GetInstance()
        {
            // Double-check locking mechanism
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Source();
                    }
                }
            }
            return instance;
        }

        // Method to create the directory structure
        public void updateDirectoryStructure()
        {
            // Assuming you have a method to load or parse your directory structure
            var rootDirectory = new Directory("Root Directory Name");

            // Add the root directory to the source
            Root = rootDirectory;

            // Load the directory structure from the XAML file
            LoadDirectoryStructure(SourcePath);


        }

        // Method to get the read the XAML file, and create the directory structure by making the object of the Directory class

        public void LoadDirectoryStructure(string filePath)
        {
            // Clear existing structure
            Root = null;

            // Load the XAML (XML) file
            var xDocument = XDocument.Load(filePath);

            // Parse the root directory element
            var rootElement = xDocument.Element("Directory");
            if (rootElement != null)
            {
                Root = ParseDirectory(rootElement);
            }
        }

        private Directory ParseDirectory(XElement directoryElement)
        {
            var directory = new Directory(directoryElement.Attribute("name")?.Value);

            // Parse each child of the directory
            foreach (var element in directoryElement.Elements())
            {
                if (element.Name == "Directory")
                {
                    directory.Children.Add(ParseDirectory(element));
                }
                else if (element.Name == "File")
                {
                    var file = new FileItem(element.Attribute("name")?.Value, element.Attribute("type")?.Value);                    
                    directory.Children.Add(file);
                }
            }

            return directory;
        }

        public void debug()
        {
            // print the directory structure with files and subdirectories
            Debug.Print(SourcePath);

            var instance1 = Source.GetInstance();
            if (instance1.Root == null)
            {
                Debug.Print("Root directory is null.");
                return;
            }

            foreach (var child in instance1.Root.Children)
            {
                Debug.Print(child.Name);
                if (child is Directory dir)
                {
                    foreach (var subChild in dir.Children)
                    {
                        Debug.Print("  " + subChild.Name);
                    }
                }
            }

        }

    }
}
