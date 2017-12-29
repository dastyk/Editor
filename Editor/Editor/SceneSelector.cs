using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Properties;
namespace Editor
{
    public partial class SceneSelector : Form
    {
        BinaryLoader_Wrapper bl;
        public SceneSelector(BinaryLoader_Wrapper bl)
        {
            InitializeComponent();
            this.bl = bl;

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.SceneSelectorSize;
        }
        
    }
}
