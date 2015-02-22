using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var tagItemControl = new TagItem { Content = "Monranbah Wines" };
            TestPanel.Children.Add(tagItemControl);
            tagItemControl.OnDelete += (s, e) =>
            {
                EnqueueTestComplete();
            };
            
        }

        [TestMethod]
        public void CreateTagItemControls()
        {
            
        }

    }
}
