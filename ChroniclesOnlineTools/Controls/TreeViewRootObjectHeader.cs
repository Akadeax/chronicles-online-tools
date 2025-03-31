using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChroniclesOnlineTools.Controls
{
    public class TreeViewRootObjectHeader : TreeViewItem
    {
        public static readonly DependencyProperty AssociatedTypeProperty =
            DependencyProperty.Register(
                nameof(AssociatedType),
                typeof(Type),
                typeof(TreeViewRootObjectHeader),
                new PropertyMetadata()
            );

        public Type AssociatedType
        {
            get => (Type)GetValue(AssociatedTypeProperty);
            set => SetValue(AssociatedTypeProperty, value);
        }
    }
}
