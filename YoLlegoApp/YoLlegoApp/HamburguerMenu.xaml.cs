using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YoLlegoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HamburguerMenu : MasterDetailPage
	{
		public HamburguerMenu ()
		{
			InitializeComponent ();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new Principal());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page= new Principal(),MenuTitle="Inicio"},
                new Menu{ Page= new Principal(),MenuTitle="Mis Clases"}
            };
            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }
            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}