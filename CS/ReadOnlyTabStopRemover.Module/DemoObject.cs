using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.ConditionalEditorState;

namespace ReadOnlyTabStopRemover.Module {
    [DefaultClassOptions]
    [EditorStateRule("DemoObject.SimpleProperty.Disabled", "SimpleProperty", EditorState.Disabled, "DisableSimpleProperty", DevExpress.ExpressApp.ViewType.DetailView, "Disables the SimpleProperty only if the DisableSimpleProperty value is True")]
    public class DemoObject : BaseObject {
        public DemoObject(Session session) : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        private bool _DisableSimpleProperty;
        [ImmediatePostData]
        public bool DisableSimpleProperty {
            get { return _DisableSimpleProperty; }
            set { SetPropertyValue("DisableSimpleProperty", ref _DisableSimpleProperty, value); }
        }
        private string _SimpleProperty;
        public string SimpleProperty {
            get { return _SimpleProperty; }
            set { SetPropertyValue("SimpleProperty", ref _SimpleProperty, value); }
        }
        private string _ReadOnlyProperty = "Always readonly";
        public string ReadOnlyProperty {
            get { return _ReadOnlyProperty; }
        }
    }
}
