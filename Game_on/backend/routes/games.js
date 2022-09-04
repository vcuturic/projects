var express = require('express')
var Game = require('../models/game')
var passport = require('./config/passport')
const igdb = require('igdb-api-node').default;
const twitchConstants = require('../constants/twitchconstants');
const url = require('url');

var router = express.Router()

router.get("/", 
    async function(req, res) {
        const queryObject = url.parse(req.url, true).query;
        let response;
        if(queryObject.search && queryObject.search != "") {
            const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
            .fields('*')
            .search(queryObject.search)
            .where(`total_rating != null`)
            .limit(queryObject.limit)
            .offset(queryObject.offset)
            .request('/games');
            res.status(200);
            res.json(response.data);
        }
        else {
            response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
            .fields('*')
            .sort('total_rating', 'desc')
            .sort('total_rating_count', 'desc')
            .where(`total_rating != null`)
            .limit(queryObject.limit)
            .offset(queryObject.offset)
            .request('/games');
            res.status(200);
            res.json(response.data);
        }
    }
)

router.post("/covers", 
    async function(req, res) {
        const queryObject = url.parse(req.url, true).query;
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
        .limit(queryObject.limit)
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
        res.json(response.data[0]);
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

router.get("/game/:id/cover", 
    //passport.authenticate('jwt', {session:false}),
    async function(req, res) {
        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('game, url')
        .where(`game = ${req.params.id}`)
        .request('/covers'); 
        
        res.status(200);
        res.json(response.data[0]);
    }
)

router.post("/genres",
    async function(req, res) {
        var genres = req.body;

        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('name')
        .where(`id = (${genres})`)
        .request('/genres'); 
        
        res.status(200);
        res.json(response.data);
    }
)

router.post("/platforms",
    async function(req, res) {
        var platforms = req.body;

        const response = await igdb(twitchConstants.CLIENT_ID, twitchConstants.CLIENT_SECRET)
        .fields('name')
        .where(`id = (${platforms})`)
        .request('/platforms'); 
        
        res.status(200);
        res.json(response.data);
    }
)

router.get("/favorites",
    passport.authenticate('jwt', {session:false}),
    async (req, res)=>{
        var favoriteGames = await Game.find({userId: req.user._id});
        res.status(200).send(favoriteGames);
    }
)

router.post("/favorites",
    passport.authenticate('jwt', {session:false}),
    (req, res)=>{
        const queryObject = url.parse(req.url, true).query;
        var game = {gameId: queryObject.gameId, userId: req.user._id};
        res.send(Game.save(game))
    }
)

router.delete("/favorites", 
    async (req, res) => {
        const queryObject = url.parse(req.url, true).query;
        res.status(200).send(await Game.deleteOne({gameId: queryObject.gameId}));
    }
);

router.put("/", (req, res)=>{
    res.send("Update existing game.")
})

module.exports = router