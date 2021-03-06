﻿using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using Prism.Windows.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pixo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ForgetPhonePage : SessionStateAwarePage
    {
        public ForgetPhonePage()
        {
            this.InitializeComponent();
        }

        private void tbForget_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ForgetPage));
        }

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string phonenumber = tbPhone.Text.Replace("+", "");
            var isNumeric = long.TryParse(phonenumber, out long n);
            if (isNumeric)
            {
                tbPhone.IsEnabled = false;
                btnGo.IsEnabled = false;

                var userSession = new UserSessionData
                {
                    UserName = "dsfsdf",
                    Password = "dsfsdfdsfdsf"
                };

                var Api = InstaApiBuilder.CreateBuilder()
                    .SetUser(userSession)
                    .Build();


                var result = await Api.SendRecoveryByPhoneAsync("+" + phonenumber);
                if (result.Succeeded)
                {
                    Statico.Notifer.Show(result.Value.Body, Statico.NotifDelay);
                    Frame.Navigate(typeof(LoginPage));
                }
                else
                {
                    Statico.Notifer.Show(result.Info.Message, Statico.NotifDelay);
                }
            }
            else
            {
                Statico.Notifer.Show("Please check your Phonenumber.", Statico.NotifDelay);
            }

            tbPhone.IsEnabled = true;
            btnGo.IsEnabled = true;
        }
    }
}
