using DevExpress.ExpressApp;

namespace XAFCommunity.Win {
    public static class ReadOnlyTabStopHelper {
        internal static Schema GetReadOnlyTabStopSchema() {
            const string schema =
                @"<Element Name=""Application"">
	                <Element Name=""Views"">
                        <Attribute Name=""TabOverReadOnlyEditors"" Choice=""True,False"" IsNewNode=""True""/>
	                </Element>
                </Element>";

            return new Schema(new DictionaryXmlReader().ReadFromString(schema));
        }
    }
}