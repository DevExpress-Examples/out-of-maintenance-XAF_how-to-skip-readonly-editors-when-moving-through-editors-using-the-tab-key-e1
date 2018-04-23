using System;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;

namespace ReadOnlyTabStopRemover.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class ReadOnlyTabStopRemoverWindowsFormsModule : ModuleBase {
        public ReadOnlyTabStopRemoverWindowsFormsModule() {
            InitializeComponent();
        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelOptions, IModelOptionsEx>();
        }
    }
    public interface IModelOptionsEx : IModelNode {
        [DefaultValue(false)]
        [Category("Behavior")]
        bool TabOverReadOnlyEditors { get; set; }
    }
}
