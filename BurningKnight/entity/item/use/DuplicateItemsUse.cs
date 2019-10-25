using BurningKnight.assets.items;
using BurningKnight.entity.component;
using BurningKnight.entity.item.stand;
using Lens.entity;
using Lens.util.math;
using Lens.util.timer;

namespace BurningKnight.entity.item.use {
	public class DuplicateItemsUse : ItemUse {
		public override void Use(Entity entity, Item item) {
			base.Use(entity, item);
			
			var room = entity.GetComponent<RoomComponent>().Room;

			if (room == null) {
				return;
			}

			// Copy to array, because we are going to change the list in the loop
			var items = room.Tagged[Tags.Item].ToArray();

			foreach (var it in items) {
				if (it is ItemStand ist) {
					if (ist.Item == null) {
						continue;
					}

					Timer.Add(() => {
						var st = new ItemStand();
						entity.Area.Add(st);

						ist.X -= ist.Width / 2f + 1;

						st.X = ist.X + ist.Width + 2;
						st.Y = ist.Y;

						st.SetItem(Items.CreateAndAdd(ist.Item.Id, entity.Area), item);
					}, Random.Float(0, 0.5f));
				} else if (it is Item i) {
					Timer.Add(() => {
						var st = Items.CreateAndAdd(i.Id, entity.Area);
						i.X -= i.Width / 2f + 1;
						
						st.X = i.X + i.Width + 2;
						st.Y = i.Y;
					}, Random.Float(0, 0.5f));
				}
			}
		}
	}
}