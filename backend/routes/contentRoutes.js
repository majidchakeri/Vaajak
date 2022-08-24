const express = require('express');
const contentController = require('../controllers/contentController');

const router = express.Router();

// router.route('/content').get(authController.protect, contentController.getAllPackage);
router.get('/content', contentController.getAllPackage);
router.get('/getpackagevocab', contentController.getPackageData);
router.post('/createPackage', contentController.createPackage);
module.exports= router;