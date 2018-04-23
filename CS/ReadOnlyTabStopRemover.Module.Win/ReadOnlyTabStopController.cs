using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.ExpressApp.Editors;

namespace ReadOnlyTabStopRemover.Module.Win {
    public class TestCustomEditorStateCustomization : ViewController<DetailView> {
        private IList<PropertyEditor> GetEditors() {
            return View.GetItems<PropertyEditor>();
        }
        protected override void OnActivated() {
            base.OnActivated();
            foreach (PropertyEditor editor in GetEditors()) {
                editor.AllowEditChanged += OnCustomizeTabStop;
                editor.ControlCreated += OnCustomizeTabStop;
            }
        }
        private void OnCustomizeTabStop(object sender, System.EventArgs e) {
            CustomizeTabStop(((PropertyEditor)sender));
        }
        protected override void OnDeactivated() {
            foreach (PropertyEditor editor in GetEditors()) {
                editor.AllowEditChanged -= OnCustomizeTabStop;
                editor.ControlCreated -= OnCustomizeTabStop;
            }
            base.OnDeactivated();
        }
        private void CustomizeTabStop(PropertyEditor editor) {
            Control ctrl = editor.Control as Control;
            bool disabled = ctrl != null && !editor.AllowEdit;
            CustomizeTabStopCore(ctrl, disabled ? ShouldTabOverReadOnlyEditors() : true);
        }
        private void CustomizeTabStopCore(Control control, bool shouldTabStop) {
            if (control == null) return;
            //The TextEdit control overrides the TabStop property, and so it should be explicitely set.
            TextEdit txtEditor = control as TextEdit;
            if (txtEditor != null)
                txtEditor.TabStop = shouldTabStop;
            else
                control.TabStop = shouldTabStop;
        }
        private bool ShouldTabOverReadOnlyEditors() {
            IModelOptionsEx modelOptionsExt = Application.Model.Options as IModelOptionsEx;
            return modelOptionsExt != null && modelOptionsExt.TabOverReadOnlyEditors;
        }
    }
}