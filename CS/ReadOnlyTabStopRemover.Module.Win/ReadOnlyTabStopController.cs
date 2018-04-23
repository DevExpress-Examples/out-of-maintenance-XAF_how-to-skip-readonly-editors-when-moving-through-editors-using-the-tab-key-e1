using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.ConditionalEditorState;
using DevExpress.ExpressApp.ConditionalEditorState.Win;

namespace ReadOnlyTabStopRemover.Module.Win {
    public class TestCustomEditorStateCustomization : ViewController<DetailView> {
        private EditorStateCustomizationDetailViewController detailViewCustomization;
        protected override void OnActivated() {
            base.OnActivated();
            detailViewCustomization = Frame.GetController<EditorStateCustomizationDetailViewController>();
            if (detailViewCustomization != null)
                detailViewCustomization.CustomEditorStateCustomization += detailViewCustomization_CustomEditorStateCustomization;
        }
        private void CustomizeTabStop(Control control, bool shouldTabStop) {
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
        private void detailViewCustomization_CustomEditorStateCustomization(object sender, CustomEditorStateCustomizationEventArgs e) {
            if (e.EditorState == EditorState.Disabled) {
                bool disabled = e.Active;
                PropertyEditor item = e.Item as PropertyEditor;
                if (item != null) {
                    //Customize tab stop for readonly editors affected by the ConditionalEditorState module.
                    CustomizeTabStop((Control)item.Control, disabled ? ShouldTabOverReadOnlyEditors() : !disabled);
                }
            }
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            foreach (PropertyEditor item in View.GetItems<PropertyEditor>()) {
                Control ctrl = (Control)item.Control;
                bool disabled = ctrl != null && !item.AllowEdit;
                //Customize tab stop for readonly editors unaffected by the ConditionalEditorState module.
                CustomizeTabStop(ctrl, disabled ? ShouldTabOverReadOnlyEditors() : true);
            }
        }
        protected override void OnDeactivating() {
            if (detailViewCustomization != null)
                detailViewCustomization.CustomEditorStateCustomization -= detailViewCustomization_CustomEditorStateCustomization;
            base.OnDeactivating();
        }
    }
}