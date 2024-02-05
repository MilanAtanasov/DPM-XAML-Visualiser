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
            //TODO
        }
    }
}
