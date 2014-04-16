me.NPC = me.ObjectEntity.extend({

    init:function (x, y, settings){
        // save the area size defined in Tiled
        //var width = settings.width;
        //var height = settings.height;;
 
        // adjust the size setting information to match the sprite size
        // so that the entity object is created with the right size
        settings.spritewidth = settings.width = 32;
        settings.spriteheight = settings.height = 64;

        this.parent(x, y , settings);

        this.renderable.addAnimation("down",   [ 0, 4,  8, 12 ]);
        this.renderable.addAnimation("left",   [ 1, 5,  9, 13 ]);
        this.renderable.addAnimation("up",     [ 2, 6, 10, 14 ]);
        this.renderable.addAnimation("right",  [ 3, 7, 11, 15 ]);

        this.renderable.addAnimation("stand-down",  [ 0 ]);
        this.renderable.addAnimation("stand-left",  [ 1 ]);
        this.renderable.addAnimation("stand-up",    [ 2 ]);
        this.renderable.addAnimation("stand-right", [ 3 ]);

        this.gravity = 0;
        this.setVelocity(1, 1);
        this.direction = "down";
         
        this.collidable = true;
        this.lastdirection = this.direction;
        
    },

    walkleft: function(){
        this.animationspeed = me.sys.fps / (me.sys.fps / 3);
        this.vel.x -= this.accel.x * me.timer.tick;
        this.vel.y = 0;
        if(this.lastdirection !== 'left'){
            this.renderable.setCurrentAnimation('left');
            this.direction = 'left';
        }
    },

    walkright: function(){
        this.animationspeed = me.sys.fps / (me.sys.fps / 3);
        this.vel.x += this.accel.x * me.timer.tick;
        this.vel.y = 0;
        if(this.lastdirection !== 'right'){
            this.renderable.setCurrentAnimation('right');
            this.direction = 'right';
        }
    },

    walkup: function(){
        this.animationspeed = me.sys.fps / (me.sys.fps / 3);
        this.vel.y -= this.accel.y * me.timer.tick; 
        this.vel.x = 0;
        if(this.lastdirection !== 'up'){
            this.renderable.setCurrentAnimation('up');
            this.direction = 'up';
        }
    },

    walkdown: function(){
        this.animationspeed = me.sys.fps / (me.sys.fps / 3);
        this.vel.y += this.accel.y * me.timer.tick; 
        this.vel.x = 0;
        if(this.lastdirection !== 'down'){
            this.renderable.setCurrentAnimation('down');
            this.direction = 'down';
        }
    },

    stopwalk: function(){
        this.vel.x = 0;
        this.vel.y = 0;
        this.renderable.setCurrentAnimation('stand-' + this.direction);
    },

    getRandomDirection: function() {
        var dir = Math.floor(Math.random() * 4) + 1;

        if(dir == 1){
            return 'left';
        }
        else if(dir == 2){
            return 'right';
        }
        else if(dir == 3){
            return 'up';
        }
        else{
            return 'down';
        }
    },

    getRandomDistance: function(){
        return Math.floor(Math.random() * 100) + 30;
    }
});