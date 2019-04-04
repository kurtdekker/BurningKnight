﻿using BurningKnight.assets;
using BurningKnight.assets.items;
using BurningKnight.assets.lighting;
using BurningKnight.state;
using BurningKnight.util;
using Lens;
using Lens.game;
using Microsoft.Xna.Framework;

namespace BurningKnight {
	public class BK : Engine {
		public BK(int width, int height, bool fullscreen) : base(new LoadState(), $"Burning Knight: {Titles.Generate()}", width, height, fullscreen) {
			
		}

		protected override void Initialize() {
			base.Initialize();
			
			Controls.Bind();
			
			CommonAse.Load();
			Shaders.Load();
			Font.Load();
			Items.Load();
			Mods.Load();
		}

		protected override void UnloadContent() {
			Mods.Destroy();
			Items.Destroy();
			Lights.DestroySurface();
			
			base.UnloadContent();
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			Mods.Update((float) gameTime.ElapsedGameTime.TotalSeconds);
		}

		public override void RenderUi() {
			base.RenderUi();
			Mods.Render();
		}
	}
}