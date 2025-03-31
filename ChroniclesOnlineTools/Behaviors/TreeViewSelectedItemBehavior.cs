using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ChroniclesOnlineTools.Behaviors
{
    public class TreeViewSelectedItemBehavior
    {
        // Declare our attached property, it needs to be a DependencyProperty so
        // we can bind to it from out ViewMode.
        public static readonly DependencyProperty TreeViewSelectedItemProperty =
            DependencyProperty.RegisterAttached(
            "TreeViewSelectedItem",
            typeof(object),
            typeof(TreeViewSelectedItemBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                new PropertyChangedCallback(TreeViewSelectedItemChanged)));

        // We need a Get method for our new property
        public static object GetTreeViewSelectedItem(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(TreeViewSelectedItemProperty);
        }

        // As well as a Set method for our new property
        public static void SetTreeViewSelectedItem(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(TreeViewSelectedItemProperty, value);
        }

        // This is the handler for when our new property's value changes
        // When our property is set to a non-null value we need to add an event handler
        // for the TreeView's SelectedItemChanged event
        private static void TreeViewSelectedItemChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            TreeView tv = (TreeView)dependencyObject;

            if (e.NewValue == null && e.OldValue != null)
            {
                tv.SelectedItemChanged -= tv_SelectedItemChanged;
            }
            else if (e.NewValue != null && e.OldValue == null)
            {
                tv.SelectedItemChanged += tv_SelectedItemChanged;
            }
        }

        // When TreeView.SelectedItemChanged fires, set our new property to the value
        static void tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetTreeViewSelectedItem((DependencyObject)sender, e.NewValue);
        }
    }
}
