var mongoose = require("mongoose")
var crypto = require("crypto")
var jwt = require("jsonwebtoken")
var Schema = mongoose.Schema

var UserSchema = new Schema({
    email: {
        type: String,
        required: false,
        unique: true
    },
    name: {
        type: String,
        required: true,
        unique: true
    },
    hash: String,
    salt: String,
    admin: Boolean
})

//  Difference between making func on chema vs model is Table vs Document
// Document is an noSQL row (ne relaciona)
UserSchema.methods.setPassword = function(password) {
    this.salt = crypto.randomBytes(16).toString('hex')
    this.hash = crypto.pbkdf2Sync(password, this.salt, 1000, 64, 'sha512').toString('hex')
}

UserSchema.methods.validatePassword = function(password) {
    hash = crypto.pbkdf2Sync(password, this.salt, 1000, 64, 'sha512').toString('hex')
    return this.hash === hash;
}

UserSchema.methods.generateJwt = function(){
    var expire = new Date()
    expire.setDate(expire.getDate()+7)
    
    return jwt.sign({
        _id: this._id,
        email: this.email,
        name: this.name,
        expire: parseInt(expire.getTime()/1000) // return miliseconds | /1000 = seconds

    }, "SECRET")
}

UserSchema.methods.getRole = function(){
    if(this.admin)
        return "ADMIN";
    return "USER";
}


var UserModel = mongoose.model('user', UserSchema)

module.exports = UserModel
