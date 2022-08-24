const express = require('express');

const AppError = require('../utils/appError');
const packageModel = require('../model/packagesModel')
const vocabModel = require('../model/vocabsModel')

const accuntRoutes = express.Router();

exports.getAllPackage = async (req, res, next) => {
    console.log('log1');
    packageModel.findAll().then(packages => {
        console.log(packages);
    })
}

exports.createPackage = async (req, res, next) => {
    console.log("req issss ================ ",req.body);
    const reqBody = req.body;
    console.log(reqBody);
    const { name, userId } = reqBody;
    const newPackage = await packageModel.create({ name: name, creator_id: userId});
    res.status(201).json({
        status : "success",
        data : {
            message : "package created.",
            user : newPackage
        }
    })
}

exports.getPackageData = async (req, res, next) => {
    const { packag_id, packag_name} = req.body;
    const vocabs = await vocabModel.findAll({packag_id: packag_id, packag_name: packag_name})
    res.status(200).json({
        status : "success",
        data : {
            message : "package vocab find.",
            user : vocabs
        }
    })
}