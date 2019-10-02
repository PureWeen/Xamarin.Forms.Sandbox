using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms.Sandbox
{
    public static class ViewHelpers
    {
        public static ContentPage CreateContentPage(View view)
        {
            var returnValue = new ContentPage() { Content = view };

            returnValue.On<iOS>().SetUseSafeArea(true);
            return returnValue;
        }


        public static ListView CreateListView(Func<View> template = null)
        {
            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            listView.RowHeight = 200;
            listView.ItemsSource = Enumerable.Range(0, 1000).ToList();

            if (template != null)
            {
                listView.ItemTemplate = new DataTemplate(() =>
                {
                    ViewCell cell = new ViewCell();
                    cell.View = template();
                    return cell;
                });
            }

            return listView;
        }

        public static ContentPage CreateListViewPage(Func<View> template)
        {
            return CreateContentPage(CreateListView(template));
        }


        public static StackLayout CreateStackLayout(IEnumerable<View> children, StackOrientation orientation = StackOrientation.Vertical)
        {
            var sl = new StackLayout() { Orientation = orientation };
            foreach (var child in children)
                sl.Children.Add(child);

            return sl;
        }

        public static ContentPage CreateStackLayoutPage(IEnumerable<View> children)
        {
            return CreateContentPage(CreateStackLayout(children));
        }

        public static Picker CreatePicker(System.Collections.IEnumerable data = null)
        {
            System.Collections.IList itemSource = null;

            if (data != null)
                itemSource = new List<object>(data.Cast<object>());
            else
                itemSource = new List<object> { "cat", "dog", "Rat", "mouse", "monkey" };

            return new Picker() { ItemsSource = itemSource };
        }
    }
}
