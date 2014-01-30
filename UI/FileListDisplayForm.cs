using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UI
{
	public partial class FileListDisplayForm : Form
	{

		private List<FileInfo> files;
		private const string NO_FILES_FOUND = "[No Files to display]";

		public FileListDisplayForm(List<FileInfo> filesToDisplay)
		{
			InitializeComponent();
			files = filesToDisplay;
			Initialize();
		}

		private void Initialize()
		{
			if (files == null || files.Count == 0)
			{
				fileListRichText.Text = NO_FILES_FOUND;
			}
			else
			{
				StringBuilder fileDisplay = new StringBuilder();
				foreach (FileInfo fileInfo in files)
				{
					fileDisplay.AppendLine(fileInfo.FullName);
				}
				fileListRichText.Text = fileDisplay.ToString();
			}
		}
	}
}
