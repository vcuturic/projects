var express = require('express')
var jwt = require('express-jwt')
var Game = require('../models/game')
var passport = require('./config/passport')
const igdb = require('igdb-api-node').default;
const twitchConstants = require('../constants/twitchconstants');

var router = express.Router()

router.get("/", 
    async function(req, res) {
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('*')
        .sort('total_rating')
        .limit(10) 
        .request('/games'); 
        
        res.status(200);
        res.json(response.data);
    }
)

router.post("/covers", 
    async function(req, res) {
        var games = req.body;
        var lastElement = games.filter(el => el.cover != null).slice(-1)[0];
        var query = "id = (";
        games.forEach(element => {
            if(element.cover){
                query += element.cover;
                if(element != lastElement){
                    query+= `,`;
                }
            }
        });
        query += ')';
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('url, game')
        .where(query)
        .request('/covers')
        res.status(200);
        res.json(response.data);
    }
)

router.get("/game/:id", 
    //passport.authenticate('jwt', {session:false}),
    async function(req, res) {
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('*')
        .where(`id = ${req.params.id}`)
        .request('/games'); 
        
        res.status(200);
        res.json(response.data);
    }
)

router.get("/game/:id/screenshots", 
    //passport.authenticate('jwt', {session:false}),
    async function(req, res) {
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('game, url')
        .where(`game = ${req.params.id}`)
        .request('/screenshots'); 
        
        res.status(200);
        res.json(response.data);
    }
)

router.post("/",
    passport.authenticate('jwt', {session:false}),
    (req, res)=>{
        res.send(Game.sacuvaj(req.body))
    }
)

router.get("/game/:id/cover", 
    //passport.authenticate('jwt', {session:false}),
    async function(req, res) {
        console.log("Touched");
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('game, url')
        .where(`game = ${req.params.id}`)
        .request('/covers'); 
        
        res.status(200);
        res.json(response.data[0]);
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