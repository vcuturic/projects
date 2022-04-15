var express = require('express')
var jwt = require('express-jwt')
var Game = require('../models/game')
var passport = require('./config/passport')

var router = express.Router()


router.get("/", 
    //passport.authenticate('jwt', {session:false}),
    async (req, res, next)=>
    { 
        var games = await Game.find()
        res.send(games)
    }
)

router.get("/game/:id", 
    //passport.authenticate('jwt', {session:false}),
    async (req, res, next)=>
    { 
        var game = await Game.findById(req.params.id)
        res.send(game)
    }
)

router.post("/",
    passport.authenticate('jwt', {session:false}),
    (req, res)=>{
        res.send(Game.sacuvaj(req.body))
    }
)

router.put("/", (req, res)=>{
    res.send("Update existing game.")
})

router.delete("/", (req, res)=>{
    res.send("Delete game.")
})

module.exports = router