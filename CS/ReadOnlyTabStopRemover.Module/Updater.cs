using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace ReadOnlyTabStopRemover.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            DemoObject obj1 = ObjectSpace.CreateObject<DemoObject>();
            obj1.Name = "DemoObject1";
            obj1.DisableSimpleProperty = true;
            obj1.Save();
            DemoObject obj2 = ObjectSpace.CreateObject<DemoObject>();
            obj2.Name = "DemoObject2";
            obj2.DisableSimpleProperty = false;
            obj2.Save();
        }
    }
}