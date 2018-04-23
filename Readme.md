# How to skip readonly editors when moving through editors, using the Tab key


<p><strong>===============================================================</strong><strong><br />
</strong><strong> </strong><strong>This example is obsolete with version 13.2. Refer to the </strong><a href="https://www.devexpress.com/Support/Center/p/S30850">Usability.Win - Do not tab stop on disabled/readonly editors and columns</a><strong> ticket for more details.</strong><strong><br />
===============================================================</strong></p><p><u></u></p><p><u></u></p>


<h3>Description</h3>

<p>This version uses the ConditionalEditorState module to disable editors conditionally. The CustomEditorStateCustomization event is also reused to perform addition customizations (set the TabStop property) to the editors.<br />
See also the <a data-ticket="S33618">ConditionalEditorState - provide an event to allow additional user customization of target editors</a> suggestion for more information.</p>

<br/>


