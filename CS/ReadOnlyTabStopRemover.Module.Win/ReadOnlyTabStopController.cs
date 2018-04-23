using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;

namespace XAFCommunity.Win {
    /// <summary>
    /// This controller sets UI control properties based upon class property attributes.
    /// The code will set the ReadOnly property based upon an attribute. Where controls
    /// are read-only the tabstop is set to false. If there is a TabStopAttribute override
    /// this is applied as well.
    /// </summary>
    public partial class ReadOnlyTabStopController : ViewController {
        #region Structor(s)

        public ReadOnlyTabStopController() {
            this.TargetViewType = ViewType.DetailView;
        }
        #endregion

        #region OnViewControlsCreated

        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            DictionaryNode viewNode = this.View.Info.Parent;
            if (viewNode != null) {
                DictionaryAttribute attr = viewNode.GetAttribute("TabOverReadOnlyEditors");
                bool readOnlyTabStopFunctionality;
                if (bool.TryParse(attr.Value, out readOnlyTabStopFunctionality)) {
                    if (readOnlyTabStopFunctionality) {
                        DetailView detailView = (DetailView)View;
                        CheckControlsVisibility(detailView);
                    }
                }
            }
        }
        #endregion

        #region CheckControlsVisibility

        private void CheckControlsVisibility(DetailView detailView) {
            Guard.ArgumentNotNull(detailView, "detailView");
            // Determine here if the class implements a particular interface. 
            foreach (DetailViewItem viewItem in detailView.Items) {
                Type objectType = viewItem.ObjectType;
                if (viewItem is DXPropertyEditor && viewItem.Info != null) {
                    string propertyName = viewItem.Info.KeyAttribute != null ? viewItem.Info.KeyAttribute.Value : "";
                    Boolean propertyIsReadOnly = viewItem.Info.IsReadOnly;
                    Boolean viewInfoIsModified = viewItem.Info.IsModified;
                    // Access the visualisation control.
                    BaseEdit editor = viewItem.Control as BaseEdit;

                    // ReadOnly Determination - this is only executed if the Dictionary has determined that a property should be
                    // read only.
                    if (!propertyIsReadOnly && !String.IsNullOrEmpty(propertyName)) {
                        Boolean revisedReadOnly = propertyIsReadOnly;

                        if (editor != null && propertyIsReadOnly != revisedReadOnly && !viewItem.Info.IsModified && !editor.Properties.ReadOnly) {
                            if (editor.Properties.ReadOnly != revisedReadOnly) {
                                if (!viewInfoIsModified)
                                    editor.Properties.ReadOnly = revisedReadOnly;
                            }
                        }
                    }
                    // Post processing
                    // if the control is read-only, then there is no need for the control to be a tabstop.
                    if (editor != null) {
                        Boolean controlHasTabStop = editor.TabStop;
                        Boolean revisedTabStop = controlHasTabStop && (!editor.Properties.ReadOnly);
                        if (revisedTabStop != controlHasTabStop) {
                            editor.TabStop = revisedTabStop;
                        }
                    }
                }
            }
        }
    }
        #endregion
}