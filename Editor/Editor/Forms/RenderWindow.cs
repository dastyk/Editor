using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Importer;
using Editor.Properties;
namespace Editor.Forms
{
    public partial class RenderWindow : Form
    {
        Utilities.EditorWrapper wrapper;
        public Renderer renderer;
        public RenderWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.wrapper = wrapper;
            renderer = new Renderer(panel1);
            retry:
            var err = renderer.Init();
            if(err.IsError())
            {
                var r = err.ShowError(MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, "Failed to init renderer");
                if (r == DialogResult.Cancel)
                    System.Environment.Exit(Convert.ToInt32(err.errornr));
                else if (r == DialogResult.Retry)
                    goto retry;
            }
            if (Settings.Default.RenderWindowSize != null)
                this.Size = Settings.Default.RenderWindowSize;
        }

        bool rendering = false;
        public void ToggleRender()
        {
            if (rendering)
            {

                rendering = false;
                renderer.Pause();
              
            }
            else
            {
                rendering = true;

                var err = renderer.UpdateSettings(panel1);
                if(err.IsError())
                {
                    err.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Error, "Failed to update renderer settings");
                    System.Environment.Exit(Convert.ToInt32(err.errornr));
                }
                err = renderer.Start();
                if (err.IsError())
                {
                    err.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Error, "Failed to start renderer");
                    System.Environment.Exit(Convert.ToInt32(err.errornr));
                }
            }

        }

        private void RenderWindow_SizeChanged(object sender, EventArgs e)
        {
            if (rendering)
            {

             
                renderer.Pause();
                var err = renderer.UpdateSettings(panel1);
                if (err.IsError())
                {
                    err.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Error, "Failed to update renderer settings");
                    System.Environment.Exit(Convert.ToInt32(err.errornr));
                }
                err = renderer.Start();
                if (err.IsError())
                {
                    err.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Error, "Failed to start renderer");
                    System.Environment.Exit(Convert.ToInt32(err.errornr));
                }

            }
        }
    }
}
