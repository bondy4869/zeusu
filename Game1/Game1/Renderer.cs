using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Red
{
    class Renderer
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        private Dictionary<string, Texture2D> textures = new
            Dictionary<string, Texture2D>();

        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
        public void LoadContent(string assetName, string filepath = "./")
        {
            if (textures.ContainsKey(assetName))
            {
#if DEBUG
                Console.WriteLine(assetName + "はすでに読み込まれています。\n" +
                    "プログラムを確認してください。");
#endif
                return;
            }
            textures.Add(assetName, contentManager.Load<Texture2D>(filepath +
                assetName));
        }
        public void Unload()
        {
            textures.Clear();
        }

        public void Begin()
        {
           spriteBatch.Begin();
        }
    public void End()
    {
        spriteBatch.End();
    }
    public void DrawTexture(string assetName, Vector2 position, float
        alpha = 1.0f)
    {
        Debug.Assert(
            textures.ContainsKey(assetName),
            "描画時にアセット名の指定を間違えたか、画像の読み込み自体出来ていません");

            spriteBatch.Draw(textures[assetName], position, Color.White *
                alpha);
    }

        public void DrawTexture(string assetName, Vector2 position,
            Rectangle rect, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体出来ていません。");

            spriteBatch.Draw(
                textures[assetName],
                position,
                rect,

                Color. White * alpha);
        }
    }
}
