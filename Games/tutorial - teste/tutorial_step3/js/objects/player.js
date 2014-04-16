me.PlayerEntity2 = me.NPC.extend({

    init:function (x, y, settings){
        this.parent(x, y , settings);

        this.setVelocity(2, 2);
     
        this.updateColRect(2,25, -1,5);

        me.game.viewport.follow(this.pos, me.game.viewport.AXIS.BOTH);

        this.type = me.game.PLAYER_OBJECT;
        this.distance = 0;
    },

    update : function ()
    {
        this.lastdirection = this.direction;
        
        if (me.input.isKeyPressed('left')){
            this.walkleft();
        }
        else if (me.input.isKeyPressed('right')){
            this.walkright();
        }
        else if(me.input.isKeyPressed('up')){
            this.walkup();
        }
        else if(me.input.isKeyPressed('down')){
            this.walkdown();
        }
        else{
            this.stopwalk();
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

        if (this.vel.x!=0 || this.vel.y!=0)
        {
            this.parent();
            return true;
        }
        return false;
    }
});