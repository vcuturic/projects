var passport = require("passport")
var ExtractJwt = require("passport-jwt").ExtractJwt
var JwtStrategy = require("passport-jwt").Strategy
var LocalStrategy = require("passport-local").Strategy
var User = require("../../models/user")

var localOptions = {
    usernameField: 'email',
}

passport.use(new LocalStrategy(localOptions, function (email, password, done) {
    
        User.findOne({
            $or:[
                {email: email} 
            ]
            }, function(err, user){

        // var user = await User.findOne({email: username})
        if (err)
            return done(err);

        if(!user){
            return done(null, false, {
                message:"Credentials not valid"
            })
        }

        if(!user.validatePassword(password)){
            return done(null, false, {
                message: "Credentials not valid"
            })
        }

        return done(null, user)
        })
    }
))

var JwtOptions = {
    jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
    secretOrKey: "SECRET"
}

passport.use(new JwtStrategy(JwtOptions, function(jwt_payload, done){
    var user = User.findById(jwt_payload._id)
        .then(user=>{
            return done(null, user)
        })
        .catch(err=>{
            return done(err)
        })
}))

// ... je prosledjivanje neodredjenog broja argumenata
// passport.authorizeRoles = function(...roles){
//     return function(req, res, next){
//         if(roles.find(role => role === req.user.getRole())){
//             next()
//         }
//         else{
//             res.status(403).send()
//         }
//     }
// }

module.exports = passport
