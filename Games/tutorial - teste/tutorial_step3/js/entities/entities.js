/**
 * Player Entity
 */
game.PlayerEntity = me.ObjectEntity.extend(
{	
  
  	/* -----

		constructor
		
	  ------			*/
	
	init:function (x, y, settings)
	{
		//settings.spritewidth=32;

		// call the constructor
		this.parent(x, y , settings);

		
		// set the default horizontal & vertical speed (accel vector)
		this.setVelocity(2, 2);
	 
		// adjust the bounding box
		this.updateColRect(2,25, -1,5);

		// disable gravity
		this.gravity = 0;
		
		// set the display to follow our position on both axis
		me.game.viewport.follow(this.pos, me.game.viewport.AXIS.BOTH);

		this.collidable = true;

		//Direção inicial
		this.direction = 'down';

		this.renderable.addAnimation("stand-down", [4]);
		this.renderable.addAnimation("stand-left", [8]);
		this.renderable.addAnimation("stand-up", [1]);
		this.renderable.addAnimation("stand-right", [11]);
		this.renderable.addAnimation("down", [3,4,5,4]);
		this.renderable.addAnimation("left", [6,7,8]);
		this.renderable.addAnimation("up", [0,1,2,1]);
		this.renderable.addAnimation("right", [9,10,11]);

		// Change Inventory and question layer position
        this.layerPosition = "right";
        
        // Keep this last direction to change only when hero change is direction
        this.lastDirection = this.direction;

		me.debug.renderHitBox = true;
		
	},

	/* -----

		update the player pos
		
	  ------			*/
	update : function ()
	{
		if (me.input.isKeyPressed('left'))
		{
			this.animationspeed = me.sys.fps / (me.sys.fps / 3);
			this.vel.x -= this.accel.x * me.timer.tick;
			this.vel.y = 0;
			if(this.direction !== 'left'){
				this.renderable.setCurrentAnimation('left');
				this.direction = 'left';
			}
		}
		else if (me.input.isKeyPressed('right'))
		{
			this.animationspeed = me.sys.fps / (me.sys.fps / 3);
			this.vel.x += this.accel.x * me.timer.tick;
			this.vel.y = 0;
			if(this.direction !== 'right'){
				this.renderable.setCurrentAnimation('right');
				this.direction = 'right';
			}
		}
		else if(me.input.isKeyPressed('up'))
		{
			this.animationspeed = me.sys.fps / (me.sys.fps / 3);
			this.vel.y -= this.accel.y * me.timer.tick; 
			this.vel.x = 0;
			if(this.direction !== 'up'){
				this.renderable.setCurrentAnimation('up');
				this.direction = 'up';
			}
		}
		else if(me.input.isKeyPressed('down'))
		{
			this.animationspeed = me.sys.fps / (me.sys.fps / 3);
			this.vel.y += this.accel.y * me.timer.tick; 
			this.vel.x = 0;
			if(this.direction !== 'down'){
				this.renderable.setCurrentAnimation('down');
				this.direction = 'down';
			}
		}
		else
		{
			this.vel.x = 0;
			this.vel.y = 0;
		}

		if (this.vel.y === 0 && this.vel.x === 0)
		{
			this.renderable.setCurrentAnimation('stand-' + this.direction);
		}
		
		
		// check & update player movement
		this.updateMovement();

		// check for collision
	    var res = me.game.collide(this);
	 
	    if (res) {
	        // if we collide with an enemy
	        if (res.obj.type == me.game.ENEMY_OBJECT) {
	            // check if we jumped on it
	            if ((res.y > 0) && ! this.jumping) {
	                // bounce (force jump)
	                this.falling = false;
	                this.vel.y = -this.maxVel.y * me.timer.tick;
	                // set the jumping flag
	                this.jumping = true;
	 
	            } else {
	                // let's flicker in case we touched an enemy
	                this.renderable.flicker(45);
	            }
	        }
	    }
			 
		// update animation
		if (this.vel.x!=0 || this.vel.y!=0)
		{
			// update object animation
			this.parent();
			return true;
		}
		
		// else inform the engine we did not perform
		// any update (e.g. position, animation)
		return false;
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
an enemy Entity
------------------------ */
game.EnemyEntity = me.ObjectEntity.extend({
    init: function(x, y, settings) {
        // define this here instead of tiled
        settings.image = "wheelie_right";
           
        // save the area size defined in Tiled
        var width = settings.width;
        var height = settings.height;;
 
        // adjust the size setting information to match the sprite size
        // so that the entity object is created with the right size
        settings.spritewidth = settings.width = 32;
        settings.spritewidth = settings.height = 32;
         
        // call the parent constructor
        this.parent(x, y , settings);
         
        // set start/end position based on the initial area size
        x = this.pos.x;
        this.startX = x;
        this.endX   = x + width - settings.spritewidth
        this.pos.x  = x + width - settings.spritewidth;
 
        // walking & jumping speed
        this.setVelocity(20, 1);
         
        // make it collidable
        this.collidable = true;
        this.type = me.game.ENEMY_OBJECT;
    },
 
    // call by the engine when colliding with another object
    // obj parameter corresponds to the other object (typically the player) touching this one
    onCollision: function(res, obj) {
 
        // res.y >0 means touched by something on the bottom
        // which mean at top position for this one
        if (this.alive && (res.y > 0) && obj.falling) {
            this.renderable.flicker(750);
        }
    },
 
    // manage the enemy movement
    update: function(dt) {
        // do nothing if not in viewport
        if (!this.inViewport)
            return false;
 
        if (this.alive) {
            if (this.walkLeft && this.pos.x <= this.startX) {
                this.walkLeft = false;
            } else if (!this.walkLeft && this.pos.x >= this.endX) {
                this.walkLeft = true;
            }
            // make it walk
            this.flipX(this.walkLeft);
            this.vel.x += (this.walkLeft) ? -this.accel.x * me.timer.tick : this.accel.x * me.timer.tick;
                 
        } else {
            this.vel.x = 0;
        }
         
        // check and update movement
        this.updateMovement();
         
        // update animation if necessary
        if (this.vel.x!=0 || this.vel.y!=0) {
            // update object animation
            this.parent(dt);
            return true;
        }
        return false;
    }
});