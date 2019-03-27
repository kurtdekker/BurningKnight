﻿using System;
using BurningKnight.entity.component;
using BurningKnight.entity.projectile;
using Lens.input;
using Lens.util.camera;
using Microsoft.Xna.Framework;

namespace BurningKnight.entity.item.use {
	public class SimpleShootUse : ShootUse {
		public SimpleShootUse(string slice, float speed, float range = 96) : base((entity, item) => {
			var angle = entity.AngleTo(Input.Mouse.GamePosition);
			var antiAngle = angle - (float) Math.PI;
			var projectile = Projectile.Make(entity, slice, angle, speed);

			Camera.Instance.Push(antiAngle, 4f);
			entity.GetAnyComponent<BodyComponent>()?.KnockbackFrom(antiAngle);
			
			projectile.AddLight(32f, Color.Red);
			projectile.Range = range * 0.5f / speed;
		}) {
			
		}
	}
}