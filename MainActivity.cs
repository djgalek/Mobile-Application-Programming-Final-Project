using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.IO;
using SQLite;

namespace FinalProject
{
    [Activity(Label = "FinalProject", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //path to database file
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbFinal.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button enterButton = FindViewById<Button>(Resource.Id.SubmitButton);
            enterButton.Click += delegate 
            {

                //setup the db connection
                var db = new SQLiteConnection(dbPath);

                //setup a table
                db.CreateTable<UserData>();

                EditText NameBox = FindViewById<EditText>(Resource.Id.NameBox);
                string name = NameBox.Text;

                EditText MoneyBox = FindViewById<EditText>(Resource.Id.MoneyBox);
                string money = MoneyBox.Text;

                //create new user data
                UserData myUserData = new UserData(name, money);

                //store data into table
                db.Insert(myUserData);

                //clear boxes
                NameBox.Text = "";
                MoneyBox.Text = "";

            };

            Button viewButton = FindViewById<Button>(Resource.Id.ViewButton);
            enterButton.Click += delegate
            {
                //var intent = new Intent(this, typeof(UserDisplay));
                //StartActivity(intent);

                TextView displayText = FindViewById<Button>(Resource.Id.displayText);

                //setup the db connection
                var db = new SQLiteConnection(dbPath);

                //connect to table
                var table = db.Table<UserData>();


                foreach(var item in table)
                {
                    UserData myUserData = new UserData(item.Name, item.Money);
                    displayText.Text += myUserData + "\n";
                } 
            };
        }
    }
}

