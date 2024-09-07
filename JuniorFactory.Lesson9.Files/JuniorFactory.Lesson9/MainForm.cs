using System.Windows.Forms;

namespace JuniorFactory.Lesson9
{
    public partial class MainForm : Form
    {
        Thread _workerThred;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var hardDisk = DriveInfo.GetDrives();
            foreach (var disk in hardDisk)
            {
                hardDiskComboBox.Items.Add(disk.Name);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var disk = hardDiskComboBox.SelectedItem?.ToString();
           // disk = "D:\\Games";
            _workerThred = new Thread(HardDiskSpaceCalculate);
            _workerThred.Start(disk);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _workerThred?.Abort();
        }

        private void HardDiskSpaceCalculate(object? obj)
        {
            var disk = obj?.ToString();
            var dir = new DirectoryInfo(disk);
            var data = DirSize(dir);

            this.UIThread(() =>
            {
                foreach (var diskSpace in data.SubDirs)
                {
                    var parent = treeView1.Nodes.Add(diskSpace.Name + " " + diskSpace.TotalSizeText);
                    parent.Tag = diskSpace;
                    AddTreeNodes(parent, diskSpace);
                }
            });
        }

        public DirectorySpace DirSize(DirectoryInfo d)
        {
            var dirSpace = new DirectorySpace();
            dirSpace.Name = d.Name;
            dirSpace.SubDirs = new List<DirectorySpace>();

            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    dirSpace.Size += fi.Length;
                }

                dirSpace.TotalSize = dirSpace.Size;

                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)//.Take(4))
                {
                    var subDir = DirSize(di);
                    dirSpace.TotalSize += subDir.TotalSize;
                    dirSpace.SubDirs.Add(subDir);
                }
            }
            catch (Exception ex)
            {
                // logs
            }
            return dirSpace;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                var diskSpace = (DirectorySpace)node.Tag;
                AddTreeNodes(node, diskSpace);
            }

        }

        private void AddTreeNodes(TreeNode parent, DirectorySpace spaceData)
        {
            foreach (var diskSpace in spaceData.SubDirs)
            {
                var newParent = parent.Nodes.Add(diskSpace.Name + " " + diskSpace.TotalSizeText);
                newParent.Tag = diskSpace;
                // Local123(newParent, d);
            }
        }
    }


    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code"></param>
        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
            {
                @this.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }
    }
}
