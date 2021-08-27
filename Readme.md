<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593773/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1508)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ReadOnlyTabStopController.cs](./CS/ReadOnlyTabStopRemover.Module.Win/ReadOnlyTabStopController.cs) (VB: [ReadOnlyTabStopController.vb](./VB/ReadOnlyTabStopRemover.Module.Win/ReadOnlyTabStopController.vb))
* [WinModule.cs](./CS/ReadOnlyTabStopRemover.Module.Win/WinModule.cs) (VB: [WinModule.vb](./VB/ReadOnlyTabStopRemover.Module.Win/WinModule.vb))
* [DemoObject.cs](./CS/ReadOnlyTabStopRemover.Module/DemoObject.cs) (VB: [DemoObject.vb](./VB/ReadOnlyTabStopRemover.Module/DemoObject.vb))
<!-- default file list end -->
# How to skip readonly editors when moving through editors, using the Tab key


<p><strong>===============================================================</strong><strong><br />
</strong><strong> </strong><strong>This example is obsolete with version 13.2. Refer to the </strong><a href="https://www.devexpress.com/Support/Center/p/S30850">Usability.Win - Do not tab stop on disabled/readonly editors and columns</a><strong> ticket for more details.</strong><strong><br />
===============================================================</strong></p><p><u></u></p><p><u></u></p>


<h3>Description</h3>

<p>This version uses the ConditionalEditorState module to disable editors conditionally. The CustomEditorStateCustomization event is also reused to perform addition customizations (set the TabStop property) to the editors.<br />
See also the <a data-ticket="S33618">ConditionalEditorState - provide an event to allow additional user customization of target editors</a> suggestion for more information.</p>

<br/>


