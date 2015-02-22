using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Commons.Controls.Tags.Test
{
    public partial class TagPanelTests : UserControl
    {
        private ObservableCollection<string> _myItemsSource = new ObservableCollection<string>(new[] {
                    "Delete all tags",
                    "Scala",
                    "Python"
                });
        
        public TagPanelTests()
        {
            InitializeComponent();
        }

        public ObservableCollection<string> MyItemsSource
        {
            get
            {
                return _myItemsSource;
            }
        }


        private void Tag_Delete(object sender, RoutedEventArgs e)
        {
            var content = (string) (sender as TagItem).GetBindingExpression(TagItem.ContentProperty).DataItem;
            if (_myItemsSource.Contains(content))
            {
                _myItemsSource.Remove(content);
            }
        }
    }
}
