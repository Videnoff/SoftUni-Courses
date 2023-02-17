const jwt = require('./jwt');
const config = require('../config/config');
const models = require('../models');

module.exports = (redirectAuthenticated = true) => {

    return function (req, res, next) {
        // const token = req.cookies[config.authCookieName] || '';
        const token = req.headers.authorization || '';
        console.log(token);

        // Promise.all([
        // models.TokenBlacklist.findOne({ token })
        //         ?
        // ])
        // .then(([data, blacklistToken]) => {
        //     if (blacklistToken) { return Promise.reject(new Error('blacklisted token')) }
        jwt.verifyToken(token).then(data => {
            models.User.findById(data.id)
                .then((user) => {
                    req.user = user;
                    next();
                }).catch(err => {
                next(err);
            });
        });
        // })
        // .catch(err => {
        //     if (!redirectAuthenticated) { next(); return; }
        //
        //     if (['token expired', 'blacklisted token', 'jwt must be provided'].includes(err.message)) {
        //         res.status(401).send('UNAUTHORIZED!');
        //         return;
        //     }
        //
        //     next(err);
        // })
    }

};