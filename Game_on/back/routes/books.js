var express = require("express")
var jwt = require("express-jwt")
var Book = require("../models/book")
var passport = require("../config/passport")

var router = express.Router()

var auth = jwt({
    secret: "SECRET",
    userProperty: 'payload',
    algorithms: ["HS256"]
})

router.get('/', 
    passport.authenticate('jwt', {session: false}), 
    async (req, res) =>{
    var books = await Book.find() // ovde errror
    res.send(books);
})
router.post('/', 
    passport.authenticate('jwt', {session: false}),
    // passport.authorizeRoles("ADMIN"),
    // passport.authorizeRoles("ADMIN", "USER"),
    (req, res) =>{
        res.send(Book.sacuvaj(req.body));
    }
)
router.put('/', (req, res) =>{
    res.send("put book");
})
router.delete('/', (req, res) =>{
    res.send("delete book");
})

module.exports = router;
