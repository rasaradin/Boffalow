﻿using InstagramApiSharp.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Pixo
{
    class UnFollower
    {
        public async void All(int max)
        {
            for (int i = 0; i < max; i++)
            {
                //press Stop:
                if (History.isStopUn)
                {
                    Stop();
                    return;
                }


                Random random = new Random();
                var result = await UserWorkation.InstaApi.UserProcessor.UnFollowUserAsync(FollowerAnalyser.Followings[i].Pk);
                if (result.Succeeded)
                {
                    var x = FollowerAnalyser.Followings[0];
                    FollowerAnalyser.Followers.RemoveAll(a => a.Pk == x.Pk);
                    Debug.WriteLine(x.UserName);

                    FollowerAnalyser.Diffrensial();

                    HomePage.DiffrentNumber.Text = FollowerAnalyser.Diffrent.Count().ToString();
                    HomePage.FollowingNumber.Text = FollowerAnalyser.Followings.Count().ToString();
                    UnFollowPage.tbMax.Text = FollowerAnalyser.Followings.Count().ToString();
                    UnFollowPage.tbNumber.PlaceholderText = FollowerAnalyser.Followings.Count().ToString();
                    UnFollowPage.lv.ItemsSource = FollowerAnalyser.Followings;
                }
                else
                {
                    Debug.WriteLine(result.Info.Message);
                    Debug.WriteLine(result.Info.ResponseType);

                    //Notinfer.Show(result.Info.Message, 60000);
                    i++;
                    if (result.Info.ResponseType == ResponseType.ChallengeRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.CheckPointRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.LoginRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.RequestsLimit)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.SentryBlock)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.WrongRequest)
                    {

                    }
                }

                int delay = 30000 + random.Next(4500);
                Debug.WriteLine("Delay = " + delay);
                int Ok = 0;
                while (Ok <= delay)
                {
                    await Task.Delay(100);
                    Ok += 100;
                    if (History.isStopUn)
                    {
                        Stop();
                        return;
                    }
                }


            }
        }

        public async void NotFollowingMe(int max)
        {
            int B = 0;

           // Parallel.For(0, max, GO);
            for (int i = 0; i < max; i++)
            {
                //press Stop:
                if (History.isStopUn)
                {
                    Stop();
                    return;
                }


                Random random = new Random();
                var result = await UserWorkation.InstaApi.UserProcessor.UnFollowUserAsync(FollowerAnalyser.Diffrent[0].Pk);
                if (result.Succeeded)
                {
                    var x = FollowerAnalyser.Diffrent[0];
                    FollowerAnalyser.Diffrent.RemoveAll(a => a.Pk == x.Pk);
                    FollowerAnalyser.Followings.RemoveAll(a => a.Pk == x.Pk);
                    Debug.WriteLine(x.UserName);

                    FollowerAnalyser.Diffrensial();

                    HomePage.DiffrentNumber.Text = FollowerAnalyser.Diffrent.Count().ToString();
                    HomePage.FollowingNumber.Text = FollowerAnalyser.Followings.Count().ToString();
                    UnFollowPage.tbMax.Text = FollowerAnalyser.Diffrent.Count().ToString();
                    UnFollowPage.tbNumber.PlaceholderText = FollowerAnalyser.Diffrent.Count().ToString();
                    UnFollowPage.lv.ItemsSource = FollowerAnalyser.Diffrent;
                    UnFollowPage.notifers.Show(x.UserName + "is Unfollowed.", 1000);
                }
                else
                {
                    Debug.WriteLine(result.Info.Message);
                    Debug.WriteLine(result.Info.ResponseType);

                    //Notinfer.Show(result.Info.Message, 60000);
                    i++;
                    if (result.Info.ResponseType == ResponseType.ChallengeRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.CheckPointRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.LoginRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.RequestsLimit)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.SentryBlock)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.WrongRequest)
                    {

                    }
                }
                B++;
                if (B == 50)
                {
                    int delay = 30000 + random.Next(4500);
                    Debug.WriteLine("Delay = " + delay);
                    int Ok = 0;
                    while (Ok <= delay)
                    {
                        await Task.Delay(100);
                        Ok += 100;
                        if (History.isStopUn)
                        {
                            Stop();
                            return;
                        }
                    }
                    B = 0;
                }
            }
            Stop();
            return;
        }

        private async void GO(int arg1, ParallelLoopState arg2)
        {
            //press Stop:
            if (History.isStopUn)
            {
                Stop();
                return;
            }


            Random random = new Random();
            var result = await UserWorkation.InstaApi.UserProcessor.UnFollowUserAsync(FollowerAnalyser.Diffrent[0].Pk);
            if (result.Succeeded)
            {
                var x = FollowerAnalyser.Diffrent[0];
                FollowerAnalyser.Diffrent.RemoveAll(a => a.Pk == x.Pk);
                FollowerAnalyser.Followings.RemoveAll(a => a.Pk == x.Pk);
                Debug.WriteLine(x.UserName);

                FollowerAnalyser.Diffrensial();
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
() =>
{
    HomePage.DiffrentNumber.Text = FollowerAnalyser.Diffrent.Count().ToString();
    HomePage.FollowingNumber.Text = FollowerAnalyser.Followings.Count().ToString();
    UnFollowPage.tbMax.Text = FollowerAnalyser.Diffrent.Count().ToString();
    UnFollowPage.tbNumber.PlaceholderText = FollowerAnalyser.Diffrent.Count().ToString();
    UnFollowPage.lv.ItemsSource = FollowerAnalyser.Diffrent;
}
);

            }
            else
            {
                Debug.WriteLine(result.Info.Message);
                Debug.WriteLine(result.Info.ResponseType);

                //Notinfer.Show(result.Info.Message, 60000);
                if (result.Info.ResponseType == ResponseType.ChallengeRequired)
                {

                }
                else if (result.Info.ResponseType == ResponseType.CheckPointRequired)
                {

                }
                else if (result.Info.ResponseType == ResponseType.LoginRequired)
                {

                }
                else if (result.Info.ResponseType == ResponseType.RequestsLimit)
                {

                }
                else if (result.Info.ResponseType == ResponseType.SentryBlock)
                {

                }
                else if (result.Info.ResponseType == ResponseType.WrongRequest)
                {

                }
            }

                int delay = 30000 + random.Next(4500);
                Debug.WriteLine("Delay = " + delay);
                int Ok = 0;
                while (Ok <= delay)
                {
                    await Task.Delay(100);
                    Ok += 100;
                    if (History.isStopUn)
                    {
                        Stop();
                        return;
                    }
                }
            }

        public async void FollowerThatFollowingMe(int max)
        {
            for (int i = 0; i < max; i++)
            {
                //press Stop:
                if (History.isStopUn)
                {
                    Stop();
                    return;
                }


                Random random = new Random();
                var result = await UserWorkation.InstaApi.UserProcessor.UnFollowUserAsync(FollowerAnalyser.Equals[i].Pk);
                if (result.Succeeded)
                {
                    var x = FollowerAnalyser.Equals[0];
                    FollowerAnalyser.Followings.RemoveAll(a=> a.Pk == x.Pk);
                    //FollowerAnalyser.Followers.Remove(FollowerAnalyser.Equals[i]);
                    Debug.WriteLine(x.UserName);

                    //HomePage.DiffrentNumber.Text = FollowerAnalyser.Diffrent.Count().ToString();
                    HomePage.FollowingNumber.Text = FollowerAnalyser.Followings.Count().ToString();
                    UnFollowPage.tbNumber.Text = FollowerAnalyser.Diffrent.Count().ToString();
                    UnFollowPage.tbNumber.PlaceholderText = FollowerAnalyser.Diffrent.Count().ToString();
                }
                else
                {
                    Debug.WriteLine(result.Info.Message);
                    Debug.WriteLine(result.Info.ResponseType);

                   // Notinfer.Show(result.Info.Message, 60000);
                    i++;
                    if (result.Info.ResponseType == ResponseType.ChallengeRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.CheckPointRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.LoginRequired)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.RequestsLimit)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.SentryBlock)
                    {

                    }
                    else if (result.Info.ResponseType == ResponseType.WrongRequest)
                    {

                    }
                }

                int delay = 30000 + random.Next(4500);
                Debug.WriteLine("Delay = " + delay);
                int Ok = 0;
                while (Ok <= delay)
                {
                    await Task.Delay(100);
                    Ok += 100;
                    if (History.isStopUn)
                    {
                        Stop();
                        return;
                    }
                }


            }
        }

        private void Stop()
        {
            History.isStopUn = true;
            UnFollowPage.btnUnf.Content = "Process";
            UnFollowPage.tbNumber.IsEnabled = true;
            UnFollowPage.cbMet.IsEnabled = true;
            UnFollowPage.btnUnf.IsEnabled = true;
            HomePage.par.IsActive = false;
        }
    }
}
