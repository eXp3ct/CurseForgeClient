using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.CustomControl
{
    public class ToolStripProgressBarUpdater : IProgress<double>
    {
        private readonly ToolStripProgressBar _progressBar;

        public ToolStripProgressBarUpdater(ToolStripProgressBar progressBar)
        {
            _progressBar = progressBar;
        }

        public void Report(double value)
        {
            _progressBar.Value = (int)(value * 100);
        }
    }
}
