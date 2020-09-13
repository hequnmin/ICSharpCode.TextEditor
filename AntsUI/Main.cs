using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace Example
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Expression");
            txtEditor.Encoding = System.Text.Encoding.Default;
        }
    }
}
