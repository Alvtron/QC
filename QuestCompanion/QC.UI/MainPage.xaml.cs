using QC.Model;
using QC.UI.DataSource;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Security.Authentication.Web;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QC.UI
{
    /// <summary>
    /// MainPage that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDatabaseRecords();
        }

        /// <summary>
        /// Refreshes the UI.
        /// </summary>
        private void RefreshDatabaseRecords()
        {
            /*try
            {
                var students = Students.Instance.GetStudents().Result;
                Input_SelectableStudents.ItemsSource = students;
                ListViewStudents.ItemsSource = students;
                var courses = Courses.Instance.GetCourses().Result;
                Input_SelectableCourses.ItemsSource = courses;
                ListViewCourses.ItemsSource = courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }

        /// <summary>
        /// Display a message to the user.
        /// This method may be called from any thread.
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="type"></param>
        public void NotifyUser(string strMessage)
        {
            // If called from the UI thread, then update immediately.
            // Otherwise, schedule a task on the UI thread to perform the update.
            if (Dispatcher.HasThreadAccess)
            {
                Debug.WriteLine(strMessage);
            }
            else
            {
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Debug.WriteLine(strMessage));
            }
        }

        private void OutputToken(String TokenUri)
        {
            GoogleReturnedToken.Text = TokenUri;
        }

        private async void Launch_Click(object sender, RoutedEventArgs e)
        {
            if (GoogleClientID.Text == "")
            {
                NotifyUser("Please enter an Client ID.");
            }
            else if (GoogleCallbackUrl.Text == "")
            {
                NotifyUser("Please enter an Callback URL.");
            }

            try
            {
                String GoogleURL = "https://accounts.google.com/o/oauth2/auth?client_id=" + Uri.EscapeDataString(GoogleClientID.Text) + "&redirect_uri=" + Uri.EscapeDataString(GoogleCallbackUrl.Text) + "&response_type=code&scope=" + Uri.EscapeDataString("http://picasaweb.google.com/data");

                Uri StartUri = new Uri(GoogleURL);
                // When using the desktop flow, the success code is displayed in the HTML title of this end URI
                Uri EndUri = new Uri("https://accounts.google.com/o/oauth2/approval");

                NotifyUser("Navigating to: " + GoogleURL);

                WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.UseTitle, StartUri, EndUri);
                if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    OutputToken(WebAuthenticationResult.ResponseData.ToString());
                }
                else if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    OutputToken("HTTP Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseErrorDetail.ToString());
                }
                else
                {
                    OutputToken("Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseStatus.ToString());
                }
            }
            catch (Exception Error)
            {
                NotifyUser(Error.Message);
            }
        }


        /// <summary>
        /// Displays the message dialog with one option.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        private async void DisplayMessageDialogWithOneOption(string title, string message)
        {
            ContentDialog messageDialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            try
            {
                await messageDialog.ShowAsync();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
