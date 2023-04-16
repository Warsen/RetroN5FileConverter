using System.ComponentModel;
using System.Reflection;

namespace RetroN5FileConverter;

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
		components = new Container();
		ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
		label1 = new Label();
		statusStrip1 = new StatusStrip();
		toolStripStatusLabel1 = new ToolStripStatusLabel();
		linkLabel1 = new LinkLabel();
		checkBox1 = new CheckBox();
		listView1 = new ListView();
		imageList1 = new ImageList(components);
		listView2 = new ListView();
		checkBox2 = new CheckBox();
		toolTip1 = new ToolTip(components);
		statusStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(10, 9);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.Name = "label1";
		label1.Size = new Size(469, 15);
		label1.TabIndex = 4;
		label1.Text = "Drag and drop a save file into either box, then drag out a converted save from the other.";
		// 
		// statusStrip1
		// 
		statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
		statusStrip1.Location = new Point(0, 177);
		statusStrip1.Name = "statusStrip1";
		statusStrip1.Padding = new Padding(1, 0, 16, 0);
		statusStrip1.Size = new Size(491, 22);
		statusStrip1.SizingGrip = false;
		statusStrip1.TabIndex = 7;
		statusStrip1.Text = "statusStrip1";
		// 
		// toolStripStatusLabel1
		// 
		toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		toolStripStatusLabel1.Size = new Size(39, 17);
		toolStripStatusLabel1.Text = "Ready";
		// 
		// linkLabel1
		// 
		linkLabel1.AutoSize = true;
		linkLabel1.Location = new Point(438, 152);
		linkLabel1.Margin = new Padding(4, 0, 4, 0);
		linkLabel1.Name = "linkLabel1";
		linkLabel1.Size = new Size(40, 15);
		linkLabel1.TabIndex = 9;
		linkLabel1.TabStop = true;
		linkLabel1.Text = "About";
		linkLabel1.LinkClicked += linkLabel1_LinkClicked;
		// 
		// checkBox1
		// 
		checkBox1.AutoSize = true;
		checkBox1.Checked = true;
		checkBox1.CheckState = CheckState.Checked;
		checkBox1.Location = new Point(10, 152);
		checkBox1.Margin = new Padding(4, 3, 4, 3);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new Size(179, 19);
		checkBox1.TabIndex = 5;
		checkBox1.Text = "Compress RetroN5 Save Data";
		toolTip1.SetToolTip(checkBox1, "This will compress save data when converting a raw save into a RetroN5 save.\r\nAlthough compression is optional, your RetroN5 will compress the save every time you play.");
		checkBox1.UseVisualStyleBackColor = true;
		// 
		// listView1
		// 
		listView1.AllowDrop = true;
		listView1.BackgroundImage = (Image)resources.GetObject("listView1.BackgroundImage");
		listView1.LargeImageList = imageList1;
		listView1.Location = new Point(10, 30);
		listView1.Margin = new Padding(4, 3, 4, 3);
		listView1.MultiSelect = false;
		listView1.Name = "listView1";
		listView1.Scrollable = false;
		listView1.Size = new Size(230, 115);
		listView1.SmallImageList = imageList1;
		listView1.TabIndex = 0;
		listView1.TileSize = new Size(228, 52);
		listView1.UseCompatibleStateImageBehavior = false;
		listView1.View = View.Tile;
		listView1.ItemDrag += ListView_ItemDrag;
		listView1.ItemSelectionChanged += ListView_ItemSelectionChanged;
		listView1.DragDrop += ListView_DragDrop;
		listView1.DragEnter += ListView_DragEnter;
		// 
		// imageList1
		// 
		imageList1.ColorDepth = ColorDepth.Depth32Bit;
		imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		imageList1.TransparentColor = Color.Transparent;
		imageList1.Images.SetKeyName(0, "unknownfile");
		// 
		// listView2
		// 
		listView2.AllowDrop = true;
		listView2.LargeImageList = imageList1;
		listView2.Location = new Point(250, 30);
		listView2.Margin = new Padding(4, 3, 4, 3);
		listView2.MultiSelect = false;
		listView2.Name = "listView2";
		listView2.Scrollable = false;
		listView2.Size = new Size(230, 115);
		listView2.SmallImageList = imageList1;
		listView2.TabIndex = 10;
		listView2.TileSize = new Size(228, 52);
		listView2.UseCompatibleStateImageBehavior = false;
		listView2.View = View.Tile;
		listView2.ItemDrag += ListView_ItemDrag;
		listView2.ItemSelectionChanged += ListView_ItemSelectionChanged;
		listView2.DragDrop += ListView_DragDrop;
		listView2.DragEnter += ListView_DragEnter;
		// 
		// checkBox2
		// 
		checkBox2.AutoSize = true;
		checkBox2.Checked = true;
		checkBox2.CheckState = CheckState.Checked;
		checkBox2.Location = new Point(200, 152);
		checkBox2.Margin = new Padding(4, 3, 4, 3);
		checkBox2.Name = "checkBox2";
		checkBox2.Size = new Size(199, 19);
		checkBox2.TabIndex = 11;
		checkBox2.Text = "Trim Excess Raw Save Data (GBA)";
		toolTip1.SetToolTip(checkBox2, resources.GetString("checkBox2.ToolTip"));
		checkBox2.UseVisualStyleBackColor = true;
		// 
		// toolTip1
		// 
		toolTip1.AutomaticDelay = 200;
		toolTip1.AutoPopDelay = 32000;
		toolTip1.InitialDelay = 200;
		toolTip1.ReshowDelay = 40;
		// 
		// MainForm
		// 
		AllowDrop = true;
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(491, 199);
		Controls.Add(checkBox2);
		Controls.Add(listView2);
		Controls.Add(listView1);
		Controls.Add(checkBox1);
		Controls.Add(linkLabel1);
		Controls.Add(statusStrip1);
		Controls.Add(label1);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		Icon = (Icon)resources.GetObject("$this.Icon");
		Margin = new Padding(4, 3, 4, 3);
		MaximizeBox = false;
		Name = "MainForm";
		Text = "RetroN5 File Converter";
		statusStrip1.ResumeLayout(false);
		statusStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	private readonly Image _hyperkinbg;
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
			(_file1Name, _file2Name) = (_file2Name, _file1Name);
			(_file1Buffer, _file2Buffer) = (_file2Buffer, _file1Buffer);
			(listView1.BackgroundImage, listView2.BackgroundImage) = (listView2.BackgroundImage, listView1.BackgroundImage);
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

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		MessageBox.Show("RetroN5 File Converter\nVersion 3.1 Drag & Drop\nSpecial Thanks to Wolf", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}
}