using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BitmapFontExtension.FontSource;

namespace TestBitmapFont
{
    public partial class GamePage : PhoneApplicationPage
    {
        ContentManager contentManager;
        GameTimer timer;
        SpriteBatch spriteBatch;

        BitmapFont font, font2, font3, font4, font5;
        public GamePage()
        {
            InitializeComponent();

            // Get the content manager from the application
            contentManager = (Application.Current as App).Content;

            // Create a timer for this page
            timer = new GameTimer();
            timer.UpdateInterval = TimeSpan.FromTicks(333333);
            timer.Update += OnUpdate;
            timer.Draw += OnDraw;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the sharing mode of the graphics device to turn on XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(true);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);

            // TODO: use this.content to load your game content here

            font = new BitmapFont(App.GetResourceStream(new Uri("Fonts/fontbxhcu.txt", UriKind.Relative)).Stream, contentManager.Load<Texture2D>("Fonts/fontbxhcu"));
            font3 = new BitmapFont(App.GetResourceStream(new Uri("Fonts/font.txt", UriKind.Relative)).Stream, contentManager.Load<Texture2D>("Fonts/font"));
            font2 = font.Clone();
            font4 = font3.Clone();
            font5 = font4.Clone();

            font.setText("012346789@#$", BitmapFont.HA.CENTER, new Vector2(100, 100));
            font2.setText("BITMAPFONT BY WITHLOVEI", BitmapFont.HA.RIGHT,0.75f, new Vector2(480, 200));
            font3.setText("Day la font chuan scale 50% roatate Math.PI/18", BitmapFont.HA.CENTER, 0.5f, (float)Math.PI/18, new Vector2(240, 300));
            font4.setText("Day la font chuan scale 75% and rotate", BitmapFont.HA.CENTER, 0.75f, new Vector2(240,350));            
            font5.setText("Non scale and rotate", BitmapFont.HA.CENTER, new Vector2(240, 400));
            // Start the timer
            timer.Start();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Set the sharing mode of the graphics device to turn off XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);

            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Allows the page to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        private void OnUpdate(object sender, GameTimerEventArgs e)
        {
            // TODO: Add your update logic here
        }

        /// <summary>
        /// Allows the page to draw itself.
        /// </summary>
        private void OnDraw(object sender, GameTimerEventArgs e)
        {
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            font.Draw(spriteBatch);
            font2.Draw(spriteBatch);
            font3.Draw(spriteBatch);
            font4.Draw(spriteBatch);
            font5.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here
        }
    }
}