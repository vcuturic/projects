var mongoose = require('mongoose')
var Schema = mongoose.Schema

var GameSchema = new Schema({
    title: {type: String, required: true},
    yearOfPublication: {type: Number, required: true},
    cover: {type: String, required: true},
    author: {type: String, required: true},
    about: {type: String, required: true},
    small_about: {type: String, required: true},
    gameplay: {type: String, required: true}
})

// GameSchema.virtual('name').get(()=>{
//     return this.author.substring(0,indexOf(' '))
// })

var GameModel = mongoose.model('game', GameSchema)

GameModel.sacuvaj = function sacuvaj(reqGame)
{
    var game = new GameModel({
        title: reqGame.title,
        yearOfPublication: reqGame.yearOfPublication,
        cover: reqGame.cover,
        author: reqGame.author,
        about: reqGame.about,
        small_about: reqGame.small_about,
        gameplay: reqGame.gameplay
    })

    game.save((err)=>{
        if (err)
            console.log(err.stack)
    })

    return game
}


module.exports = GameModel