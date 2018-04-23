using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace ReadOnlyTabStopRemover.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class ReadOnlyTabStopRemoverWindowsFormsModule : ModuleBase
    {
        public ReadOnlyTabStopRemoverWindowsFormsModule()
        {
            InitializeComponent();
        }

        public override Schema GetSchema()
        {
            return XAFCommunity.Win.ReadOnlyTabStopHelper.GetReadOnlyTabStopSchema();
        }
    }
}
