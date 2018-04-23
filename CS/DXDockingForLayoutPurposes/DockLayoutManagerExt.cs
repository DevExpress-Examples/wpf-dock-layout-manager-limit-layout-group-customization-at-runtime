using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Docking.Platform;

namespace DXDockingForLayoutPurposes {
    //S171364
    class DockLayoutManagerExt : DockLayoutManager {

        IView layoutView;
        IView customizationView;

        protected override IView CreateLayoutView(IUIElement element) {
            layoutView = new CustomLayoutView(element);
            return layoutView;
        }
        protected override IView CreateCustomizationView(IUIElement element) {
            customizationView = new MyCustomizationView(element);
            return customizationView;
        }
    }

    public class MyCustomizationView : CustomizationView {
        public MyCustomizationView(IUIElement viewUIElement)
            : base(viewUIElement) {
        }

        protected override void RegisterListeners() {
            base.RegisterUIServiceListener(new LayoutViewSelectionListener());
            base.RegisterUIServiceListener(new CustomizationViewUIInteractionListener());
            base.RegisterUIServiceListener(new MyCustomizationDraggingListener());//my version
        }
    }

    public class CustomLayoutView : LayoutView {
        public CustomLayoutView(IUIElement viewUIElement)
            : base(viewUIElement) {
        }

        protected override void RegisterListeners() {
            RegisterUIServiceListener(new LayoutViewRegularDragListener());
            RegisterUIServiceListener(new LayoutViewFloatingDragListener());
            RegisterUIServiceListener(new LayoutViewReorderingListener());
            RegisterUIServiceListener(new MyDragListener());// my version
            RegisterUIServiceListener(new LayoutViewNonClientDraggingListener());
            RegisterUIServiceListener(new LayoutViewUIInteractionListener());
            RegisterUIServiceListener(new LayoutViewSelectionListener());
            RegisterUIServiceListener(new LayoutViewActionListener());
        }
    }

    public class MyDragListener : LayoutViewClientDraggingListener {
        public override bool CanDrop(Point point, ILayoutElement element) {

            DockLayoutElementDragInfo dockLayoutElementDragInfo = new DockLayoutElementDragInfo(this.View, point, element);
            BaseLayoutItem draggedItem = dockLayoutElementDragInfo.Item;
            BaseLayoutItem target = dockLayoutElementDragInfo.Target;
            if (!DragHelper.IsItemInGroup(draggedItem) && !DragHelper.IsTargetInGroup(target)) {
                return base.CanDrop(point, element);
            }
            bool result = DragHelper.AllowMoving(draggedItem, target);
            return result;

        }
    }

    public class MyCustomizationDraggingListener : CustomizationViewClientDraggingListener {
        public override bool CanDrop(Point point, ILayoutElement element) {
            DockLayoutElementDragInfo dockLayoutElementDragInfo = new DockLayoutElementDragInfo(base.View, point, element);
            var draggedItem = dockLayoutElementDragInfo.Item;
            var target = dockLayoutElementDragInfo.Target;
            if ((dockLayoutElementDragInfo.DropTarget is HiddenItemElement || dockLayoutElementDragInfo.DropTarget is HiddenItemsListElement) && dockLayoutElementDragInfo.Item.AllowHide) {
                LayoutItemType itemType = dockLayoutElementDragInfo.Item.ItemType;
                return (LayoutItemsHelper.IsLayoutItem(dockLayoutElementDragInfo.Item) || itemType == LayoutItemType.Group);
            }
            if (!DragHelper.IsItemInGroup(draggedItem) && !DragHelper.IsTargetInGroup(target)) {
                return base.CanDrop(point, element);
            }
            return DragHelper.AllowMoving(draggedItem, target);
        }
    }
}
