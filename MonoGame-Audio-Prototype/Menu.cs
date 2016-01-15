using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_UI_Touch_Prototype
{
    class Menu
    {
        private Texture2D GUITexture;
        private Rectangle GUIRect;

        private string assetname;

        public delegate void ElementClicked(string element);
        public event ElementClicked ClickEvent;

        public Menu(string assetname)
        {
            this.assetname = assetname;
        }

        public void LoadContent(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(assetname);
            GUIRect = new Rectangle(0, 0, GUITexture.Width, GUITexture.Height);
        }

        public void Update()
        {
            /// Will Be replaced with touch controls for game, using mouse for testing purposes
            if(GUIRect.Contains(new Point(Mouse.GetState().X,Mouse.GetState().Y))&& Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                ClickEvent(assetname);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GUITexture, GUIRect, Color.White);
        }

        public void CentreElement(int width, int height)
        {
            GUIRect = new Rectangle((width / 2) - (this.GUITexture.Width / 2), (height / 2) - (this.GUITexture.Height / 2), this.GUITexture.Width, this.GUITexture.Height);
        }
    }
}
