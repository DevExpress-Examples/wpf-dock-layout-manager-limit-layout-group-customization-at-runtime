# How to limit LayoutGroup customization at runtime


<p>We have prepared an example demonstrating how to limit LayoutGroup customization at runtime.</p><p>To provide this functionality, we created a DockLayoutManager class descendant and the attached DisableCrossingGroupBoundaries property. The DisableCrossingGroupBoundaries property can be attached only to the LayoutGroup.</p><p>In this case, the LayoutGroup with the property assigned to true allows any customization and prevents moving inner elements outside LayoutGroup boundaries. For the LayoutGroup without this property, the default logic is used for arranging elements.</p>

<br/>


