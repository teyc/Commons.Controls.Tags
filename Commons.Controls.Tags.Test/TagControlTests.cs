using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Commons.Controls.Tags.Test
{
    [TestClass]
    public class TagControlTests: SilverlightTest
    {
        [TestMethod]
        [Asynchronous]
        public void CreateTagItemControl()
        {
            var tagItemControl = new TagItem { Content = "Delete this tag" };
            TestPanel.Children.Add(tagItemControl);
            tagItemControl.OnDelete += (s, e) =>
            {
                EnqueueTestComplete();
            };
            
        }

        [TestMethod]
        [Asynchronous]
        public void CreateTagItemControls()
        {
            var panel = new TagPanelTests();
            TestPanel.Children.Add(panel);
            var items = (panel.FindName("TagsListBox") as ListBox).Items;
            EnqueueConditional(() =>
            {
                return items != null && items.Count > 0;
            });
            EnqueueConditional(() =>
            {
                return items !=null && items.Count == 0; 
            });
            EnqueueTestComplete();
        }

    }
}
