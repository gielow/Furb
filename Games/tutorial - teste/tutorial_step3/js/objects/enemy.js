me.EnemyEntity = me.NPC.extend({

    init:function (x, y, settings){
        this.parent(x, y , settings);

        this.type = me.game.ENEMY_OBJECT;
        this.distance = 0;
    },

    update: function(dt) {
        if (!this.inViewport)
            return false;

        this.lastdirection = this.direction;

        if(this.distance <= 0){
            this.distance = this.getRandomDistance();
            this.direction = this.getRandomDirection();

            if (this.direction == 'left'){
                this.walkleft();
            }
            else if (this.direction == 'right'){
                this.walkright();
            }
            else if(this.direction == 'up'){
                this.walkup();
            }
            else if(this.direction == 'down'){
                this.walkdown();
            }
            else{
                this.stopwalk();
            }
        }
        this.distance--;
         
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