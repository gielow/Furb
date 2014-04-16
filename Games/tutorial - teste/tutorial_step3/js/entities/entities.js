/**
 * Player Entity
 */
game.PlayerEntity = me.PlayerEntity2.extend(
{
	init:function (x, y, settings)
	{
		settings.image = "snake";
		this.parent(x, y , settings);	
	}
});


/*----------------
 a Coin entity
------------------------ */
game.CoinEntity = me.CollectableEntity.extend({
    // extending the init function is not mandatory
    // unless you need to add some extra initialization
    

    init: function(x, y, settings) {
        // call the parent constructor
        this.parent(x, y, settings);

        me.debug.renderHitBox = true;
    },
    // this function is called by the engine, when
    // an object is touched by something (here collected)
    onCollision: function() {
        // do something when collected
 
        // make sure it cannot be collected "again"
        this.collidable = false;
        // remove it
        me.game.remove(this);
    }
 
});

/* --------------------------
an enemy Npc
------------------------ */
game.NpcEntity = me.EnemyEntity.extend({
	init: function(x, y, settings) {
        // define this here instead of tiled
        settings.image = "snake";
        
        // call the parent constructor
        this.parent(x, y , settings);
    }
});