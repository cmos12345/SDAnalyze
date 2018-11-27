using System.Collections.ObjectModel;

namespace SDAnalyze
{
    public class TreeViewNode
    {
        public string DirectoryPath { get; set; }
        public string Title { get; set; }
        public ObservableCollection<TreeViewNode> ChildNodes { get; set; }

        public TreeViewNode()
        {
            ChildNodes = new ObservableCollection<TreeViewNode>();
        }
    }
}
