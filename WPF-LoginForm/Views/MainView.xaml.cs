using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Microsoft.Win32;
using System.IO;
using Path = System.IO.Path;
using System.Data.SqlClient;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private string connectionString;

        public MainView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(Object sender, RoutedEventArgs e) 
        { 
            if(this.WindowState== WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private bool isContextMenuOpen = false;

        private void btnContextMenu_Click(object sender, RoutedEventArgs e)
        {
            //isContextMenuOpen = !isContextMenuOpen; // inverser l'état du Popup
            //popupContextMenu.IsOpen = isContextMenuOpen; // afficher ou masquer le Popup en fonction de l'état
        }
        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {

            // Créer une instance de la fenêtre de connexion
            LoginView loginView = new LoginView();

            // Afficher la fenêtre de connexion
            loginView.Show();
            Window.GetWindow(this).Close();
        }


    }
}
