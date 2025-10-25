using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NT106_Q12_2
{
    public partial class bai7 : Form
    {
        public bai7()
        {
            InitializeComponent();
        }

        private void bai7_Load(object sender, EventArgs e)
        {
            // Nạp danh sách ổ đĩa vào TreeView
            tv.Nodes.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeNode node = new TreeNode(drive.Name)
                    {
                        Tag = drive.RootDirectory.FullName
                    };
                    // Thêm node giả để hiện dấu expand (+)
                    node.Nodes.Add(new TreeNode("Loading..."));
                    tv.Nodes.Add(node);
                }
            }
        }

        private void tv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Nạp nội dung thư mục khi expand
            TreeNode selectedNode = e.Node;
            
            // Nếu node có node con giả (Loading...) thì load thật
            if (selectedNode.Nodes.Count > 0 && selectedNode.Nodes[0].Text == "Loading...")
            {
                selectedNode.Nodes.Clear();
                
                string path = selectedNode.Tag?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(path)) return;

                try
                {
                    // Thêm thư mục con
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    DirectoryInfo[] dirs = dirInfo.GetDirectories();
                    
                    foreach (DirectoryInfo dir in dirs)
                    {
                        // Bỏ qua thư mục ẩn và hệ thống
                        if ((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                            (dir.Attributes & FileAttributes.System) == FileAttributes.System)
                            continue;

                        TreeNode node = new TreeNode(dir.Name)
                        {
                            Tag = dir.FullName
                        };
                        
                        // Kiểm tra xem thư mục có sub-folder không
                        try
                        {
                            if (dir.GetDirectories().Length > 0 || dir.GetFiles().Length > 0)
                            {
                                node.Nodes.Add(new TreeNode("Loading..."));
                            }
                        }
                        catch { }
                        
                        selectedNode.Nodes.Add(node);
                    }

                    // Thêm file
                    FileInfo[] files = dirInfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        // Bỏ qua file ẩn và hệ thống
                        if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
                            (file.Attributes & FileAttributes.System) == FileAttributes.System)
                            continue;

                        TreeNode node = new TreeNode(file.Name)
                        {
                            Tag = file.FullName
                        };
                        selectedNode.Nodes.Add(node);
                    }
                    
                    // Nếu không có gì, thêm node thông báo
                    if (selectedNode.Nodes.Count == 0)
                    {
                        selectedNode.Nodes.Add(new TreeNode("(Empty)"));
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    selectedNode.Nodes.Add(new TreeNode("(Access Denied)"));
                }
                catch (Exception ex)
                {
                    selectedNode.Nodes.Add(new TreeNode($"(Error: {ex.Message})"));
                }
            }
        }

        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Nhấp đúp: nếu là folder thì đi vào (expand), nếu là file thì hiển thị nội dung
            string path = e.Node.Tag?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(path)) return;

            if (Directory.Exists(path))
            {
                // Toggle expand/collapse cho folder
                if (!e.Node.IsExpanded)
                    e.Node.Expand();
                else
                    e.Node.Collapse();
            }
            else if (File.Exists(path))
            {
                ShowFileContent(path);
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Chọn file: hiển thị nội dung
            string path = e.Node.Tag?.ToString() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                ShowFileContent(path);
            }
        }

        private void ShowFileContent(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();

            // Ẩn cả hai control trước
            if (pb.Visible && pb.Image != null)
            {
                // Giải phóng ảnh cũ để tránh khoá file
                var old = pb.Image;
                pb.Image = null;
                old.Dispose();
            }
            pb.Visible = false;
            rtb.Visible = false;
            rtb.Clear();

            try
            {
                // Hiển thị hình ảnh
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif" || ext == ".ico")
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        pb.Image = Image.FromStream(fs);
                    }
                    // Hiển thị ảnh vừa khung, không thay đổi kích thước control
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Visible = true;
                }
                // Hiển thị text
                else if (ext == ".txt" || ext == ".log" || ext == ".cs" || ext == ".json" || 
                         ext == ".xml" || ext == ".md" || ext == ".ini" || ext == ".config" ||
                         ext == ".html" || ext == ".css" || ext == ".js" || ext == ".py" ||
                         ext == ".java" || ext == ".cpp" || ext == ".h" || ext == ".sql")
                {
                    rtb.Text = File.ReadAllText(path);
                    // Không dùng Dock, giữ nguyên kích thước từ Designer
                    rtb.Visible = true;
                }
                else
                {
                    // Thử đọc như text nếu file nhỏ hơn 1MB
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Length < 1024 * 1024) // 1MB
                    {
                        try
                        {
                            rtb.Text = File.ReadAllText(path);
                            rtb.Visible = true;
                        }
                        catch
                        {
                            MessageBox.Show($"Không thể xem loại file này!\n\nFile: {Path.GetFileName(path)}\nKích thước: {fileInfo.Length:N0} bytes", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"File quá lớn để hiển thị!\n\nFile: {Path.GetFileName(path)}\nKích thước: {fileInfo.Length:N0} bytes", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở file:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pb_Click(object sender, EventArgs e)
        {
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
