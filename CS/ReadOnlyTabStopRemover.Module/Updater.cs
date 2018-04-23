using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace ReadOnlyTabStopRemover.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            DemoObject obj = new DemoObject(Session);
            obj.Name = "DemoObject1";
            obj.DisableSimpleProperty = true;
            obj.Save();
        }
    }
}
