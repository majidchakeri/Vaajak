const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');
const Sequelize = require('sequelize');
const bcrypt = require('bcrypt');
const res = require('express/lib/response');

const usersModel = require('../model/usersModel');
const { userSchema } = require('../model/secure/userValidation');

const accuntRoutes = express.Router();


exports.getAllUser = (req, res, next) => {
    usersModel.findAll().then(users => {
        console.log('**********',users);
        res.json(users)
    }).catch(next);
};

exports.createUser = async(req, res, next) => {
    try {
        const reqBody = req.body;
        //console.log('+++++++++++++++',userSchema)
        await userSchema.validate(reqBody)
            .then(async (result) => {
                //console.log(result);
                try {
                    const { name, family, email, username, password } = req.body;

                    const userEmail = await usersModel.findOne({ where: { email: email } })
                    const userUsername = await usersModel.findOne({ where: { username: username } })
                    console.log('log baraye userEmail ine ==================',userEmail);
                    console.log('log baraye userUsername ine ==================',userUsername);
    
                    if (userEmail) {
                        const error = new Error("This email already exist.");
                        error.statusCode = 422;
                        throw error;
                    } else if (userUsername) {
                        const error = new Error("This username already exist.");
                        error.statusCode = 423;
                        throw error;
                    } else {
                        console.log('user dar hale sakhtan', name, family);
                        await usersModel.create({ name: name, family: family, email: email, username: username, password: password, status:2 });
                        console.log('user dar hale sakhtan 2222222222');
                        res.status(201).json({ 
                            status : "success",
                            data : {
                                message : "user created."
                            }
                        });

                    }
                } catch (error) {
                    console.log('catch is heare =============',error);
                }

            })
            .catch((err) => {
                console.log(err);
                throw err;
            })
    }
    catch (error) {
        next(error);
    }
};

exports.userLogin = async(req, res, next) => {
    try{
        console.log(res);
        usersModel.findAll().then(users => {
            console.log('**********',users);
            res.json(users)
        }).catch(next);
    }
    catch {
        console.log(req);
    }
};

accuntRoutes.get('/login', function () {
    res.render('account/login');
});

accuntRoutes.get('/register', function () {
    res.render('accunt/register', {errors: ""});
});
