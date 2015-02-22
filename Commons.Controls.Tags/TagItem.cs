using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Commons.Controls.Tags
{
    [TemplatePart(Name=PART_deleteButton, Type=typeof(Button))]
    public partial class TagItem : ContentControl
    {

        public const string PART_deleteButton = "deleteButton";

        public TagItem()
        {
            DefaultStyleKey = typeof(TagItem);

            this.Loaded += TagItem_Loaded;
            this.Unloaded += TagItem_Unloaded;
        }

        public event EventHandler<RoutedEventArgs> OnDelete;

        #region Interaction
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SubscribeEvents();
        }

        void TagItem_Unloaded(object sender, RoutedEventArgs e)
        {
            //UnsubscribeEvents();
        }

        void TagItem_Loaded(object sender, RoutedEventArgs e)
        {
            //SubscribeEvents();
        }

        private void SubscribeEvents()
        {

            var layoutRoot = GetTemplateChild("LayoutRoot") as Grid;
            layoutRoot.MouseEnter += layoutRoot_MouseEnter;
            layoutRoot.MouseLeave += layoutRoot_MouseLeave;

            var deleteButton = GetTemplateChild("deleteButton") as Button;
            deleteButton.Click += deleteButton_Click;
            
        }

        void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnDelete != null)
            {
                OnDelete(this, e);
            }
        }

        private void UnsubscribeEvents()
        {

            var layoutRoot = GetTemplateChild("LayoutRoot") as Grid;
            layoutRoot.MouseEnter -= layoutRoot_MouseEnter;
            layoutRoot.MouseLeave -= layoutRoot_MouseLeave;
        }

        void layoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "OnMouseOut", true);
        }

        void layoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "OnMouseOver", true);
        }

        #endregion
        
 
    }
}