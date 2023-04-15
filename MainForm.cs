using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using RetroN5DataConverter;

namespace RetroN5FileConverter
{
	public class MainForm : Form
	{
		private IContainer components;
		private Label label1;
		private CheckBox checkBox1;
		private ListView listView1;
		private ImageList imageList1;
		private ListView listView2;
		private ToolTip toolTip1;
		private CheckBox checkBox2;
		private LinkLabel linkLabel1;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;

		public MainForm()
		{
			InitializeComponent();
			_hyperkinbg = listView1.BackgroundImage;
			listView1.BackgroundImage = null;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView2 = new System.Windows.Forms.ListView();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(421, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Drag and drop a save file into either box, then drag out a converted save from th" +
    "e other.";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 177);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(490, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(443, 151);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(35, 13);
			this.linkLabel1.TabIndex = 9;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "About";
			this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(10, 151);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(169, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Compress RetroN5 Save Data";
			this.toolTip1.SetToolTip(this.checkBox1, "This will compress save data when converting a raw save into a RetroN5 save.\r\nAlt" +
        "hough compression is optional, your RetroN5 will compress the save every time yo" +
        "u play.");
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
			this.listView1.HideSelection = false;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(10, 30);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Scrollable = false;
			this.listView1.Size = new System.Drawing.Size(230, 115);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Tile;
			this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListView_ItemDrag);
			this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
			this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
			this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "unknownfile");
			// 
			// listView2
			// 
			this.listView2.AllowDrop = true;
			this.listView2.HideSelection = false;
			this.listView2.LargeImageList = this.imageList1;
			this.listView2.Location = new System.Drawing.Point(250, 30);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Scrollable = false;
			this.listView2.Size = new System.Drawing.Size(230, 115);
			this.listView2.SmallImageList = this.imageList1;
			this.listView2.TabIndex = 10;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Tile;
			this.listView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListView_ItemDrag);
			this.listView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
			this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
			this.listView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(185, 151);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(193, 17);
			this.checkBox2.TabIndex = 11;
			this.checkBox2.Text = "Trim Excess Raw Save Data (GBA)";
			this.toolTip1.SetToolTip(this.checkBox2, resources.GetString("checkBox2.ToolTip"));
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 200;
			this.toolTip1.AutoPopDelay = 32000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.ReshowDelay = 40;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(490, 199);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "RetroN5 File Converter";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private Image _hyperkinbg;
		private string _file1Name;
		private byte[] _file1Buffer;
		private string _file2Name;
		private byte[] _file2Buffer;
		private object _internalDragDrop;

		private void ListView_DragDrop(object sender, DragEventArgs e)
		{
			string path;
			byte[] buffer1;
			byte[] buffer2;

			if (_internalDragDrop == sender)
			{
				// Do nothing, the user dragged a listview file into the same listview.
				return;
			}
			else if (_internalDragDrop != null)
			{
				// Swap filenames, buffers, back colors, and list item texts.
				path = _file1Name;
				_file1Name = _file2Name;
				_file2Name = path;
				buffer1 = _file1Buffer;
				_file1Buffer = _file2Buffer;
				_file2Buffer = buffer1;
				Image tempImage = listView1.BackgroundImage;
				listView1.BackgroundImage = listView2.BackgroundImage;
				listView2.BackgroundImage = tempImage;
				path = listView1.Items[0].Text;
				listView1.Items.RemoveAt(0);
				listView1.Items.Add(new ListViewItem(listView2.Items[0].Text, 0));
				listView2.Items.RemoveAt(0);
				listView2.Items.Add(new ListViewItem(path, 0));
				return;
			}

			if (e.Data.GetData(DataFormats.FileDrop) is string[] paths && paths.Length == 1)
			{
				path = paths[0];
			}
			else
			{
				return;
			}

			try
			{
				buffer1 = File.ReadAllBytes(path);
			}
			catch
			{
				string title = typeof(MainForm).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
				MessageBox.Show("Unable to read file\n" + path + "\nPlease run " + title + " where it has permission to read files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string extension = Path.GetExtension(path);

			if (buffer1.Length >= 24 // RetroN5 save must be at least 24 bytes.
				&& extension.Equals(".sav", StringComparison.OrdinalIgnoreCase)
				&& BitConverter.ToUInt32(buffer1, 0) == Converter.RETRON_DATA_MAGIC)
			{
				// Convert RetroN5 save to raw save.
				// Deserialize the buffer into a RetroN5Data structure, then pass it to a converter
				// to extract the compressed data to a new buffer ready to be written to a file.
				RetroN5Data rtn5 = default;
				rtn5.magic = BitConverter.ToUInt32(buffer1, 0);
				rtn5.fmtVer = BitConverter.ToUInt16(buffer1, 4);
				rtn5.flags = BitConverter.ToUInt16(buffer1, 6);
				rtn5.origSize = BitConverter.ToUInt32(buffer1, 8);
				rtn5.packedSize = BitConverter.ToUInt32(buffer1, 12);
				rtn5.dataOffset = BitConverter.ToUInt32(buffer1, 16);
				rtn5.crc32 = BitConverter.ToUInt32(buffer1, 20);
				rtn5.data = new byte[buffer1.Length - 24];
				Array.Copy(buffer1, 24, rtn5.data, 0, buffer1.Length - 24);
				buffer2 = Converter.ExtractRetroN5Data(rtn5, checkBox2.Checked);
				if (checkBox2.Checked && buffer2.Length == 0x22000)
					MessageBox.Show("The file dropped is an uninitialized save file\n" + path + "\nThe file will not be trimmed for compatibility. You may not want to use it: There is no data in it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				_file2Name = _file1Name = Path.GetFileName(path);

				if (sender as ListView == listView1)
				{
					listView1.BackgroundImage = _hyperkinbg;
					listView2.BackgroundImage = null;
				}
				else
				{
					listView2.BackgroundImage = _hyperkinbg;
					listView1.BackgroundImage = null;
				}
			}
			else if (buffer1.Length >= 1024 // Uncompressed save must be at least 1 kilobyte.
				&& (extension.Equals(".sav", StringComparison.OrdinalIgnoreCase)
				|| extension.Equals(".srm", StringComparison.OrdinalIgnoreCase)))
			{
				// Convert raw save to RetroN5 save.
				// Pass the buffer to the converter to create a RetroN5Data structure,
				// then serialize it to a new buffer ready to be written to a file.
				RetroN5Data rtn5 = Converter.CreateRetroN5Data(buffer1, checkBox1.Checked);
				buffer2 = new byte[rtn5.data.Length + 24];
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.magic), 0, buffer2, 0, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.fmtVer), 0, buffer2, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.flags), 0, buffer2, 6, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.origSize), 0, buffer2, 8, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.packedSize), 0, buffer2, 12, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.dataOffset), 0, buffer2, 16, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(rtn5.crc32), 0, buffer2, 20, 4);
				Array.Copy(rtn5.data, 0, buffer2, 24, rtn5.data.Length);

				if (sender as ListView == listView1)
				{
					_file1Name = Path.GetFileName(path);
					_file2Name = Path.GetFileNameWithoutExtension(path) + ".sav";
					listView1.BackgroundImage = null;
					listView2.BackgroundImage = _hyperkinbg;

				}
				else
				{
					_file2Name = Path.GetFileName(path);
					_file1Name = Path.GetFileNameWithoutExtension(path) + ".sav";
					listView2.BackgroundImage = null;
					listView1.BackgroundImage = _hyperkinbg;
				}
			}
			else
			{
				MessageBox.Show("The file dropped is not a valid save file\n" + path + "\nThe file must have the .sav or .srm extension and pass a minimum size check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (sender as ListView == listView1)
			{
				_file1Buffer = buffer1;
				_file2Buffer = buffer2;
				if (listView1.Items.Count > 0)
					listView1.Items.RemoveAt(0);
				listView1.Items.Add(new ListViewItem(_file1Name, 0));
				if (listView2.Items.Count > 0)
					listView2.Items.RemoveAt(0);
				listView2.Items.Add(new ListViewItem(_file2Name + "*", 0));
			}
			else
			{
				_file2Buffer = buffer1;
				_file1Buffer = buffer2;
				if (listView2.Items.Count > 0)
					listView2.Items.RemoveAt(0);
				listView2.Items.Add(new ListViewItem(_file2Name, 0));
				if (listView1.Items.Count > 0)
					listView1.Items.RemoveAt(0);
				listView1.Items.Add(new ListViewItem(_file1Name + "*", 0));
			}
		}

		private void ListView_DragEnter(object sender, DragEventArgs e)
		{
			if (_internalDragDrop != null)
			{
				e.Effect = DragDropEffects.Move;
				toolStripStatusLabel1.Text = "Ready";
			}
			else if (e.Data.GetData(DataFormats.FileDrop) is string[] paths && paths.Length == 1)
			{
				e.Effect = DragDropEffects.Copy;
				toolStripStatusLabel1.Text = "Ready";
			}
			else
			{
				e.Effect = DragDropEffects.None;
				toolStripStatusLabel1.Text = "Warning: Drop must be a single save file";
			}
		}

		private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			e.Item.Selected = false;
			e.Item.Focused = false;
		}

		private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			string path;
			byte[] buffer;

			ListView senderListView = sender as ListView;
			if (senderListView == listView1)
			{
				path = Path.Combine(Path.GetTempPath(), _file1Name);
				buffer = _file1Buffer;
			}
			else
			{
				path = Path.Combine(Path.GetTempPath(), _file2Name);
				buffer = _file2Buffer;
			}

			if (File.Exists(path) && MessageBox.Show("Temporary file already exists\n" + path + "\nWould you like to overwrite it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
			{
				return;
			}

			try
			{
				File.WriteAllBytes(path, buffer);
			}
			catch
			{
				string title = typeof(MainForm).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
				MessageBox.Show("Unable to write temporary file\n" + path + "\nPlease run " + title + " where it has permission to write temporary files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			toolStripStatusLabel1.Text = "Dragging out a temporary file...";

			_internalDragDrop = sender;
			// This is a blocking operation, it will not exit until you let go of the mouse or complete the replace file dialog.
			DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { path }), DragDropEffects.All);
			_internalDragDrop = null;

			// Regardless of if the file was moved or copied, if it still exists, delete the temporary file.
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
				}
				catch
				{
					MessageBox.Show("Unable to delete temporary file\n" + path + "\nYou may want to find and remove your temporary file later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			toolStripStatusLabel1.Text = "Ready";
		}

		private void linkLabel1_Click(object sender, EventArgs e)
		{
			string title = typeof(MainForm).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
			string version = typeof(MainForm).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			string copyright = typeof(MainForm).Assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

			MessageBox.Show(title + "\nVersion " + version + "\nCopyright " + copyright, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
