var mongoose = require('mongoose')
var Schema = mongoose.Schema

var GameSchema = new Schema({
    gameId: {type: Number, required: true},
    userId: {type: String, required: true}
})

var GameModel = mongoose.model('game', GameSchema)

GameModel.save = function save(reqGame)
{
    var game = new GameModel({
        gameId: reqGame.gameId,
        userId: reqGame.userId
    })

    game.save((err)=>{
        if (err) {
            console.log(err.stack)
        }
    })

    return game;
}

module.exports = GameModel