using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Docking;

namespace DXDockingForLayoutPurposes {
    public class Helper : DependencyObject {
        public static readonly DependencyProperty DisableCrossingGroupBoundariesProperty = DependencyProperty.RegisterAttached("DisableCrossingGroupBoundaries",
            typeof(bool), typeof(Helper), new PropertyMetadata(false, new PropertyChangedCallback(PropertyChanged)));

        public static bool GetDisableCrossingGroupBoundaries(DependencyObject d) {
            return (bool)d.GetValue(DisableCrossingGroupBoundariesProperty);
        }
        public static void SetDisableCrossingGroupBoundaries(DependencyObject d, bool value) {
            d.SetValue(DisableCrossingGroupBoundariesProperty, value);
        }

        public static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (!(d is LayoutGroup)) {
                throw new ArgumentException("Use this attached property only with LayoutGroup");
            }
        }

    }
    public static class DragHelper {
        public static bool AllowMoving(BaseLayoutItem item, BaseLayoutItem target) {
            bool result = false;
            if (target == null) {
                return false;
            }
            if (DragHelper.IsItemInGroup(item) && DragHelper.IsTargetInGroup(target) && (target is LayoutControlItem)) {
                return true;
            }
            BaseLayoutItem draggedItem = null, targetItem = null;
            if (item is LayoutControlItem) {
                draggedItem = item as LayoutControlItem;
                if (target is LayoutControlItem) {
                    targetItem = target as LayoutControlItem;
                    if (targetItem.Parent == draggedItem.Parent) {
                        result = true;
                    }
                }
                if (target is LayoutGroup) {
                    targetItem = target as LayoutGroup;
                    if (targetItem.Parent == draggedItem.Parent) {
                        result = true;
                    }
                }
            }
            if (item is LayoutGroup) {
                draggedItem = item as LayoutGroup;
                if (target is LayoutControlItem) {
                    targetItem = target as LayoutControlItem;
                    if (targetItem.Parent == draggedItem.Parent) {
                        result = true;
                    }
                }
                if (target is LayoutGroup) {
                    targetItem = target as LayoutGroup;
                    if (targetItem.Parent == draggedItem.Parent) {
                        result = true;
                    }
                }
            }
            return result;
        }


        public static bool IsItemInGroup(BaseLayoutItem item) {
            bool result = false;
            BaseLayoutItem currentItem = item;
            while (currentItem.Parent != null) {
                if (currentItem.Parent is LayoutGroup) {
                    LayoutGroup lgroup = currentItem.Parent as LayoutGroup;
                    bool allowCustomization = Helper.GetDisableCrossingGroupBoundaries(lgroup);
                    if (allowCustomization) {
                        result = true;
                        break;
                    }
                }
                currentItem = currentItem.Parent;
            }
            return result;
        }
        public static bool IsTargetInGroup(BaseLayoutItem target) {
            bool result = false;
            BaseLayoutItem currentTarget = target;
            while (currentTarget != null) {
                if (currentTarget is LayoutGroup) {
                    LayoutGroup lgroup = currentTarget as LayoutGroup;
                    bool allowCustomization = Helper.GetDisableCrossingGroupBoundaries(lgroup);
                    if (allowCustomization) {
                        result = true;
                        break;
                    }
                }
                currentTarget = currentTarget.Parent;
            }
            return result;
        }

    }




}

