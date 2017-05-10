using Android.App;
using Android.Widget;
using Android.OS;
using MaratonaXamari.Shared;
using System;
using System.Linq;

namespace MaratonaXamarin.Android
{
    [Activity(Label = "MaratonaXamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            var button = this.FindViewById<Button>(Resource.Id.btnCarregar);
            var listView = this.FindViewById<ListView>(Resource.Id.lvwItens);

            button.Click += async (sender, e) =>
            {
                var api = new UserApi();
                var users = await api.ListAsync(new Developer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Neuber",
                    Email = "bnksystem@outlook.com",
                    Estado = "MG",
                    Cidade = "BETIM"
                });

                listView.Adapter = new ArrayAdapter(this,
                                                    Android.Resource.Layout.Main,
                                                         users.OrderBy(y => y.Name).Select(x => $"{x.Id} {x.Name}").ToArray());
            };
        }
    }
}

